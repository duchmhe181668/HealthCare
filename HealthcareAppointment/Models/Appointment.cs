﻿namespace HealthcareAppointment.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } // Scheduled, Completed, Cancelled
    }
}
