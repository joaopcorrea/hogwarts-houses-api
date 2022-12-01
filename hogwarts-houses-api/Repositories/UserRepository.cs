using hogwarts_houses_api.Database;
using hogwarts_houses_api.Models;
using hogwarts_houses_api.Repositories.Interfaces;
using JsonFlatFileDataStore;

namespace hogwarts_houses_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public House ChooseHouse()
        {
            throw new NotImplementedException();
        }

        public async Task<User> Create(User user)
        {
            await _context.Users.InsertOneAsync(user);

            return user;
        }

        public List<User> GetAll()
        {
            return _context.Users.AsQueryable().ToList();
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public User Login(User user)
        {
            throw new NotImplementedException();
        }

        public User Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
