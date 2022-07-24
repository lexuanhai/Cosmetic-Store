using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBSITE.Extensions;

namespace WEBSITE.Areas.Admin.Controllers
{
    //[Authorize]
    public class HomeController : BaseController
    {
        //public IHttpContextAccessor _httpContextAccessor;
        //public HomeController(IHttpContextAccessor httpContextAccessor)
        //{
        //    _httpContextAccessor = httpContextAccessor;
        //    base.Index1();
        //}
        public IActionResult Index()
        {
            //var email = User.GetSpecificClaim("Email");
            
            return View();
        }
    }
}
