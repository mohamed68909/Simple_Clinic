using System;
using System.Collections.Generic;

namespace SampleClilicDataAccessLayer.Models;

public partial class Appointment
{
    public Guid AppointmentId { get; set; }

    public Guid PatientId { get; set; }

    public Guid DoctorId { get; set; }

    public DateTime? AppointmentDateTime { get; set; }

    public string AppointmentStatus { get; set; }

    public Guid MedicalRecordId { get; set; }

    public Guid? PaymentId { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual MedicalRecord? MedicalRecord { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual Payment? Payment { get; set; }
}
