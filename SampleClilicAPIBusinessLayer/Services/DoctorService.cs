using SampleClilicAPIBusinessLayer.Interfaces;
using SampleClilicDataAccessLayer.DTOs;
using SampleClilicDataAccessLayer.Interfaces;
using SampleClilicDataAccessLayer.Models;
using SampleClilicDataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClilicAPIBusinessLayer.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public async Task<IEnumerable<DoctorDTO>> GetAllDoctorsAsync()
        {
            var Doctor = await _doctorRepository.GetAllDoctorsAsync();
            return Doctor.Select(d => new DoctorDTO
            {
                DoctorID = d.DoctorId,
                Name = d.Name,
                Specialization = d.Specialization,
                DateOfBirth = d.DateOfBirth,
                Gender = d.Gender,
                PhoneNumber = d.PhoneNumber,
                Email = d.Email,
                Address = d.Address,

            }).ToList();
        }

        public async Task<DoctorDTO> GetDoctorByIdAsync(Guid doctorId)
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsync(doctorId);
            if (doctor == null) return null;

            return new DoctorDTO
            {
                DoctorID = doctor.DoctorId,
                Name = doctor.Name,
                Specialization = doctor.Specialization,
                DateOfBirth = doctor.DateOfBirth,
                Gender = doctor.Gender,
                PhoneNumber = doctor.PhoneNumber,
                Address = doctor.Address,
                Email = doctor.Email
            };
        }

        public async Task AddDoctorAsync(DoctorDTO doctor)
        {
            var doctor1 = new Doctor
            {
                DoctorId = doctor.DoctorID,
                Name = doctor.Name,
                Specialization = doctor.Specialization,
                Gender = doctor.Gender,
                DateOfBirth = doctor.DateOfBirth,
                PhoneNumber = doctor.PhoneNumber,
                Email = doctor.Email,
                Address = doctor.Address


            };
            await _doctorRepository.AddAsync(doctor1);
            await _doctorRepository.SaveAsync();
        }



        public async Task UpdateDoctorAsync(DoctorDTO doctor)
        {
            var doctorToUpdate = await _doctorRepository.GetDoctorByIdAsync(doctor.DoctorID);
            if (doctorToUpdate == null) return;
            doctorToUpdate.Name = doctor.Name;
            doctorToUpdate.Specialization = doctor.Specialization;
            doctorToUpdate.Email = doctor.Email;
            doctorToUpdate.PhoneNumber = doctor.PhoneNumber;
            doctorToUpdate.DateOfBirth = doctor.DateOfBirth;

            await _doctorRepository.UpdateAsync(doctorToUpdate);
            await _doctorRepository.SaveAsync();

        }

        public async Task DeleteDoctorAsync(Guid doctorId)
        {
            await _doctorRepository.DeleteAsync(doctorId);
            await _doctorRepository.SaveAsync();
        }






    }
}
    

