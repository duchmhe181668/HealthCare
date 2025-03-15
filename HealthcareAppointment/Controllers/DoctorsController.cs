using HealthcareAppointment.Business;
using HealthcareAppointment.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAppointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly DoctorService _service;

        public DoctorsController()
        {
            _service = new DoctorService();
        }

        [HttpGet]
        public ActionResult<List<User>> GetDoctors() => _service.GetDoctors();

        [HttpGet("{id}")]
        public ActionResult<User> GetDoctorById(Guid id)
        {
            var doctor = _service.GetDoctorById(id);
            return doctor != null ? Ok(doctor) : NotFound();
        }

        [HttpPost]
        public IActionResult AddDoctor([FromBody] User doctor)
        {
            _service.AddDoctor(doctor);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDoctor(Guid id, [FromBody] User doctor)
        {
            doctor.Id = id;
            _service.UpdateDoctor(doctor);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(Guid id)
        {
            _service.DeleteDoctor(id);
            return Ok();
        }
    }
}
