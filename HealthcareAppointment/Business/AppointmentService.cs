using HealthcareAppointment.Models;

namespace HealthcareAppointment.Business
{
    public class AppointmentService
    {
        private readonly List<Appointment> _appointments = new List<Appointment>();

        public AppointmentService()
        {
            _appointments.Add(new Appointment
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                DoctorId = Guid.NewGuid(),
                Date = DateTime.Now.AddDays(1),
                Status = "Scheduled"
            });
        }

        public List<Appointment> GetAppointments() => _appointments;
        public Appointment GetAppointmentById(Guid id) => _appointments.FirstOrDefault(a => a.Id == id);
        public void AddAppointment(Appointment appointment) => _appointments.Add(appointment);
        public void UpdateAppointment(Appointment appointment)
        {
            var existing = GetAppointmentById(appointment.Id);
            if (existing != null)
            {
                existing.PatientId = appointment.PatientId;
                existing.DoctorId = appointment.DoctorId;
                existing.Date = appointment.Date;
                existing.Status = appointment.Status;
            }
        }
        public void DeleteAppointment(Guid id) => _appointments.RemoveAll(a => a.Id == id);
        public void CancelAppointment(Guid id)
        {
            var appointment = GetAppointmentById(id);
            if (appointment != null) appointment.Status = "Cancelled";
        }

        public List<Appointment> GetAppointmentsForDoctor(Guid doctorId, int pageNumber, int pageSize)
        {
            return _appointments
                .Where(a => a.DoctorId == doctorId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
