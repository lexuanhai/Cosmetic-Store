using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBSITE.Areas.Admin.Models
{
    public class ImagesProductModelView
    {
        public string Url { get; set; }
        public string Alt { get; set; }
        public int? ProductId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
