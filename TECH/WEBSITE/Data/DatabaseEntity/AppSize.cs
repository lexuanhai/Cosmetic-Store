using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WEBSITE.SharedKernel;

namespace WEBSITE.Data.DatabaseEntity
{
    [Table("AppSize")]
    public class AppSize: DomainEntity<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
