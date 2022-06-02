using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WEBSITE.SharedKernel;
namespace WEBSITE.Data.DatabaseEntity
{
    [Table("ImagesProduct")]
   public class ImagesProduct: DomainEntity<int>
    {
        //[Key]
        //public int Id { get; set; }
        public string Url { get; set; }
        public string Alt { get; set; }
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public bool IsDeleted { get; set; }
    }
}
