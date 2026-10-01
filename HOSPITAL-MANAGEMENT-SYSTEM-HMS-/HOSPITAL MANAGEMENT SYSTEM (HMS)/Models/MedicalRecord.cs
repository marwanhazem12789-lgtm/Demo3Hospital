using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models
{
    public class MedicalRecord
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(1000)]
        public string Notes {  get; set; }
        [Required,MaxLength(1000)]

        public string Prescription {  get; set; }
        [Required,MaxLength(500)]
        public string Diagnosis {  get; set; }
        [ForeignKey(nameof(Appointment))]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
