using Clinic.Data.Models;
using Clinic.Data.Repositories.Interfaces;

namespace Clinic.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
            ClientRepository = new ClientRepository(_context);
            TherapistRepository = new TherapistRepository(_context);
            PrescriptionsRepository = new PrescriptionRepository(_context);
            SessionsRepository = new SessionsRepository(_context);
            ServicesRepository = new ServiceRepository(_context);
            ExercisesRepository = new ExerciseRepository(_context);
            MedicinesRepository = new MedicineRepository(_context);
            TreatmentsRepository = new TreatmentRepository(_context);

        }
        
        public IClientRepository ClientRepository { get; set; }
        public ITherapistRepository TherapistRepository { get; set; }
        public IPrescriptionRepository PrescriptionsRepository { get; set; }
        public ISessionsRepository SessionsRepository { get; set; }
        public IServiceRepository ServicesRepository { get; set; }
        public IExerciseRepository ExercisesRepository { get; set; }
        public IMedicineRepository MedicinesRepository { get; set; }
        public ITreatmentRepository TreatmentsRepository { get; set; }
        
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}