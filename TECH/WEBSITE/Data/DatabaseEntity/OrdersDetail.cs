using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WEBSITE.Data.DatabaseEntity
{
    [Table("OrdersDetail")]
   public class OrdersDetail
   {
        [Key]
        public int Id { get; set; }
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int? OrdersId { get; set; }
        [ForeignKey("OrdersId")]
        public Orders Orders { get; set; }
        public int? Total { get; set; }
        public bool IsDeleted { get; set; }
   }
}
