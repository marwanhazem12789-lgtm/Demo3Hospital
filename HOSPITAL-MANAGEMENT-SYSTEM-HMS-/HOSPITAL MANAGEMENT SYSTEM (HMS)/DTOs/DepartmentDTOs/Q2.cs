using System.ComponentModel.DataAnnotations;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.DepartmentDTOs
{
    public class Q2
    {
       
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Location { get; set; }

        public int counntt { get; set; }
    }
}
