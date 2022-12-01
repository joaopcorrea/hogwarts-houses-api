using hogwarts_houses_api.Database;
using hogwarts_houses_api.Models;
using hogwarts_houses_api.Repositories.Interfaces;
using System.Threading.Tasks;

namespace hogwarts_houses_api.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private readonly DatabaseContext _context;

        public HouseRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<int> AddPoints(int id, int points)
        {
            var house = _context.Houses.Find(h => h.Id == id).FirstOrDefault();
            if (house == null) return -1;

            house.Points += points;

            await _context.Houses.UpdateOneAsync(id, house);

            return house.Points;
        }

        public async Task<House> Create(House house)
        {
            await _context.Houses.InsertOneAsync(house);

            return house;
        }

        public async Task<int> Delete(int id)
        {
            await _context.Houses.DeleteOneAsync(id);

            return id;
        }

        public List<House> GetAll() => _context.Houses.AsQueryable().ToList();

        public House GetById(int id) => _context.Houses.Find(h => h.Id == id).FirstOrDefault();

        public async Task<int> SubtractPoints(int id, int points)
        {
            var house = _context.Houses.Find(h => h.Id == id).FirstOrDefault();
            if (house == null) return -1;

            house.Points -= points;

            await _context.Houses.UpdateOneAsync(id, house);

            return house.Points;
        }

        public async Task<House> Update(int id, House house)
        {
            await _context.Houses.UpdateOneAsync(id, house);

            return house;
        }
    }
}
