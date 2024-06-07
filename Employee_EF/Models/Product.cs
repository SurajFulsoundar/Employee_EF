using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_EF.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Product_Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Cid { get; set; }
        [NotMapped]
        public string? Category_Name { get; set;}
    }


}

