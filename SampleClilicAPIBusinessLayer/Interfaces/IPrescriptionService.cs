using SampleClilicDataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClilicAPIBusinessLayer.Interfaces
{
    public interface IPrescriptionService
    {
        Task<IEnumerable<PrescriptionDTO>> GetAllPrescriptionsAsync();
        Task<PrescriptionDTO> GetPrescriptionByIdAsync(Guid prescriptionId);
        Task AddAsync(PrescriptionDTO prescription);
        Task UpdateAsync(PrescriptionDTO prescription);
   
     
    }
}
