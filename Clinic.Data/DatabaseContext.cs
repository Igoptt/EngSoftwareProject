using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Clinic.Data.Models;
using Clinic.Data.Repositories;
using Newtonsoft.Json;

namespace Clinic.Data
{
    public class DatabaseContext
    {
        private Database _database;
        private string _jsonDbPath;

        public DatabaseContext()
        {
            string executableLocation = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);
            _jsonDbPath = Path.Combine(executableLocation, "clinic.json");
        }

        public void LoadDatabase()
        {
            _database = JsonConvert.DeserializeObject<Database>(File.ReadAllText(_jsonDbPath));
        }

        public void SaveDatabase()
        {
            File.WriteAllText(_jsonDbPath, JsonConvert.SerializeObject(_database));
        }

        public Database GetDataBase()
        {
            return _database;
        }

    }
}