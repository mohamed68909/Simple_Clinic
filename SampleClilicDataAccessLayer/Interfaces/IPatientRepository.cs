using SampleClilicDataAccessLayer.DTOs;
using SampleClilicDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClilicDataAccessLayer.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(Guid patientId);
       
        Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(Guid patientId);
        Task<IEnumerable<Patient>> SearchPatients(string name);

        Task<IEnumerable<MedicalRecord>> GetMedicalRecordsByPatientId(Guid patientId);
        Task AddAsync(Patient patient);
        Task UpdateAsync(Patient patient);
        Task DeleteAsync(Guid patientId);
        Task SaveAsync();
     
    }
}
