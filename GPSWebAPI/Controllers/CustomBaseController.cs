using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GPSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CustomBaseController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/<CustomBaseController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CustomBaseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomBaseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomBaseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomBaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
