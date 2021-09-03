using System.Collections.Generic;

namespace Clinic.Data.Models
{
    public class Client : User
    {
        public Client()
        {
            ClientAppointments = new List<Sessions>();
            ClientPrescriptions = new List<Prescription>();
        }
        public List<Sessions> ClientAppointments { get; set; }
        public List<Prescription> ClientPrescriptions { get; set; }
    }
}