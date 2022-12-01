using hogwarts_houses_api.Models;

namespace hogwarts_houses_api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public List<User> GetAll();
        public Task<User> Create(User user);
        public User GetById(int id);
        public Task<User> Update(int id, User user);
        public Task<House> ChooseHouse(int id);
    }
}
