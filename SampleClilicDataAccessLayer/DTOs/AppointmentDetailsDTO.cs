using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClilicDataAccessLayer.DTOs
{
    public class AppointmentDetailsDTO
    {
        public Guid AppointmentID { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string AppointmentStatus { get; set; }

        public PatientDTO Patient { get; set; }
        public DoctorDTO Doctor { get; set; }
    }

}
