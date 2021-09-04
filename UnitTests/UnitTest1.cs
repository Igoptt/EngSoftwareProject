using Clinic.UI.DTO;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MapToClientDbSucess()
        {
            var clientDto = new ClientDto()
            {
                Id = 1,
                Password = "234",
                Username = "user",
                FirstName = "firstName",
                LastName = "lastName",
            };
            var result = clientDto.MapToClientDb();
            result.Id.Should().Be(clientDto.Id);
            result.Username.Should().Be(clientDto.Username);
        }
        
        [Test]
        public void MapToExerciseDbSucess()
        {
            var exercisedto = new ExerciseDto()
            {
                Id = 1,
                Price = 2.2,
                Name = "user",
                PrescriptionId = 2,
                Intensity = 10,
            };
            var result = exercisedto.MapToExerciseDb();
            result.Id.Should().Be(exercisedto.Id);
            result.PrescriptionId.Should().Be(exercisedto.PrescriptionId);
        }
        
        
        
    }
}