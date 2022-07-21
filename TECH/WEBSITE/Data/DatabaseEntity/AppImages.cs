﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WEBSITE.SharedKernel;

namespace WEBSITE.Data.DatabaseEntity
{
    [Table("AppImages")]
    public class AppImages : DomainEntity<int>
    {
        public string Url { get; set; }
        public string Alt { get; set; }                
        public bool IsDeleted { get; set; }
    }
}
