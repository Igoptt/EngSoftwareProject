using System;
using Clinic.UI.DTO;

namespace Clinic.UI.FormHelpers
{
    public class EditSessionFormHelper
    {
        public SessionsDto UpdateSession(string sessionHour, DateTime sessionDate, SessionsDto oldSession)
        {
            var hour = sessionHour.Split(':')[0];
            var session = oldSession;
            session.SessionDate = sessionDate.AddHours(Convert.ToInt32(hour));
            return session;
        }
    }
}