using hogwarts_houses_api.Models;
using hogwarts_houses_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hogwarts_houses_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        readonly ITaskRepository _repository;

        public TaskController(ITaskRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tasks = _repository.GetAll();
            if (!tasks.Any())
                return NotFound();

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var task = _repository.GetById(id);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Models.Task task)
        {
            var createdTask = await _repository.Create(task);

            return Created("", createdTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Models.Task task)
        {
            var updatedTask = await _repository.Update(id, task);

            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.Delete(id);

            return NoContent();
        }
    }
}
