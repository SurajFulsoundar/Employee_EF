using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_EF.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Did { get; set; }
        public string? DName { get; set; }
    }
}
