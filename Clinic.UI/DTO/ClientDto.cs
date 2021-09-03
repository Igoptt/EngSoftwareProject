using System.Collections.Generic;
using Clinic.Data.Models;

namespace Clinic.UI.DTO
{
    public class ClientDto
    {
        
        public List<SessionsDto> ClientAppointments { get; set; }
        public List<PrescriptionDto> ClientPrescriptions { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }   
        public string LastName { get; set; }   
        public string Username { get; set; }   
        public string Password { get; set; }
        //public UserTypeDto UserType { get; set; }

    }

    // public enum UserTypeDto
    // {
    //     Client,
    //     Therapist
    // }
}