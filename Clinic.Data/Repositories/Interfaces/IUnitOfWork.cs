using System;

namespace Clinic.Data.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository ClientRepository { get; set; }
        ITherapistRepository TherapistRepository { get; set; }
        IPrescriptionRepository PrescriptionsRepository { get; set; }
        ISessionsRepository SessionsRepository { get; set; }
        IServiceRepository ServicesRepository { get; set; }
        IExerciseRepository ExercisesRepository { get; set; }
        IMedicineRepository MedicinesRepository { get; set; }
        ITreatmentRepository TreatmentsRepository { get; set; }
        // void Commit();
    }
}