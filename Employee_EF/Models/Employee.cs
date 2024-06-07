using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_EF.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public int Did { get; set;}

        [NotMapped]
        public string? DName { get; set;}

    }
}
