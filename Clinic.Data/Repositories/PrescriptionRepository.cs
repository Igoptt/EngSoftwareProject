using System.Collections.Generic;
using Clinic.Data.Models;
using Clinic.Data.Repositories.Interfaces;

namespace Clinic.Data.Repositories
{
    public class PrescriptionRepository:RepositoryBase<Prescription>, IPrescriptionRepository
    {
        public PrescriptionRepository(DatabaseContext context) : base(context)
        {
        }

        // public Therapist GetPrescriptonAuthor(int prescriptionId)
        // {
        //     
        // }
        //
        // public List<Therapist> GetTherapistsWithAcess(int prescriptionId)
        // {
        //     
        // }
        
        //metodo para mudar a visibilidade da prescriçao, adicionar therapists a lista TherapistsWithAcess

        // public Client GetPrescriptionClient(int prescriptionId)
        // {
        //     
        // }
        
        //metodo para ir buscar os serviços da prescriçao 
        
    }
}