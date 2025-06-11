using System;
using System.Collections.Generic;

namespace SampleClilicDataAccessLayer.Models;

public  class MedicalRecord
{
    public Guid MedicalRecordId { get; set; }

    public Guid PatientId { get; set; }

    public Guid DoctorId { get; set; }
    public Guid AppointmentId { get; set; }


    public string VisitDescription { get; set; }

    public string Diagnosis { get; set; }

    public string PrescribedMedication { get; set; }

    public string AdditionalNotes { get; set; }

    public virtual Appointment? Appointment { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual Prescription? Prescription { get; set; }
}
