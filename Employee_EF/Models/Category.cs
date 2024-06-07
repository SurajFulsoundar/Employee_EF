using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_EF.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Cid { get; set; }
        public string? Category_Name { get; set; }

    }
}
