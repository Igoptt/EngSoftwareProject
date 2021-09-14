using System.Collections.Generic;
using Clinic.Data;
using Clinic.Data.Models;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;

namespace Clinic.UI
{
    //TODO passar as coisas que usam o unit of work para aqui
    public class DatabaseManager
    {
        private readonly DatabaseContext _databaseContext;
        private readonly UnitOfWork _unitOfWork;

        public DatabaseManager()
        {
            _databaseContext = new DatabaseContext();
            _databaseContext.LoadDatabase();
            _unitOfWork = new UnitOfWork(_databaseContext);
        }

        //LoginForm methods
        public ClientDto ClientLoggingIn(string username)
        {
            var clientDb = _unitOfWork.ClientRepository.GetClientByUsername(username);
            if (clientDb != null)
            {
                return clientDb.MapToClientDto();
            }

            return null;
        }
        
        public TherapistDto TherapistLoggingIn(string username)
        {
            var therapistDb = _unitOfWork.TherapistRepository.GetTherapistByUsername(username);
            if (therapistDb != null)
            {
                return therapistDb.MapToTherapistDto();
            }

            return null;
        }
        
        //RegisterForm methods
        public int InsertNewClient(ClientDto newClient)
        {
            var clientDb = newClient.MapToClientDb();
            return _unitOfWork.ClientRepository.Insert(clientDb);
        }

        public int InsertNewTherapist(TherapistDto newTherapist)
        {
            var therapistDb = newTherapist.MapToTherapistDb();
            return _unitOfWork.TherapistRepository.Insert(therapistDb);
        }
        
        //TherapistViewForm methods
        
        public TherapistDto TherapistViewingForm(int therapistId) 
        {
            //Vai buscar o terapeuta à Db
            var therapistDb = _unitOfWork.TherapistRepository.GetTherapistById(therapistId);
            var currentTherapistSessions = _unitOfWork.SessionsRepository.GetTherapistSessions(therapistId);
            var currentTherapistPrescriptions = _unitOfWork.PrescriptionsRepository.GetPrescriptionsEmmitedCByTherapist(therapistId);
            
            //Converte o terapeuta para Dto com as sessóes
            var currentTherapist = therapistDb.MapToTherapistDto();
            currentTherapist.TherapistSessions = currentTherapistSessions.MapSessionsToDto();
            currentTherapist.TherapistPrescriptions = currentTherapistPrescriptions.MapPrescriptionsToDto();
            
            //Converte a prescrição do terapeuta com os serviços para Dto
            currentTherapist.TherapistPrescriptions = TherapistPrescriptionsWithServicesDto(currentTherapistPrescriptions, currentTherapist);
            
            return currentTherapist;
        }
        
        public List<PrescriptionDto> TherapistPrescriptionsWithServicesDto(List<Prescription> PrescriptionsDb, TherapistDto therapistDto)
        {
            
            var index = 0;
            foreach (var prescription in PrescriptionsDb)
            {
                foreach (var service in prescription.PrescribedServices)
                {
                    var medicineDb = _unitOfWork.MedicinesRepository.GetMedicineById(service);
                    if (medicineDb != null)
                    {
                        therapistDto.TherapistPrescriptions[index].PrescribedServices.Add(medicineDb.MapToMedicineDto());
                    }

                    var exerciseDb = _unitOfWork.ExercisesRepository.GetExerciseById(service);
                    if (exerciseDb != null)
                    {
                        therapistDto.TherapistPrescriptions[index].PrescribedServices.Add(exerciseDb.MapToExerciseDto());
                    }

                    var treatmentDb = _unitOfWork.TreatmentsRepository.GetTreatmentById(service);
                    if (treatmentDb != null)
                    {
                        therapistDto.TherapistPrescriptions[index].PrescribedServices.Add(treatmentDb.MapToTreatmentDto());
                    }
                }
                index++;
            }
            return therapistDto.TherapistPrescriptions;
        }
        
        //ClientViewForm methods
        
