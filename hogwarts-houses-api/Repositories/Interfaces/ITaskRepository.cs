using hogwarts_houses_api.Models;
using Task = hogwarts_houses_api.Models.Task;

namespace hogwarts_houses_api.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        public Task<Task> Create(Task task);
        public Task<int> Delete(int id);
        public List<Task> GetAll();
        public Task GetById(int id);
        public Task<Task> Update(int id, Task task);
    }
}
