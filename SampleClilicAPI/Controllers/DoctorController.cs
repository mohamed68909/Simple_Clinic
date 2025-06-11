using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleClilicAPIBusinessLayer.Interfaces;
using SampleClilicDataAccessLayer.DTOs;

namespace SampleClilicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            return Ok(doctors);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDTO>> GetDoctorById(Guid id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }
        [HttpPost]
        public async Task<ActionResult> CreateDoctor(DoctorDTO doctor)
        {
            if (doctor == null)
            {
                return BadRequest();
            }
            await _doctorService.AddDoctorAsync(doctor);
            return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.DoctorID }, doctor);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDoctor(DoctorDTO doctor)
        {
            if (doctor == null)
            {
                return BadRequest();
            }
            await _doctorService.UpdateDoctorAsync(doctor);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctor(Guid id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            await _doctorService.DeleteDoctorAsync(id);
            return NoContent();
        }
    }
}
