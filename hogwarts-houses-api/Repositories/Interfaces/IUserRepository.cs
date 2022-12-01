using hogwarts_houses_api.Models;

namespace hogwarts_houses_api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public User Create(User user);
        public User GetById(Guid id);
        public User Login(User user);
        public User Update(User user);
        public House ChooseHouse();
    }
}
