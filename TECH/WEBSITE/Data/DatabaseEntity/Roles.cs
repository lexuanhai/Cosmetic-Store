using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WEBSITE.Data.DatabaseEntity
{
    public class Roles:IdentityRole
    {
        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; }

    }
}
