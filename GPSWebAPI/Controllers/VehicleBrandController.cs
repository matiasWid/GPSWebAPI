using AutoMapper;
using GPSWebAPI.DTOs.VehicleBrand;
using GPSWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GPSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleBrandController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<ErrorMessages> _errorMessagesLocalizer;

        public VehicleBrandController(ApplicationDbContext context,
            IMapper mapper,
            IStringLocalizer<ErrorMessages> errorMessagesLocalizer)
        {
            this._context = context;
            this._mapper = mapper;
            this._errorMessagesLocalizer = errorMessagesLocalizer;
        }

        // GET: api/<VehicleBrandController>
        [HttpGet]
        public async Task<List<VehicleBrandDTO>> Get()
        {
            var vehicleBrand = await _context.VehicleBrands.Where(vb => vb.Active == true).ToListAsync();
            return _mapper.Map<List<VehicleBrandDTO>>(vehicleBrand);
        }

        // GET api/<VehicleBrandController>/5
        [HttpGet("{id}", Name = "getVehicleBrand")]
        public async Task<ActionResult<VehicleBrandDTO>> Get(int id)
        {
            var vehicleBrand = await _context.VehicleBrands
                .FirstOrDefaultAsync(vb => vb.Id == id);

            if (vehicleBrand == null)
                return NotFound();

            return _mapper.Map<VehicleBrandDTO>(vehicleBrand);
        }

        // POST api/<VehicleBrandController>
        [HttpPost]
        public async Task<ActionResult<VehicleBrandCreationDTO>> Post([FromBody] VehicleBrandCreationDTO vehicleBrandCreationDTO)
        {
            var vehicleBrand = _mapper.Map<VehicleBrand>(vehicleBrandCreationDTO);
            var existVehicleBrandDescription = await _context.VehicleBrands.AnyAsync(vb => vb.Description == vehicleBrandCreationDTO.Description);
            if (existVehicleBrandDescription)
                return BadRequest(_errorMessagesLocalizer["Duplicated_Entry", "description"]);
            _context.Add(vehicleBrand);
            await _context.SaveChangesAsync();
            var vehicleBrandDTO = _mapper.Map<VehicleBrandDTO>(vehicleBrand);
            return CreatedAtRoute("getVehicleBrand", new { id = vehicleBrandDTO.Id }, vehicleBrandDTO);

        }

        // PUT api/<VehicleBrandController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] VehicleBrandCreationDTO vehicleBrandCreationDTO)
        {
            if (vehicleBrandCreationDTO.Id != id)
                return BadRequest(_errorMessagesLocalizer["ID_Not_Match"]);

            var exist = _context.VehicleBrands.Any(vb => vb.Id == id );
            if (!exist)
                return NotFound();

            var vehicleBrand = _mapper.Map<VehicleBrand>(vehicleBrandCreationDTO);

            _context.Update(vehicleBrand);
            await _context.SaveChangesAsync();
            var vehicleBrandDTO = _mapper.Map<VehicleBrandDTO>(vehicleBrand);

            return CreatedAtRoute("getVehicleBrand", new { id = vehicleBrandDTO.Id }, vehicleBrandDTO); ;
        }

        // DELETE api/<VehicleBrandController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var vehicleBrand = await _context.VehicleBrands.FirstOrDefaultAsync(vb => vb.Id == id);
            if (vehicleBrand == null)
                return NotFound();

            vehicleBrand.Active = false;
            _context.Update(vehicleBrand);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
