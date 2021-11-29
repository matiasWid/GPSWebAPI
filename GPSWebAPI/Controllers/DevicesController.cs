using AutoMapper;
using GPSWebAPI.DTOs;
using GPSWebAPI.DTOs.Device;
using GPSWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Linq;

namespace GPSWebAPI.Controllers
{
    [ApiController]
    [Route("api/devices")]
    public class DevicesController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DevicesController> _logger;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<ErrorMessages> _errorMessagesLocalizer;

        public DevicesController(ApplicationDbContext applicationDbContext, 
            ILogger<DevicesController> logger,
            IMapper mapper,
            IStringLocalizer<ErrorMessages> errorMessagesLocalizer)
        {
            this._context = applicationDbContext;
            this._logger = logger;
            this._mapper = mapper;
            this._errorMessagesLocalizer = errorMessagesLocalizer;
        }
        [HttpGet]
        public async Task<ActionResult<List<DeviceDTO>>> Get()
        {
            var devices = await _context.Devices.Where(d => d.Active == true).ToListAsync();

            return _mapper.Map<List<DeviceDTO>>(devices);
        }

        [HttpGet("{id:int}", Name = "getDevice")]
        public async Task<ActionResult<DeviceVehicleDTO>> Get(int id)
        {
            var devices = await _context.Devices
                .Include(d => d.Vehicle)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (devices == null)
                return NotFound();

            return _mapper.Map<DeviceVehicleDTO>(devices);
        }

        [HttpPost]
        public async Task<ActionResult<DeviceDTO>> Post([FromBody] DeviceCreationDTO deviceCreationDTO)
        {
            try
            {
                var device = _mapper.Map<Device>(deviceCreationDTO);
                var existDeviceSameSerie = await _context.Devices.AnyAsync(d => d.Serial == device.Serial);
                if (existDeviceSameSerie)
                    return BadRequest(_errorMessagesLocalizer["Duplicated_Entry", "serial"]);
                _context.Add(device);
                await _context.SaveChangesAsync();
                var deviceDTO = _mapper.Map<DeviceDTO>(device);
                return CreatedAtRoute("getDevice", new { id = deviceDTO.Id }, deviceDTO);
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx.Message);
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }


        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromBody] Device device, int id)
        {
            if (device.Id != id)
                return BadRequest(_errorMessagesLocalizer["ID_Not_Match"]);
            _context.Update(device);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var device = await _context.Devices.FirstOrDefaultAsync<Device>(d=> d.Id == id);
            if (device == null)
                return NotFound();

            device.Active = false;
            _context.Update(device);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
