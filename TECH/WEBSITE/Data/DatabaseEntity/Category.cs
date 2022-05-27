using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WEBSITE.SharedKernel;

namespace WEBSITE.Data.DatabaseEntity
{
    [Table("Category")]
    public class Category: DomainEntity<int>
    {
        //[Key]
        //public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public Category ParentCategory { get; set; }
        public bool IsDeleted { get; set; }
    }
}
