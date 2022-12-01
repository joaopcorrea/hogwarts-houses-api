using hogwarts_houses_api.Models;
using hogwarts_houses_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hogwarts_houses_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        readonly IHouseRepository _repository;

        public HouseController(IHouseRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var houses = _repository.GetAll();
            if (!houses.Any())
                return NotFound();

            return Ok(houses);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var house = _repository.GetById(id);
            if (house == null)
                return NotFound();

            return Ok(house);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] House house)
        {
            var createdHouse = await _repository.Create(house);

            return Created("", createdHouse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] House house)
        {
            var updatedHouse = await _repository.Update(id, house);

            return Ok(updatedHouse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.Delete(id);

            return NoContent();
        }

        [HttpPost("{id}/points/add/{points}")]
        public async Task<IActionResult> AddPoints(int id, int points)
        {
            var res = await _repository.AddPoints(id, points);
            return Ok(res);
        }

        [HttpPost("{id}/points/subtract/{points}")]
        public async Task<IActionResult> SubtractPoints(int id, int points)
        {
            var res = await _repository.SubtractPoints(id, points);
            return Ok(res);
        }
    }
}
