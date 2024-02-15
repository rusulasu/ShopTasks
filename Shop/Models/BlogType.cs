﻿using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class BlogType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
