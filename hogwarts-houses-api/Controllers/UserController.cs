using hogwarts_houses_api.Models;
using hogwarts_houses_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hogwarts_houses_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _repository.GetAll();
            if (!users.Any())
                return NotFound();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _repository.GetById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            var createdUser = await _repository.Create(user);

            return Created("", createdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            var updatedUser = await _repository.Update(id, user);

            return Ok(updatedUser);
        }

        [HttpPost("{id}/chooseHouse")]
        public async Task<IActionResult> ChooseHouse(int id)
        {
            var house = await _repository.ChooseHouse(id);

            return Ok(house);
        }
    }
}