        //recebe o id do cliente e retorna o clienteDto que tenha esse Id
        public ClientDto ClientViewingForm(int clientId) 
        {
            //Vai buscar o cliente à Db
            var clientDb = _unitOfWork.ClientRepository.GetClientById(clientId);
            var currentClientSessions = _unitOfWork.SessionsRepository.GetClientSessions(clientId);
            var currentClientPrescriptions = _unitOfWork.PrescriptionsRepository.GetPrescriptionsByClient(clientId);
            
            //Converte o cliente para Dto com as sessóes
            var currentClient = clientDb.MapToClientDto();
            currentClient.ClientAppointments = currentClientSessions.MapSessionsToDto();
            currentClient.ClientPrescriptions = currentClientPrescriptions.MapPrescriptionsToDto();
            
            //Converte a prescrição do cliente com os serviços para Dto
            currentClient.ClientPrescriptions = ClientPrescriptionsWithServicesDto(currentClientPrescriptions,currentClient);
            
            return currentClient;
        }

        //mapeia a lista dos serviços de cada prescrição
        private List<PrescriptionDto> ClientPrescriptionsWithServicesDto(List<Prescription> PrescriptionsDb, ClientDto clientDto)
        {
            
            var index = 0;
            foreach (var prescription in PrescriptionsDb)
            {
                foreach (var service in prescription.PrescribedServices)
                {
                    var medicineDb = _unitOfWork.MedicinesRepository.GetMedicineById(service);
                    if (medicineDb != null)
                    {
                        clientDto.ClientPrescriptions[index].PrescribedServices.Add(medicineDb.MapToMedicineDto());
                    }

                    var exerciseDb = _unitOfWork.ExercisesRepository.GetExerciseById(service);
                    if (exerciseDb != null)
                    {
                        clientDto.ClientPrescriptions[index].PrescribedServices.Add(exerciseDb.MapToExerciseDto());
                    }

                    var treatmentDb = _unitOfWork.TreatmentsRepository.GetTreatmentById(service);
                    if (treatmentDb != null)
                    {
                        clientDto.ClientPrescriptions[index].PrescribedServices.Add(treatmentDb.MapToTreatmentDto());
                    }
                }
                index++;
            }
            return clientDto.ClientPrescriptions;
        }
        
        //TODO estas funçõpes estao no Manager e nao no helper pois vao ser usadas por varios forms
        //Vai buscar a informação completa sobre os serviços daquela prescrição
        public string GetPrescriptionServicesInformation(List<PrescriptionDto> prescriptions, int chosenPrescriptionId)
        {
            var prescriptionDetails = "";
            foreach (var prescription in prescriptions)
            {
                if (prescription.Id == chosenPrescriptionId)
                {
                    foreach (var service in prescription.PrescribedServices)
                    {
                        prescriptionDetails += ExerciseInformation(service.Id);
                        prescriptionDetails += MedicineInformation(service.Id);
                        prescriptionDetails += TreatmentInformation(service.Id);
                    }
                }
            }
            return prescriptionDetails;
        }

        public Exercise GetExerciseFromDb(int exerciseId)
        {
            return _unitOfWork.ExercisesRepository.GetExerciseById(exerciseId);
        }
        
        private string ExerciseInformation(int exerciseId)
        {
            var exerciseDetails = "";
            var exerciseBd = GetExerciseFromDb(exerciseId);
            if (exerciseBd != null) // quer dizer que o tipo de serviço era um exercise
            {
                var exerciseDto = exerciseBd.MapToExerciseDto();
                exerciseDetails +=
                    $"Este serviço é um exercicio, chamado de: {exerciseDto.Name}" +
                    $" \nTem uma intensidade de:{exerciseDto.Intensity}" +
                    $" \nO horário sugerido para fazer este exercício é: {exerciseDto.SuggestedSchedule} \n";
            }

            return exerciseDetails;
        }

        public Treatment GetTreatmentFromDb(int treatmentId)
        {
            return _unitOfWork.TreatmentsRepository.GetTreatmentById(treatmentId);
        }
        
