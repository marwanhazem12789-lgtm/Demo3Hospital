using System.ComponentModel.DataAnnotations;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.PatientDtos
{
    public class GetPatient
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string FullName { get; set; }
        [Required, MaxLength(20), Phone]

        public string PhoneNumber { get; set; }
        [Required, MaxLength(20)]
        public string Gender { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime BirthOfDate { get; set; }
    }
}
