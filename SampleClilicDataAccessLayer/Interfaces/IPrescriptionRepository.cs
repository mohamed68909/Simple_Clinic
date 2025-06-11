using SampleClilicDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClilicDataAccessLayer.Interfaces
{
    public interface IPrescriptionRepository
    {
        Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync();
        Task<Prescription> GetPrescriptionByIdAsync(Guid prescriptionId);
        Task AddAsync(Prescription prescription);
        Task UpdateAsync(Prescription prescription);
    
        Task SaveAsync();
    }
}
