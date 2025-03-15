using HealthcareAppointment.Business;
using HealthcareAppointment.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAppointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentService _service;

        public AppointmentsController()
        {
            _service = new AppointmentService();
        }

        [HttpGet]
        public ActionResult<List<Appointment>> GetAppointments() => _service.GetAppointments();

        [HttpGet("{id}")]
        public ActionResult<Appointment> GetAppointmentById(Guid id)
        {
            var appointment = _service.GetAppointmentById(id);
            return appointment != null ? Ok(appointment) : NotFound();
        }

        [HttpPost]
        public IActionResult AddAppointment([FromBody] Appointment appointment)
        {
            _service.AddAppointment(appointment);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAppointment(Guid id, [FromBody] Appointment appointment)
        {
            appointment.Id = id;
            _service.UpdateAppointment(appointment);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(Guid id)
        {
            _service.DeleteAppointment(id);
            return Ok();
        }

        [HttpPatch("{id}/cancel")]
        public IActionResult CancelAppointment(Guid id)
        {
            _service.CancelAppointment(id);
            return Ok();
        }

        [HttpGet("doctor/{doctorId}")]
        public ActionResult<List<Appointment>> GetAppointmentsForDoctor(Guid doctorId, int pageNumber = 1, int pageSize = 10)
        {
            return _service.GetAppointmentsForDoctor(doctorId, pageNumber, pageSize);
        }
    }
}
