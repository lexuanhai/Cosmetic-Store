using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WEBSITE.SharedKernel;
using static WEBSITE.General.General;

namespace WEBSITE.Data.DatabaseEntity
{
    [Table("Orders")]
   public class Orders: DomainEntity<int>
    {
        //[Key]
        //public int Id { get; set; }
        public int AppUserId { get; set; }
        [ForeignKey("StaffId")]
        public AppUser AppUser { get; set; }
        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customers Customers { get; set; }
        public DateTime CreateDate { get; set; }
        public OrdersStatus Status { get; set; }
        public bool IsDeleted { get; set; }

    }
}
