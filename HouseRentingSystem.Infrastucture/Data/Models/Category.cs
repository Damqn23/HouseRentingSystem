﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Infrastucture.Constants.DataConstants;

namespace HouseRentingSystem.Infrastucture.Data.Models
{
    [Comment("House category")]
    public class Category
    {
        [Key]
        [Comment("Category Identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameLength)]
        [Comment("Category Name")]
        public string Name { get; set; } = string.Empty;

        public List<House> Houses { get; set; } = new List<House>();

    }
}
