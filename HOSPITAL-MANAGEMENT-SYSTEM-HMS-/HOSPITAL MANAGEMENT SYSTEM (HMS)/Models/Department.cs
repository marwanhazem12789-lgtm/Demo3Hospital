using System.ComponentModel.DataAnnotations;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Location { get; set; }

        public ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();
    }
}
