using hogwarts_houses_api.Database;
using hogwarts_houses_api.Models;
using hogwarts_houses_api.Repositories.Interfaces;
using System.Threading.Tasks;

namespace hogwarts_houses_api.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DatabaseContext _context;

        public TaskRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Models.Task> Create(Models.Task task)
        {
            await _context.Tasks.InsertOneAsync(task);

            return task;
        }

        public async Task<int> Delete(int id)
        {
            await _context.Tasks.DeleteOneAsync(id);

            return id;
        }

        public List<Models.Task> GetAll() => _context.Tasks.AsQueryable().ToList();

        public Models.Task GetById(int id) => _context.Tasks.AsQueryable().FirstOrDefault(t => t.Id == id);

        public async Task<Models.Task> Update(int id, Models.Task task)
        {
            await _context.Tasks.UpdateOneAsync(id, task);

            return task;
        }
    }
}
