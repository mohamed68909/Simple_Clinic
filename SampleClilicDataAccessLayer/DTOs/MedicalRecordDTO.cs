using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClilicDataAccessLayer.DTOs
{
    public class MedicalRecordDTO
    {
        public Guid MedicalRecordID { get; set; }
        public Guid PatientID { get; set; }
        public Guid DoctorID { get; set; }
        public string VisitDescription { get; set; }
        public string Diagnosis { get; set; }
        public string PrescribedMedication { get; set; }
        public string AdditionalNotes { get; set; }
    }

}
