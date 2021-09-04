using Clinic.Data.Models;

namespace Clinic.UI.DTO
{
    public static class DataMapperDbToDto
    {
        public static ClientDto MapToClientDto(this Client clientDb) 
        {
            var clientDto = new ClientDto();
            clientDto.Id = clientDb.Id;
            clientDto.Password = clientDb.Password;
            clientDto.Username = clientDb.Username;
            clientDto.FirstName = clientDb.FirstName;
            clientDto.LastName = clientDb.LastName;
            
            return clientDto;
        }
    }
}