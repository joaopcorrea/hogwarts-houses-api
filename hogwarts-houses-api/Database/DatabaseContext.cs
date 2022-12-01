using hogwarts_houses_api.Models;
using JsonFlatFileDataStore;

namespace hogwarts_houses_api.Database
{
    public class DatabaseContext
    {
        private readonly DataStore _store;

        public DatabaseContext(DataStore store)
        {
            _store = store;
        }

        public IDocumentCollection<House> Houses { get => _store.GetCollection<House>(); }
        public IDocumentCollection<Models.Task> Tasks { get => _store.GetCollection<Models.Task>(); }
        public IDocumentCollection<User> Users { get => _store.GetCollection<User>(); }
    }
}
