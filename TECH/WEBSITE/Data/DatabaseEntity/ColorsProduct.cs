using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WEBSITE.SharedKernel;

namespace WEBSITE.Data.DatabaseEntity
{
    [Table("ColorsProduct")]
    public class ColorsProduct : DomainEntity<int>
    {
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int? ColorId { get; set; }
        [ForeignKey("ColorId")]
        public Colors Colors { get; set; }
    }
}
