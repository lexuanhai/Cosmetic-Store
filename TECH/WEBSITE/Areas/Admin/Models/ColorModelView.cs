using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBSITE.Areas.Admin.Models
{
    public class ColorModelView
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ProductId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
