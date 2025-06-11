using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleClilicAPIBusinessLayer.Interfaces;
using SampleClilicDataAccessLayer.DTOs;

namespace SampleClilicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
       private readonly IAppointmentService _appointmentService;


        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDTO>>> GetAllAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            return Ok(appointments);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDTO>> GetAppointmentById(Guid id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }
        [HttpPost]
        public async Task<ActionResult> CreateAppointment(AppointmentDTO appointment)
        {
            if (appointment == null)
            {
                return BadRequest();
            }
            await _appointmentService.AddAsync(appointment);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.AppointmentID }, appointment);
        }
        [HttpPut("{id}/status")]
        public IActionResult UpdateAppointmentStatus(Guid id,  string status)
        {
            _appointmentService.UpdateAppointmentStatus(id, status);
            return NoContent();
        }
        [HttpGet("{id}/medical-record")]
        public IActionResult GetAppointmentMedicalRecord(Guid id)
        {
            var record = _appointmentService.GetMedicalRecordByAppointment(id);
            if (record == null) return NotFound();
            return Ok(record);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAppointment(AppointmentDTO appointment)
        {
            await _appointmentService.UpdateAsync(appointment);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(Guid id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            await _appointmentService.DeleteAsync(id);
            return NoContent();
        }

    }
}
