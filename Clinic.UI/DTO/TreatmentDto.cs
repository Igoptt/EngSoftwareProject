﻿using Clinic.Data.Models;

namespace Clinic.UI.DTO
{
    public class TreatmentDto : ServiceDto
    {
        public int Duration { get; set; }
        public string Type { get; set; }
    }
}