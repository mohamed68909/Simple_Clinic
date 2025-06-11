using System;
using System.Collections.Generic;

namespace SampleClilicDataAccessLayer.Models;

public partial class Payment
{
    public Guid PaymentId { get; set; }

    public Guid PatientId { get; set; }

    public DateTime PaymentDate { get; set; }

    public string PaymentMethod { get; set; }

    public decimal AmountPaid { get; set; }

    public string AdditionalNotes { get; set; }

    public virtual Appointment? Appointment { get; set; }

    public virtual Patient? Patient { get; set; }
}
