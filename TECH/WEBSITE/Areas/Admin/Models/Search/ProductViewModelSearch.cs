using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBSITE.Areas.Admin.Models.Search
{
    public class ProductViewModelSearch : PageViewModel
    {
        public int? CategoryId { get; set; }
        public int? CategoryParentId { get; set; }
    }
}
