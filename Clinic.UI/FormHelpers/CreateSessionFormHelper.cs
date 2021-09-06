using System;
using System.Collections.Generic;
using Clinic.Data.Models;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;

namespace Clinic.UI.FormHelpers
{
    public class CreateSessionFormHelper
    {
        //TODO da para em vez do edit sesion suar este helper fazer doutra forma? com interfaces tlvz
        public bool TherapistAvailable(DateTime chosenDateHour, List<SessionsDto> therapistSessions)
        {
            var therapistAvailable = true;
            foreach (var therapistSession in therapistSessions)
            {
                if (therapistSession.SessionDate == chosenDateHour)
                {
                    therapistAvailable = false;
                }
            }

            return therapistAvailable;
        }

        public SessionsDto CreateSession(string sessionHour, DateTime sessionDate, int clientId, int therapistId)
        {
            var hour = sessionHour.Split(':')[0];
            var session = new SessionsDto
            {
                Id = 0,
                SessionDate = sessionDate.AddHours(Convert.ToInt32(hour)),
                AssignedClientId = clientId,
                AssignedTherapistId = therapistId,
                TheraphistSessionNote = "",
                // -1 é o valor quando nao temos prescrições
                SessionPrescriptionId = -1,
            };
            return session;
        }
    }
}