using AutoMapper;
using GPSWebAPI.DTOs;
using GPSWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace GPSWebAPI.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class VehiclesController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<VehiclesController> _logger;
        private readonly IStringLocalizer<ErrorMessages> _errorMessagesLocalizer;

        public VehiclesController(ApplicationDbContext context,
            IMapper mapper,
            ILogger<VehiclesController> logger,
            IStringLocalizer<ErrorMessages> errorMessagesLocalizer)
        {
            this._context = context;
            this._mapper = mapper;
            this._logger = logger;
            this._errorMessagesLocalizer = errorMessagesLocalizer;
        }

        [HttpGet]
        public async Task<ActionResult<List<VehicleDTO>>> Get()
        {
            var vehicles  = await _context.Vehicles
                .Where(v => v.Active == true).ToListAsync();
            return _mapper.Map<List<VehicleDTO>>(vehicles);
        }

        [HttpGet("{id:int}", Name = "getVehicle")]
        public async Task<ActionResult<VehicleDTO>> Get([FromQuery] int id)
        {
            var vehicle = await _context.Vehicles
                .Include(v => v.Device)
                .FirstOrDefaultAsync(v => v.Id == id && v.Active == true);

            if (vehicle == null)
                return NotFound();

            return _mapper.Map<VehicleDTO>(vehicle);
        }

        [HttpPost]
        public async Task<ActionResult<VehicleDTO>> Post([FromBody] VehicleCreationDTO vehicleCreationDTO)
        {
            var vehicle = _mapper.Map<Vehicle>(vehicleCreationDTO);            
            
            _context.Add(vehicle);
            await _context.SaveChangesAsync();

            var vehicleDTO = _mapper.Map<VehicleDTO>(vehicle);
            return CreatedAtRoute("getVehicle", new {id = vehicleDTO.Id}, vehicleDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Vehicle>> Post([FromQuery] int id, [FromBody] Vehicle vehicle)
        {
            if (vehicle.Id != id)
                return BadRequest(_errorMessagesLocalizer["ID_Not_Match"]);
            _context.Update(vehicle);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            var vehicle = await _context.Vehicles.FirstOrDefaultAsync<Vehicle>(v => v.Id == id);
            if (vehicle == null)
                return NotFound();

            vehicle.Active = false;
            _context.Update(vehicle);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
