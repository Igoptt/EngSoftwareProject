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
                // Price = 2.2,
                Name = "user",
                // PrescriptionId = 2,
                Intensity = 10,
            };
            var result = exercisedto.MapToExerciseDb();
            result.Id.Should().Be(exercisedto.Id);
            // result.PrescriptionId.Should().Be(exercisedto.PrescriptionId);
            result.Name.Should().Be(exercisedto.Name);
        }
        
        [Test]
        public void MapToMedicineDbSucess()
        {
            var medicineDto = new MedicineDto()
            {
                Id = 1,
                // Price = 2.2,
                Name = "user",
                // PrescriptionId = 2,
                
                Dosage = "500g",
                TimeOfDayToTakeMedicine = "noite",
            };
            var result = medicineDto.MapToMedicineDb();
            result.Id.Should().Be(medicineDto.Id);
            // result.PrescriptionId.Should().Be(medicineDto.PrescriptionId);
            // result.Price.Should().Be(medicineDto.Price);
            result.Dosage.Should().Be(medicineDto.Dosage);
        }
        
        [Test]
        public void MapToTreatmentDbSucess()
        {
            var treatmentDto = new TreatmentDto()
            {
                Id = 1,
                // Price = 2.2,
                Name = "user",
                // PrescriptionId = 2,
                
                Duration = "15",
                Type = "terapeutico",
            };
            var result = treatmentDto.MapToTreatmentDb();
            result.Id.Should().Be(treatmentDto.Id);
            // result.PrescriptionId.Should().Be(treatmentDto.PrescriptionId);
            // result.Price.Should().Be(treatmentDto.Price);
            result.Duration.Should().Be(treatmentDto.Duration);
        }

        [Test]
        public void MapToPrescriptionDbSucess()
        {
            var prescriptionDto = new PrescriptionDto()
            {
                Id = 1,
                
            };
            var result = prescriptionDto.MapToPrescriptionDb();
            result.Id.Should().Be(prescriptionDto.Id);
        }

        [Test]
        public void MapToSessionsDbSucess()
        {
            var sessionsDto = new SessionsDto()
            {
                Id = 1,
                AssignedClientId = 2,
                AssignedTherapistId = 3,
                TheraphistSessionNote = "teste",
                SessionPrescriptionId = 5,
            };
            var result = sessionsDto.MapToSessionsDb();
            result.Id.Should().Be(sessionsDto.Id);
            result.SessionPrescriptionId.Should().Be(sessionsDto.SessionPrescriptionId);
        }
        
        [Test]
        public void MapToTherapistDbSucess()
        {
            var therapistDto = new TherapistDto()
            {
                Id = 1,
                Password = "234",
                Username = "user",
                FirstName = "firstName",
                LastName = "lastName",
            };
            var result = therapistDto.MapToTherapistDb();
            result.Id.Should().Be(therapistDto.Id);
            result.Username.Should().Be(therapistDto.Username);
            result.FirstName.Should().Be(therapistDto.FirstName);
            result.LastName.Should().Be(therapistDto.LastName);
        }
        


        
        
    }
}