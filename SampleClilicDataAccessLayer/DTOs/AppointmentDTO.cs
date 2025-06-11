using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClilicDataAccessLayer.DTOs
{
    public class AppointmentDTO
    {
        public Guid AppointmentID { get; set; }
        public Guid PatientID { get; set; }
        public Guid DoctorID { get; set; }
        public DateTime? AppointmentDateTime { get; set; }
        public string AppointmentStatus { get; set; }
        public Guid MedicalRecordID { get; set; }
        public Guid? PaymentID { get; set; }
    }

}
