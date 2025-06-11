using System;
using System.Collections.Generic;

namespace SampleClilicDataAccessLayer.Models;

public  class Doctor
{
    public Guid DoctorId { get; set; }

    public string Name { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string Address { get; set; }

    public string Specialization { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
}
