﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WEBSITE.Data.DatabaseEntity
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Decription { get; set; }
        public string SubDecription { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? Price { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? ReducedPrice { get; set; }
        public int? Total { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int? BrandsId { get; set; }
        [ForeignKey("BrandsId")]
        public Brands Brands { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
