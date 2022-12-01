using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsondb.Repositories
{
    internal class FileRepository
    {
        public FileRepository()
        {

        }

        internal void CreateFile(string file)
        {
            if (!File.Exists(file))
            {
                File.Create(file);
            }


        }

        internal void UpdateFile(string file, string content)
        {
            if (!File.Exists(file))
            {
                File.Create(file);
            }

            File.WriteAllText(file, content);
        }

        internal static string ReadFile(string file) {
            return File.ReadAllText(file);
        }
    }
}
