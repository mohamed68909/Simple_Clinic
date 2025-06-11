using SampleClilicDataAccessLayer.DTOs;
using SampleClilicDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClilicAPIBusinessLayer.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsAsync();
        Task<AppointmentDTO> GetAppointmentByIdAsync(Guid appointmentId);
        Task<MedicalRecordDTO?> GetMedicalRecordByAppointment(Guid appointmentId);
        Task AddAsync(AppointmentDTO appointment);
        Task UpdateAsync(AppointmentDTO appointment);
        Task UpdateAppointmentStatus(Guid id, string status);
        Task DeleteAsync(Guid appointmentId);
  
    }
}
