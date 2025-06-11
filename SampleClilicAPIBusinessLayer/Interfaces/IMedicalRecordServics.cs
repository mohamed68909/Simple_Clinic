using SampleClilicDataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClilicAPIBusinessLayer.Interfaces
{
    public interface IMedicalRecordServics
    {
        Task<IEnumerable<MedicalRecordDTO>> GetAllMedicalRecordsAsync();
        Task<MedicalRecordDTO> GetMedicalRecordByIdAsync(Guid medicalRecordId);
        Task AddAsync(MedicalRecordDTO medicalRecord);
        Task UpdateAsync(MedicalRecordDTO medicalRecord);
       
      
    }
}
