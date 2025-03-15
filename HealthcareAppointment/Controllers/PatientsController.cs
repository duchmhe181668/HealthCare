using HealthcareAppointment.Business;
using HealthcareAppointment.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAppointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly PatientService _service;

        public PatientsController()
        {
            _service = new PatientService();
        }

        [HttpGet]
        public ActionResult<List<User>> GetPatients() => _service.GetPatients();

        [HttpGet("{id}")]
        public ActionResult<User> GetPatientById(Guid id)
        {
            var patient = _service.GetPatientById(id);
            return patient != null ? Ok(patient) : NotFound();
        }

        [HttpPost]
        public IActionResult AddPatient([FromBody] User patient)
        {
            _service.AddPatient(patient);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePatient(Guid id, [FromBody] User patient)
        {
            patient.Id = id;
            _service.UpdatePatient(patient);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(Guid id)
        {
            _service.DeletePatient(id);
            return Ok();
        }
    }
}