using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.AppoinmentDTOs
{
    public class GetAppoinments
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Status { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        public string Doctorname { get; set; }

        public string Patientname { get; set; }

    }
}
