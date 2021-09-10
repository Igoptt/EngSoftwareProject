using Clinic.Data.Models;
using Clinic.UI.DTO;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests
{
    public class Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MapToClientDtoSucess()
        {
            var client = new Client()
            {
                Id = 1,
                Password = "234",
                Username = "user",
                FirstName = "firstName",
                LastName = "lastName",
            };
            var result = client.MapToClientDto();
            result.Id.Should().Be(client.Id);
            result.Username.Should().Be(client.Username);
        }

        [Test]
        public void MapToExerciseDtoSucess()
        {
            var exercise = new Exercise()
            {
                Id = 1,
                // Price = 2.2,
                Name = "user",
                // PrescriptionId = 2,
                Intensity = 10,
            };
            var result = exercise.MapToExerciseDto();
            result.Id.Should().Be(exercise.Id);
            // result.PrescriptionId.Should().Be(exercise.PrescriptionId);
            result.Name.Should().Be(exercise.Name);
        }
        
        [Test]
        public void MapToMedicineDtoSucess()
        {
            var medicine = new Medicine()
            {
                Id = 1,
                // Price = 2.2,
                Name = "user",
                // PrescriptionId = 2,
                
                Dosage = "500g",
                TimeOfDayToTakeMedicine = "noite",
            };
            var result = medicine.MapToMedicineDto();
            result.Id.Should().Be(medicine.Id);
            // result.PrescriptionId.Should().Be(medicine.PrescriptionId);
            // result.Price.Should().Be(medicine.Price);
            result.Dosage.Should().Be(medicine.Dosage);
        }
        
        [Test]
        public void MapToTreatmentDtoSucess()
        {
            var treatment = new Treatment()
            {
                Id = 1,
                // Price = 2.2,
                Name = "user",
                // PrescriptionId = 2,
                
                Duration = "15",
                Type = "terapeutico",
            };
            var result = treatment.MapToTreatmentDto();
            result.Id.Should().Be(treatment.Id);
            // result.PrescriptionId.Should().Be(treatment.PrescriptionId);
            // result.Price.Should().Be(treatment.Price);
            result.Duration.Should().Be(treatment.Duration);
        }

        [Test]
        public void MapToPrescriptionDtoSucess()
        {
            var prescription = new Prescription()
            {
                Id = 1,
                
            };
            var result = prescription.MapToPrescriptionDto();
            result.Id.Should().Be(prescription.Id);
        }

        [Test]
        public void MapToSessionsDtoSucess()
        {
            var sessions = new Sessions()
            {
                Id = 1,
                AssignedClientId = 2,
                AssignedTherapistId = 3,
                TheraphistSessionNote = "teste",
                // SessionActivities = ,
            };
            var result = sessions.MapToSessionsDto();
            result.Id.Should().Be(sessions.Id);
            // result.SessionActivities.Should().Be(sessions.SessionActivities);
        }
        
        [Test]
        public void MapToTherapistDtoSucess()
        {
            var therapist = new Therapist()
            {
                Id = 1,
                Password = "234",
                Username = "user",
                FirstName = "firstName",
                LastName = "lastName",
            };
            var result = therapist.MapToTherapistDto();
            result.Id.Should().Be(therapist.Id);
            result.Username.Should().Be(therapist.Username);
            result.FirstName.Should().Be(therapist.FirstName);
            result.LastName.Should().Be(therapist.LastName);
        }
    }
}