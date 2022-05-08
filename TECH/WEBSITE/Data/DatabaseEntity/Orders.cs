﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static WEBSITE.General.General;

namespace WEBSITE.Data.DatabaseEntity
{
    [Table("Orders")]
   public class Orders
    {
        [Key]
        public int Id { get; set; }
        public string StaffId { get; set; }
        [ForeignKey("StaffId")]
        public Staff Staff { get; set; }
        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customers Customers { get; set; }
        public DateTime CreateDate { get; set; }
        public OrdersStatus Status { get; set; }
        public bool IsDeleted { get; set; }

    }
}
