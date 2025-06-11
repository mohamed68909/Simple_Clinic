using System;
using System.Collections.Generic;

namespace SampleClilicDataAccessLayer.Models;

public partial class Prescription
{
    public Guid PrescriptionId { get; set; }

    public Guid MedicalRecordId { get; set; }

    public string MedicationName { get; set; }

    public string Dosage { get; set; }

    public string Frequency { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? SpecialInstructions { get; set; }

    public virtual MedicalRecord? MedicalRecord { get; set; }
}
