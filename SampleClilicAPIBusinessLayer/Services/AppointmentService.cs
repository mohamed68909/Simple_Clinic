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
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsAsync()
        {
            var App = await _appointmentRepository.GetAllAppointmentsAsync();
            return App.Select(a => new AppointmentDTO
            {
                AppointmentID = a.AppointmentId,
                PatientID = a.PatientId,
                DoctorID = a.DoctorId,
                AppointmentDateTime = a.AppointmentDateTime,
                AppointmentStatus = a.AppointmentStatus,
                MedicalRecordID = a.MedicalRecordId,
                PaymentID = a.PaymentId

            }).ToList();

        }
        public async Task<AppointmentDTO> GetAppointmentByIdAsync(Guid appointmentId)
        {
            var appointment = await _appointmentRepository.GetAppointmentByIdAsync(appointmentId);
            if (appointment == null) return null;
            return new AppointmentDTO
            {
                AppointmentID = appointment.AppointmentId,
                PatientID = appointment.PatientId,
                DoctorID = appointment.DoctorId,
                AppointmentDateTime = appointment.AppointmentDateTime,
                AppointmentStatus = appointment.AppointmentStatus,
                MedicalRecordID = appointment.MedicalRecordId,
                PaymentID = appointment.PaymentId
            };
        }

        public async Task<MedicalRecordDTO?> GetMedicalRecordByAppointment(Guid appointmentId)

        {
            var record = await _appointmentRepository.GetMedicalRecordByAppointmentId(appointmentId);
            if (record == null) return null;

            return new MedicalRecordDTO
            {
                MedicalRecordID = record.MedicalRecordId,
                PatientID = record.PatientId,
                DoctorID = record.DoctorId,
                Diagnosis = record.Diagnosis,
                VisitDescription = record.VisitDescription,
                PrescribedMedication = record.PrescribedMedication,
                AdditionalNotes = record.AdditionalNotes
            };
        }

        public async Task AddAsync(AppointmentDTO appointmentDto)
        {
            var appointment = new SampleClilicDataAccessLayer.Models.Appointment
            {
                PatientId = appointmentDto.PatientID,
                DoctorId = appointmentDto.DoctorID,
                AppointmentDateTime = appointmentDto.AppointmentDateTime,
                AppointmentStatus = appointmentDto.AppointmentStatus,
                MedicalRecordId = appointmentDto.MedicalRecordID,
                PaymentId = appointmentDto.PaymentID
            };
            await _appointmentRepository.AddAsync(appointment);
            await _appointmentRepository.SaveAsync();
        }

     
        public async Task UpdateAsync(AppointmentDTO appointmentDto)
        {
            var Appointmen = await _appointmentRepository.GetAppointmentByIdAsync(appointmentDto.AppointmentID);
            if (Appointmen == null) return;


            Appointmen.AppointmentId = appointmentDto.AppointmentID;
            Appointmen.PatientId = appointmentDto.PatientID;
            Appointmen.DoctorId = appointmentDto.DoctorID;
            Appointmen.AppointmentDateTime = appointmentDto.AppointmentDateTime;
               Appointmen.AppointmentStatus = appointmentDto.AppointmentStatus;
            Appointmen.MedicalRecordId = appointmentDto.MedicalRecordID;
            Appointmen.PaymentId = appointmentDto.PaymentID;
               
            
            await _appointmentRepository.UpdateAsync(Appointmen);
            await _appointmentRepository.SaveAsync();

        }
        public async Task UpdateAppointmentStatus(Guid id, string status)
        {
           await _appointmentRepository.UpdateStatus(id, status);
        }

        public async Task DeleteAsync(Guid appointmentId)
        {
            await _appointmentRepository.DeleteAsync(appointmentId);
            await _appointmentRepository.SaveAsync();
        }
     
    }
}
