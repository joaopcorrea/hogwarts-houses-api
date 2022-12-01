using hogwarts_houses_api.Models;

namespace hogwarts_houses_api.Repositories.Interfaces
{
    public interface IHouseRepository
    {
        public Task<int> AddPoints(int id, int points);
        public Task<House> Create(House house);
        public Task<int> Delete(int id);
        public List<House> GetAll();
        public House GetById(int id);
        public Task<int> SubtractPoints(int id, int points);
        public Task<House> Update(int id, House house);
    }
}
