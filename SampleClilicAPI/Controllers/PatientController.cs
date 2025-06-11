using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleClilicAPIBusinessLayer.Interfaces;
using SampleClilicAPIBusinessLayer.Services;
using SampleClilicDataAccessLayer.DTOs;

namespace SampleClilicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService patientService;

        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
          
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> GetAllPatients()
        {
            var patients = await patientService.GetAllPatientsAsync();
            return Ok(patients);
        }
        [HttpGet]
        [Route("{id}")]
        public

            async Task<ActionResult<PatientDTO>> GetPatientById(Guid id)
        {
            var patient = await patientService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
        [HttpGet("{id}/appointments")]
        public IActionResult GetPatientAppointments(Guid id)
        {
            var appointments = patientService.GetAppointmentsByPatient(id);
            return Ok(appointments);
        }
        [HttpGet("{id}/medical-records")]
        public IActionResult GetPatientMedicalRecords(Guid id)
        {
            var records = patientService.GetMedicalRecordsByPatient(id);
            return Ok(records);
        }

        [HttpGet("search")]
        public IActionResult SearchPatients( string name)
        {
            var result = patientService.SearchPatients(name);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePatient(PatientDTO patient)
        {
            if (patient == null)
            {
                return BadRequest();
            }
            await patientService.AddAsync(patient);
            return CreatedAtAction(nameof(GetPatientById), new { id = patient.PatientID }, patient);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePatient(PatientDTO patient)
        {
            if (patient == null)
            {
                return BadRequest();
            }
            await patientService.UpdateAsync(patient);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePatient(Guid id)
        {
            var patient = await patientService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            await patientService.DeleteAsync(id);
            return NoContent();



        }
    }
}
