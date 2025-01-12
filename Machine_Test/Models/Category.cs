﻿using System.ComponentModel.DataAnnotations;

namespace Machine_Test.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }

       
        public virtual ICollection<Product> Products { get; set; }
    }
}
