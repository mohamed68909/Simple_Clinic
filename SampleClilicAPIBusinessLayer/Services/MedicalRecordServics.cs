using SampleClilicAPIBusinessLayer.Interfaces;
using SampleClilicDataAccessLayer.DTOs;
using SampleClilicDataAccessLayer.Interfaces;
using SampleClilicDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClilicAPIBusinessLayer.Services
{
    public class MedicalRecordServics : IMedicalRecordServics
    {
        private readonly IMedicalRecordRepository _MedicalRecordRepository;

        public MedicalRecordServics(IMedicalRecordRepository medicalRecordRepository)
        {
            this._MedicalRecordRepository = medicalRecordRepository;
        }

        public async Task<IEnumerable<MedicalRecordDTO>> GetAllMedicalRecordsAsync()
        {
            var MedicalRecord= await _MedicalRecordRepository.GetAllMedicalRecordsAsync();
            return
                MedicalRecord.Select(M => new MedicalRecordDTO
                {
                    MedicalRecordID= M.MedicalRecordId,
                    PatientID = M.PatientId,
                    Diagnosis = M.Diagnosis,
                  VisitDescription = M.VisitDescription,
                    PrescribedMedication = M.PrescribedMedication,
                    AdditionalNotes = M.AdditionalNotes,
                   DoctorID = M.DoctorId,

                }).ToList();

        }

       public async Task<MedicalRecordDTO>  GetMedicalRecordByIdAsync(Guid medicalRecordId)
        {
            var medicalRecord = await _MedicalRecordRepository.GetMedicalRecordByIdAsync(medicalRecordId);
            return new MedicalRecordDTO
            {
                MedicalRecordID = medicalRecord.MedicalRecordId,
                PatientID = medicalRecord.PatientId,
                DoctorID = medicalRecord.DoctorId,
                VisitDescription = medicalRecord.VisitDescription,
                Diagnosis = medicalRecord.Diagnosis,
                PrescribedMedication = medicalRecord.PrescribedMedication,
                AdditionalNotes = medicalRecord.AdditionalNotes
            };
        }
        public async Task AddAsync(MedicalRecordDTO medicalRecord)
        {
           var newMedicalRecor = new MedicalRecord
           {
               PatientId = medicalRecord.PatientID,
               DoctorId = medicalRecord.DoctorID,
               VisitDescription = medicalRecord.VisitDescription,
               Diagnosis = medicalRecord.Diagnosis,
               PrescribedMedication = medicalRecord.PrescribedMedication,
               AdditionalNotes = medicalRecord.AdditionalNotes
               ,
               MedicalRecordId = medicalRecord.MedicalRecordID,
               
           };

            await _MedicalRecordRepository.AddAsync(newMedicalRecor);
            await _MedicalRecordRepository.SaveAsync();
        }
        public async Task UpdateAsync(MedicalRecordDTO medicalRecord)
        {
            var updatedMedicalRecord = await _MedicalRecordRepository.GetMedicalRecordByIdAsync(medicalRecord.MedicalRecordID);




            updatedMedicalRecord. MedicalRecordId = medicalRecord.MedicalRecordID;
            updatedMedicalRecord. PatientId = medicalRecord.PatientID;
            updatedMedicalRecord. DoctorId = medicalRecord.DoctorID;
            updatedMedicalRecord.VisitDescription = medicalRecord.VisitDescription;
            updatedMedicalRecord. Diagnosis = medicalRecord.Diagnosis;
            updatedMedicalRecord. PrescribedMedication = medicalRecord.PrescribedMedication;
            updatedMedicalRecord. AdditionalNotes = medicalRecord.AdditionalNotes;
            await _MedicalRecordRepository.UpdateAsync(updatedMedicalRecord);
            await _MedicalRecordRepository.SaveAsync();

        }


 

        }
}
