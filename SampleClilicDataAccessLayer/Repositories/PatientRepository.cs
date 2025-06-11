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
    public class PatientRepository : IPatientRepository
    {
        private readonly CilicDbContext _context;
        public PatientRepository(CilicDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }
        public async Task<Patient> GetPatientByIdAsync(Guid patientId)
        {
            return await _context.Patients.FindAsync(patientId);
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(Guid patientId)
        {
            return await _context.Appointments
                .Where(a => a.PatientId == patientId)
                .Include(a => a.Doctor)
                .ToListAsync();
        }
        public async Task< IEnumerable<MedicalRecord>> GetMedicalRecordsByPatientId(Guid patientId)
        {
            return await _context.MedicalRecords
                .Include(m => m.Doctor)
                .Where(m => m.PatientId == patientId)
                .ToListAsync();
        }
        public  async Task<IEnumerable<Patient>> SearchPatients(string name)
        {
            return  await _context.Patients
                .Where(p => p.Name.Contains(name))
                .ToListAsync();
        }



        public async Task AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await SaveAsync();
        }
        public async Task UpdateAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await SaveAsync();
        }
        public async Task DeleteAsync(Guid patientId)
        {
            var patient = await GetPatientByIdAsync(patientId);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await SaveAsync();
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
