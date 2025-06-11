using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleClilicDataAccessLayer.DTOs;
using SampleClilicAPIBusinessLayer.Interfaces;
using SampleClilicAPIBusinessLayer.Services;

namespace SampleClilicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService prescriptionService;

        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            this.prescriptionService = prescriptionService ?? throw new ArgumentNullException(nameof(prescriptionService));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrescriptionDTO>>> GetAllPrescriptions()
        {
            var prescriptions = await prescriptionService.GetAllPrescriptionsAsync();
            return Ok(prescriptions);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PrescriptionDTO>> GetPrescriptionById(Guid id)
        {
            var prescription = await prescriptionService.GetPrescriptionByIdAsync(id);
            if (prescription == null)
            {
                return NotFound();
            }
            return Ok(prescription);
        }
        [HttpPost]
        public async Task<ActionResult> CreatePrescription(PrescriptionDTO prescription)
        {
            if (prescription == null)
            {
                return BadRequest();
            }
            await prescriptionService.AddAsync(prescription);
            return CreatedAtAction(nameof(GetPrescriptionById), new { id = prescription.PrescriptionID }, prescription);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePrescription(PrescriptionDTO prescription)
        {
            if (prescription == null)
            {
                return BadRequest();
            }
            await prescriptionService.UpdateAsync(prescription);
            return NoContent();
        }
       

    } }