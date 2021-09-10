using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Clinic.UI.DTO;

namespace Clinic.UI.FormHelpers
{
    public class AddPrescriptionFormHelper
    {

        public bool ServiceChosen(ComboBox cb_service)
        {
            if (cb_service.SelectedIndex > -1)
            {
                return true;
            }

            return false;
        }
        
        public PrescriptionDto CreatePrescription(int clientId, int theraphistAuthor, List<ServiceDto> prescriptionServices)
        {
            var prescription = new PrescriptionDto()
            {
                Id = 0,
                ClientId = clientId,
                PrescribedServices = prescriptionServices,
                PrescriptionAuthorId = theraphistAuthor,
            };
            return prescription;
            
        }
    }
}