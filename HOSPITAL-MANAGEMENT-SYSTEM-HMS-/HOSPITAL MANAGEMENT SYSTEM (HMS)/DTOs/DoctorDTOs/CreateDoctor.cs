using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.DoctorDTOs
{
    public class CreateDoctor
    {
       
        [Required, MaxLength(150)]
        public string FullName { get; set; }
        [Required, MaxLength(150), EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(20), Phone]
        public string Phone { get; set; }
        [Required, MaxLength(150)]
        public string Specialization { get; set; }
        [Required, Range(1, int.MaxValue, ErrorMessage = "must be greater than 0")]
        public decimal Salary { get; set; }
        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

    }
}
