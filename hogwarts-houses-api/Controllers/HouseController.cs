using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hogwarts_houses_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        // GET: api/<HouseController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<HouseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HouseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HouseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HouseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("points")]
        public void GetPoints(int id)
        {
        }

        [HttpPost("points/add/{points}")]
        public void AddPoints(int points)
        {
        }

        [HttpPost("points/remove/{points}")]
        public void RemovePoints(int points)
        {
        }
    }
}
