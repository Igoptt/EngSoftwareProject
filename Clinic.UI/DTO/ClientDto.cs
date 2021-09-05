using System.Collections.Generic;
using Clinic.Data.Models;

namespace Clinic.UI.DTO
{
    public class ClientDto : UserDto
    {
        public ClientDto()
        {
            ClientAppointments = new List<SessionsDto>();
            ClientPrescriptions = new List<PrescriptionDto>();
        }
        
        public List<SessionsDto> ClientAppointments { get; set; }
        public List<PrescriptionDto> ClientPrescriptions { get; set; }
        
        //public UserTypeDto UserType { get; set; }

    }

    // public enum UserTypeDto
    // {
    //     Client,
    //     Therapist
    // }
}