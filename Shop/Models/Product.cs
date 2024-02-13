﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public float Price { get; set; }

        public int Quantity { get; set; }

        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Boolean EnableSize { get; set; }
        public Company company { get; set; }



    }
}
