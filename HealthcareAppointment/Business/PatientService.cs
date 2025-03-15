using HealthcareAppointment.Models;

namespace HealthcareAppointment.Business
{
    public class PatientService
    {
        private readonly List<User> _patients = new List<User>();

        public PatientService()
        {
            _patients.Add(new User { Id = Guid.NewGuid(), Name = "John Doe", Email = "johndoe@email.com", Role = "Patient" });
        }

        public List<User> GetPatients() => _patients;
        public User GetPatientById(Guid id) => _patients.FirstOrDefault(p => p.Id == id);
        public void AddPatient(User patient) => _patients.Add(patient);
        public void UpdatePatient(User patient)
        {
            var existing = GetPatientById(patient.Id);
            if (existing != null)
            {
                existing.Name = patient.Name;
                existing.Email = patient.Email;
                existing.DateOfBirth = patient.DateOfBirth;
            }
        }
        public void DeletePatient(Guid id) => _patients.RemoveAll(p => p.Id == id);
    }
}
