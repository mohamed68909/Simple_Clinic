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
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        readonly CilicDbContext _context;
        public MedicalRecordRepository(CilicDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MedicalRecord>> GetAllMedicalRecordsAsync()
        {
            return await _context.MedicalRecords.ToListAsync();
        }
        public async Task<MedicalRecord> GetMedicalRecordByIdAsync(Guid medicalRecordId)
        {
            return await _context.MedicalRecords.FindAsync(medicalRecordId);
        }
        public async Task AddAsync(MedicalRecord medicalRecord)
        {
            await _context.MedicalRecords.AddAsync(medicalRecord);
            await SaveAsync();
        }
        public async Task UpdateAsync(MedicalRecord medicalRecord)
        {
            _context.MedicalRecords.Update(medicalRecord);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
