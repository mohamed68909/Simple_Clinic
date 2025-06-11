using SampleClilicDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClilicDataAccessLayer.Interfaces
{
    public interface IAppointmentRepository
    {
       Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment> GetAppointmentByIdAsync(Guid appointmentId);
        Task<MedicalRecord?> GetMedicalRecordByAppointmentId(Guid appointmentId);
        Task AddAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task UpdateStatus(Guid id, string status);
        Task DeleteAsync(Guid appointmentId);
        Task SaveAsync();
    }
}
