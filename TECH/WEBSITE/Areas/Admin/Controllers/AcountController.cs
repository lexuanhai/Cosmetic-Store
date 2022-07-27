using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WEBSITE.Areas.Admin.Models;
using WEBSITE.Data.DatabaseEntity;
using WEBSITE.Service;

namespace WEBSITE.Areas.Admin.Controllers {
    [Area("Admin")]
    public class AcountController : Controller
    {
        private readonly IAppUserService _appUserService;
        public IHttpContextAccessor _httpContextAccessor;
        public AcountController(
            IAppUserService appUserService,
            IHttpContextAccessor httpContextAccessor)
        {
            _appUserService = appUserService;
            _httpContextAccessor = httpContextAccessor;
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
        [HttpPost]
        public JsonResult UserLogin(UserModelView UserModelView)
        {
            var result = _appUserService.UserLogin(UserModelView);
            var status = false;
            if (result != null)
            {
                status = true;
                _httpContextAccessor.HttpContext.Session.SetString("UserInfor", JsonConvert.SerializeObject(result));
            }
            return Json(new
            {
                success = status
            });
        }
        
    }
}
