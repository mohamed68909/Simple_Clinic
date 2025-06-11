using Microsoft.EntityFrameworkCore;
using SampleClilicDataAccessLayer.Data;
using SampleClilicDataAccessLayer.Interfaces;
using SampleClilicDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClilicDataAccessLayer.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        readonly CilicDbContext _context;
        public AppointmentRepository(CilicDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await _context.Appointments.ToListAsync();
        }
        public async Task<Appointment> GetAppointmentByIdAsync(Guid appointmentId)
        {
            return await _context.Appointments.FindAsync(appointmentId);
        }
        public async Task< MedicalRecord?> GetMedicalRecordByAppointmentId(Guid  appointmentId)
        {
            return await _context.MedicalRecords
                .FirstOrDefaultAsync(m => m.AppointmentId == appointmentId);
        }


        public async Task AddAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await SaveAsync();
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await SaveAsync();
        }
        public async Task UpdateStatus(Guid id, string status)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment != null)
            {
                appointment.AppointmentStatus = status;
                _context.SaveChanges();
            }
        }


        public async Task DeleteAsync(Guid appointmentId)
        {
            var appointment = await GetAppointmentByIdAsync(appointmentId);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await SaveAsync();
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
