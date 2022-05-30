using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBSITE.Areas.Admin.Models.Search;

namespace WEBSITE.Areas.Admin.Models
{
    public class ImagesProductViewModelSearch:PageViewModel
    {
        public string Url { get; set; }
        public string Alt { get; set; }
        public int? ProductId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
