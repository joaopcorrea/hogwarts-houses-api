using jsondb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace jsondb
{
    internal class Database
    {
        private string db;

        public Database(string dbName)
        {
            var json = FileRepository.ReadFile(dbName);
            db = JsonSerializer.Deserialize(json, object);
        }

        public List<T> Table<T>(string tableName)
        {
            return new List<T>();
        }
    }
}
