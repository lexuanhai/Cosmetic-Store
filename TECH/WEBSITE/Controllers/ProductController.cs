using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBSITE.Controllers
{
    public class ProductController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductList()
        {
            return View();
        }
        public IActionResult ProductListCategory()
        {
            return View();
        }

        public IActionResult ProductDetail()
        {
            return View();
        }

    }
}
