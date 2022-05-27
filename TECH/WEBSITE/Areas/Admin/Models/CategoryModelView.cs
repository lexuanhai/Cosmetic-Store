using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBSITE.Areas.Admin.Models
{
    public class CategoryModelView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ParentName { get; set; }
        public int? ParentId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
