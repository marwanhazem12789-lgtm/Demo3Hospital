using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        [ForeignKey(nameof(Patient))]

        public int PatientId { get; set; }
        [Required , MaxLength(50)]
        public string Status { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        public Doctor Doctor { get; set; }

        public Patient Patient { get; set; }

        public MedicalRecord MedicalRecord { get; set; }
    }
}
