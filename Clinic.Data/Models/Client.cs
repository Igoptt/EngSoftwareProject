using System.Collections.Generic;

namespace Clinic.Data.Models
{
    public class Client : User
    {
        public Client()
        {
            ClientAppointments = new List<int>();
            ClientPrescriptions = new List<int>();
        }
        public List<int> ClientAppointments { get; set; }
        public List<int> ClientPrescriptions { get; set; }
    }
}