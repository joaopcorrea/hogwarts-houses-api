using hogwarts_houses_api.Database;
using hogwarts_houses_api.Models;
using hogwarts_houses_api.Repositories.Interfaces;

namespace hogwarts_houses_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<House> ChooseHouse(int id)
        {
            var user = _context.Users.Find(u => u.Id == id).FirstOrDefault();
            if (user == null) throw new Exception("Id inválido");

            var houseId = 0;

            if (user.HouseId != 0)
            {
                houseId = user.HouseId;
            }
            else
            {
                houseId = _context.Users.AsQueryable()
                    .GroupBy(u => u.HouseId)
                    .Select(g => new { g.Key, Count = g.Count() })
                    .OrderBy(g => g.Count)
                    .Select(h => h.Key)
                    .FirstOrDefault();

                user.HouseId = houseId;

                await _context.Users.UpdateOneAsync(user.Id, user);
            }

            var house = _context.Houses.AsQueryable().FirstOrDefault(h => h.Id == houseId);
            return house;
        }

        public async Task<User> Create(User user)
        {
            await _context.Users.InsertOneAsync(user);

            return user;
        }

        public List<User> GetAll() => _context.Users.AsQueryable().ToList();

        public User GetById(int id) => _context.Users.AsQueryable()
                                                     .FirstOrDefault(u => u.Id == id);

        public async Task<User> Update(int id, User user)
        {
            await _context.Users.UpdateOneAsync(id, user);

            return user;
        }
    }
}
