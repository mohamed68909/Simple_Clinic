using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleClilicAPIBusinessLayer.Interfaces;
using SampleClilicDataAccessLayer.DTOs;

namespace SampleClilicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        readonly IMedicalRecordServics medicalRecordService;
        public MedicalRecordController(IMedicalRecordServics medicalRecordService)
        {
            this.medicalRecordService = medicalRecordService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalRecordDTO>>> GetAllMedicalRecords()
        {
            var medicalRecords = await medicalRecordService.GetAllMedicalRecordsAsync();
            return Ok(medicalRecords);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalRecordDTO>> GetMedicalRecordById(Guid id)
        {
            var medicalRecord = await medicalRecordService.GetMedicalRecordByIdAsync(id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            return Ok(medicalRecord);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMedicalRecord(MedicalRecordDTO medicalRecord)
        {
            if (medicalRecord == null)
            {
                return BadRequest();
            }
            await medicalRecordService.AddAsync(medicalRecord);
            return CreatedAtAction(nameof(GetMedicalRecordById), new { id = medicalRecord.MedicalRecordID }, medicalRecord);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMedicalRecord(MedicalRecordDTO medicalRecord)
        {
            if (medicalRecord == null)
            {
                return BadRequest();
            }
            await medicalRecordService.UpdateAsync(medicalRecord);
            return NoContent();
        }

    }
}
