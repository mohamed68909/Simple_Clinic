
using SampleClilicDataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClilicAPIBusinessLayer.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDTO>> GetAllPatientsAsync();
        Task<PatientDTO> GetPatientByIdAsync(Guid patientId);
      
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByPatient(Guid patientId);
        Task<IEnumerable<MedicalRecordDTO>> GetMedicalRecordsByPatient(Guid patientId);
        Task<IEnumerable<PatientDTO>> SearchPatients(string name);
        Task AddAsync(PatientDTO patient);
        Task UpdateAsync(PatientDTO patient);
        Task DeleteAsync(Guid patientId);
    

    }
}
