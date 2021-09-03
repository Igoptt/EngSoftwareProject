using Clinic.Data.Models;

namespace Clinic.UI.DTO
{
    public static class DataMapper
    {
        
        public static Client MapToDb(this ClientDto dto)
        {
            return new Client()
            {
                Id = dto.Id,
                Password = dto.Password,
                Username = dto.Username,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                //UserType = (UserType)dto.UserType
                //TODO rest of the stuff
            };
        }
    }
}