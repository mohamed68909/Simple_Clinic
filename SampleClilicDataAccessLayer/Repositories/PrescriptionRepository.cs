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
    public class PrescriptionRepository : IPrescriptionRepository
    {
        readonly CilicDbContext _context;
        public PrescriptionRepository(CilicDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync()
        {
            return await _context.Prescriptions.ToListAsync();
        }
        public async Task<Prescription> GetPrescriptionByIdAsync(Guid prescriptionId)
        {
            return await _context.Prescriptions.FindAsync(prescriptionId);
        }
        public async Task AddAsync(Prescription prescription)
        {
            await _context.Prescriptions.AddAsync(prescription);
            await SaveAsync();
        }
        public async Task UpdateAsync(Prescription prescription)
        {
            _context.Prescriptions.Update(prescription);
            await SaveAsync();
        }
      
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
