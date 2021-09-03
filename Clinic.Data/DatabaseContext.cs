using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Clinic.Data.Models;
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
            // _database = new Database();
            // _database.Clients = new List<Client>()
            // {
            //     new Client { Id = 1, FirstName = "Rodrigo", LastName = "", Username = "igo", Password = "1234", UserType = UserType.Client},
            //     new Client { Id = 1, FirstName = "Joao", LastName = "", Username = "jo", Password = "1234", UserType = UserType.Therapist },
            // };
            
            
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