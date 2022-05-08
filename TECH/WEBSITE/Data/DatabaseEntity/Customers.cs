using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WEBSITE.Data.DatabaseEntity
{
    [Table("Customers")]
   public class Customers
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName ="varchar(12)")]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }        
        public bool IsDeleted { get; set; }
    }
}
