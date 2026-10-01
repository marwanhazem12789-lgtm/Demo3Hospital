using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.MedicalDTOs
{
    public class CreateMedicalRecord
    {
       
        [MaxLength(1000)]
        public string Notes { get; set; }
        [Required, MaxLength(1000)]

        public string Prescription { get; set; }
        [Required, MaxLength(500)]
        public string Diagnosis { get; set; }
        [ForeignKey(nameof(Appointment))]
        public int AppointmentId { get; set; }
    }
}
