using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.AppoinmentDTOs
{
    public class CreateAppoinment
    {
       
        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        [ForeignKey(nameof(Patient))]

        public int PatientId { get; set; }
        [Required, MaxLength(50)]
        public string Status { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
    }
}
