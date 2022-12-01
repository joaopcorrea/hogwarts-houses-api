using hogwarts_houses_api.Models;
using hogwarts_houses_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            if (users.Count < 1)
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

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {


            return Ok();
        } 

        [HttpPost("chooseHouse")]
        public void ChooseHouse()
        {
        }
    }
}
