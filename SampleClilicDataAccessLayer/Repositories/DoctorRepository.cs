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
    public class DoctorRepository : IDoctorRepository
    {
        readonly CilicDbContext _context;
        public DoctorRepository(CilicDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync();
        }
        public async Task<Doctor> GetDoctorByIdAsync(Guid doctorId)
        {
            return await _context.Doctors.FindAsync(doctorId);
        }
        public async Task AddAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await SaveAsync();
        }
        public async Task UpdateAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await SaveAsync();
        }
        public async Task DeleteAsync(Guid doctorId)
        {
            var doctor = await GetDoctorByIdAsync(doctorId);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await SaveAsync();
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
