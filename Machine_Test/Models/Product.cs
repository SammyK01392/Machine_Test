using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Machine_Test.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(200)]
        public string ProductName { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

      
        public virtual Category Category { get; set; }
    }
}
