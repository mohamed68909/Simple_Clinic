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
    public class PrescriptionService : IPrescriptionService
    {
        readonly IPrescriptionRepository _prescriptionRepository;
        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository ?? throw new ArgumentNullException(nameof(prescriptionRepository));
        }
        public async Task<IEnumerable<PrescriptionDTO>> GetAllPrescriptionsAsync()
        {
            var prescription= await _prescriptionRepository.GetAllPrescriptionsAsync();
            return prescription.Select(p => new PrescriptionDTO
            {
                PrescriptionID = p.PrescriptionId,
                MedicalRecordID = p.MedicalRecordId,
                MedicationName = p.MedicationName,
                Dosage = p.Dosage,
                Frequency = p.Frequency,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                SpecialInstructions = p.SpecialInstructions
            }).ToList();

        }
        public async Task<PrescriptionDTO> GetPrescriptionByIdAsync(Guid prescriptionId)
        {
            var prescription = await _prescriptionRepository.GetPrescriptionByIdAsync(prescriptionId);
            if (prescription == null) return null;
            return new PrescriptionDTO
            {
                PrescriptionID = prescription.PrescriptionId,
                MedicalRecordID = prescription.MedicalRecordId,
                MedicationName = prescription.MedicationName,
                Dosage = prescription.Dosage,
                Frequency = prescription.Frequency,
                StartDate = prescription.StartDate,
                EndDate = prescription.EndDate,
                SpecialInstructions = prescription.SpecialInstructions
            };
        }




        public async Task AddAsync(PrescriptionDTO prescription)
        {

            var prescription1 = new Prescription
            {


                MedicationName = prescription.MedicationName,
                Dosage = prescription.Dosage,
                Frequency = prescription.Frequency,
                StartDate = prescription.StartDate,
                EndDate = prescription.EndDate,
                SpecialInstructions = prescription.SpecialInstructions


            };

            await _prescriptionRepository.AddAsync(prescription1);
            await _prescriptionRepository.SaveAsync();


        }
        public async Task UpdateAsync(PrescriptionDTO prescription)
        {
            var existingPrescription = await _prescriptionRepository.GetPrescriptionByIdAsync(prescription.PrescriptionID);
            if (existingPrescription == null) return;
            existingPrescription.MedicalRecordId = prescription.MedicalRecordID;
            existingPrescription.MedicationName = prescription.MedicationName;
            existingPrescription.Dosage = prescription.Dosage;
            existingPrescription.Frequency = prescription.Frequency;
            existingPrescription.StartDate = prescription.StartDate;
            existingPrescription.EndDate = prescription.EndDate;
            existingPrescription.SpecialInstructions = prescription.SpecialInstructions;
            await _prescriptionRepository.UpdateAsync(existingPrescription);
            await _prescriptionRepository.SaveAsync();
        }
     












    }

}
