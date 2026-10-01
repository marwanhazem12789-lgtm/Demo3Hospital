using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        [Required , MaxLength(150)]
        public string FullName {  get; set; }
        [Required, MaxLength(150) , EmailAddress]
        public string Email {  get; set; }
        [Required , MaxLength(20) , Phone]
        public string Phone {  get; set; }
        [Required , MaxLength(150)]
        public string Specialization {  get; set; }
        [Required , Range(1 ,int.MaxValue , ErrorMessage = "must be greater than 0")]
        public decimal Salary { get; set; }
        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        

        public ICollection<Appointment> appointments { get; set; } = new List<Appointment>();
        
    }
}
