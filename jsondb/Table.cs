using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsondb
{
    internal class Table
    {
        Database db = new Database("hogwarts-db");
        List<User> users = db.Table<User>("usuarios");
        User user = users.Where(u => u.Id == 123);
    }
}
