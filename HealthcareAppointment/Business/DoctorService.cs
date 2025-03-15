using HealthcareAppointment.Models;

namespace HealthcareAppointment.Business
{
    public class DoctorService
    {
        private readonly List<User> _doctors = new List<User>();

        public DoctorService()
        {
            _doctors.Add(new User { Id = Guid.NewGuid(), Name = "Dr. Smith", Email = "drsmith@email.com", Role = "Doctor" });
        }

        public List<User> GetDoctors() => _doctors;
        public User GetDoctorById(Guid id) => _doctors.FirstOrDefault(d => d.Id == id);
        public void AddDoctor(User doctor) => _doctors.Add(doctor);
        public void UpdateDoctor(User doctor)
        {
            var existing = GetDoctorById(doctor.Id);
            if (existing != null)
            {
                existing.Name = doctor.Name;
                existing.Email = doctor.Email;
                existing.DateOfBirth = doctor.DateOfBirth;
            }
        }
        public void DeleteDoctor(Guid id) => _doctors.RemoveAll(d => d.Id == id);
    }
}
