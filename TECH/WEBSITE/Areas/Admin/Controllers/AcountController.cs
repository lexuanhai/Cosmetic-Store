using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WEBSITE.Areas.Admin.Models;
using WEBSITE.Data.DatabaseEntity;

namespace WEBSITE.Areas.Admin.Controllers {
    [Area("Admin")]
    public class AcountController : Controller
    {
       
        public AcountController( )
        {
           
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ViewLogin ()
        {
            return View();
        }

        public IActionResult ViewRegistration()
        {
            return View();
        }
    }
}