        private string TreatmentInformation(int treatmentId)
        {
            var treatmentDetails = "";
            var treatmentDb = GetTreatmentFromDb(treatmentId);
            if (treatmentDb != null) // quer dizer que o tipo de serviço era um tratamento
            {
                var treatmentDto = treatmentDb.MapToTreatmentDto();
                treatmentDetails +=
                    $"Este serviço é um tratamento, chamado de: {treatmentDto.Name}" +
                    $" \nDo tipo:{treatmentDto.Type}" +
                    $" \nEste tratamento tem uma duração de: {treatmentDto.Duration} \n";
            }

            return treatmentDetails;
        }

        public Medicine GetMedicineFromDb(int medicineId)
        {
            return _unitOfWork.MedicinesRepository.GetMedicineById(medicineId);
        }
        
        private string MedicineInformation(int medicineId)
        {
            var medicineDetails = "";
            var medicineBd = GetMedicineFromDb(medicineId);
            if (medicineBd != null) // quer dizer que o tipo de serviço era um medicamento
            {
                var medicineDto = medicineBd.MapToMedicineDto();
                medicineDetails +=
                    $"Este serviço é um medicamento, chamado de: {medicineDto.Name}" +
                    $" \nTem uma dosagem de:{medicineDto.Dosage}" +
                    $" \nO horario sugerido para tomar este medicamento é: {medicineDto.TimeOfDayToTakeMedicine} \n";
            }

            return medicineDetails;
        }
        
        //ChangePrescritionVisibilityForm methods

        public int InsertNewSession(Sessions session)
        {
           return _unitOfWork.SessionsRepository.Insert(session);
        }

        public int InsertNewPrescription(Prescription prescription)
        {
            return _unitOfWork.PrescriptionsRepository.Insert(prescription);
        }
        
        public List<Sessions> GetTherapistSessions(int therapistId)
        {
            return _unitOfWork.SessionsRepository.GetTherapistSessions(therapistId);
        } 

        public Prescription GetChosenPrescriptionDb(int prescriptionId)
        {
            return  _unitOfWork.PrescriptionsRepository.GetPrescriptionById(prescriptionId);
        }

        public int UpdatePrescription(Prescription prescription)
        {
            return  _unitOfWork.PrescriptionsRepository.Update(prescription);
        }

        public List<Therapist> GetAllTherapists()
        {
            return _unitOfWork.TherapistRepository.GetAll();
        }

        public Therapist GetSpecificTherapistDb(int therapistId)
        {
            return _unitOfWork.TherapistRepository.GetTherapistById(therapistId);
        }

        public Client GetSpecificClient(int clientId)
        {
            return _unitOfWork.ClientRepository.GetClientById(clientId);
        }

        public int UpdateClient(Client clientDb)
        {
            return _unitOfWork.ClientRepository.Update(clientDb);
        }

        public int UpdateTherapist(Therapist therapistDb)
        {
            return _unitOfWork.TherapistRepository.Update(therapistDb);
        }

        public Sessions GetSpecificSession(int sessionId)
        {
            return _unitOfWork.SessionsRepository.GetSessionById(sessionId);
        }

        public int UpdateSession(Sessions session)
        {
            return _unitOfWork.SessionsRepository.Update(session);
        }

        public int DeleteSession(Sessions session)
        {
            return _unitOfWork.SessionsRepository.Delete(session);
        }

        public List<Medicine> GetAllMedicines()
        {
            return _unitOfWork.MedicinesRepository.GetAll();
        }

        public List<Exercise> GetAllExercises()
        {
            return _unitOfWork.ExercisesRepository.GetAll();
        }

        public List<Treatment> GetAllTreatments()
        {
            return _unitOfWork.TreatmentsRepository.GetAll();
        }

        public int InsertNewExercise(Exercise exercise)
        {
            return _unitOfWork.ExercisesRepository.Insert(exercise);
        }
        
        public int InsertNewMedicine(Medicine medicine)
        {
            return _unitOfWork.MedicinesRepository.Insert(medicine);
        }
        
        public int InsertNewTreatment(Treatment treatment)
        {
            return _unitOfWork.TreatmentsRepository.Insert(treatment);
        }

        public List<Prescription> GetAllPrescriptions()
        {
            return _unitOfWork.PrescriptionsRepository.GetAll();
        }

    }
}