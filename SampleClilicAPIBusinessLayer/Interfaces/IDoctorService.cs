using SampleClilicDataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClilicAPIBusinessLayer.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDTO>> GetAllDoctorsAsync();
        Task<DoctorDTO> GetDoctorByIdAsync(Guid doctorId);
        Task AddDoctorAsync(DoctorDTO doctor);
        Task UpdateDoctorAsync(DoctorDTO doctor);
        Task DeleteDoctorAsync(Guid doctorId);

    }
}
