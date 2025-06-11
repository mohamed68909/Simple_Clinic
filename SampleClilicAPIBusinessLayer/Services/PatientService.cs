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
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
    


        public PatientService(IPatientRepository patientRepository)
        {
            this._patientRepository = patientRepository;
        }

        public async Task<IEnumerable<PatientDTO>> GetAllPatientsAsync()
        {
            var Patient = await _patientRepository.GetAllPatientsAsync();
            return Patient.Select(p => new PatientDTO
            {
                PatientID = p.PatientId,
                Name = p.Name,
                Gender = p.Gender,
                DateOfBirth = p.DateOfBirth,
                PhoneNumber = p.PhoneNumber,
                Email = p.Email,
                Address = p.Address


            }).ToList();
        }

        public async Task<PatientDTO> GetPatientByIdAsync(Guid PatientID)
        {
            var Patient = await _patientRepository.GetPatientByIdAsync(PatientID);
            return new PatientDTO
            {
                PatientID = PatientID,
                Name = Patient.Name,
                Gender = Patient.Gender,
                DateOfBirth = Patient.DateOfBirth,
                PhoneNumber = Patient.PhoneNumber,
                Email = Patient.Email,
                Address = Patient.Address

            };
        }
        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByPatient(Guid patientId)
        {
            var appointments = await _patientRepository.GetAppointmentsByPatientId(patientId);

            return appointments.Select(a => new AppointmentDTO
            {
                AppointmentID = a.AppointmentId,
                AppointmentDateTime = a.AppointmentDateTime,
                PatientID = a.PatientId,
                DoctorID = a.DoctorId,
                AppointmentStatus = a.AppointmentStatus,
                MedicalRecordID = a.MedicalRecordId,
                PaymentID = a.PaymentId
            });
        }

        public async Task<IEnumerable<MedicalRecordDTO>> GetMedicalRecordsByPatient(Guid patientId)
        {
            var records = await _patientRepository.GetMedicalRecordsByPatientId(patientId);
            return records.Select(r => new MedicalRecordDTO
            {
                MedicalRecordID = r.MedicalRecordId,
                PatientID = r.PatientId,
                DoctorID = r.DoctorId,
                Diagnosis = r.Diagnosis,
                VisitDescription = r.VisitDescription,
                PrescribedMedication = r.PrescribedMedication,
                AdditionalNotes = r.AdditionalNotes

            }).ToList();
        }
        public async Task<IEnumerable<PatientDTO>> SearchPatients(string name)
        {
            var patients = await _patientRepository.SearchPatients(name);
            return patients.Select(p => new PatientDTO
            {
                PatientID = p.PatientId,

                Email = p.Email,
                Address = p.Address,
                PhoneNumber = p.PhoneNumber,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender,
                Name = p.Name


            }).ToList();
        }
        public async Task AddAsync(PatientDTO Patient)
        {
            var Patient1 = new Patient
            {
                PatientId = Patient.PatientID,
                Name = Patient.Name,
                Gender = Patient.Gender,

                DateOfBirth = Patient.DateOfBirth,
                PhoneNumber = Patient.PhoneNumber,

                Email = Patient.Email,
                Address = Patient.Address


            };

            await _patientRepository.AddAsync(Patient1);
            await _patientRepository.SaveAsync();
        }
        public async Task UpdateAsync(PatientDTO patient)
        {
            var updatedPatient = await _patientRepository.GetPatientByIdAsync(patient.PatientID);
            if (updatedPatient == null) return;

            updatedPatient.Email = updatedPatient.Email;
            updatedPatient.Address = updatedPatient.Address;
            updatedPatient.PhoneNumber = updatedPatient.PhoneNumber;
            updatedPatient.DateOfBirth = updatedPatient.DateOfBirth;
            updatedPatient.PatientId = updatedPatient.PatientId;
            updatedPatient.Name = updatedPatient.Name;
            updatedPatient.Gender = updatedPatient.Gender;
            await _patientRepository.UpdateAsync(updatedPatient);
            await _patientRepository.SaveAsync();


        }
    

        public async Task DeleteAsync(Guid PatientID)
        {

            await _patientRepository.DeleteAsync(PatientID);
            await _patientRepository.SaveAsync();

        }
    }
}
