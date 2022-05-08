using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using WEBSITE.Data.DatabaseEntity;

namespace WEBSITE.Areas.Admin.Controllers { 
    public class AcountController : BaseController
    {
        private readonly UserManager<Staff> userManager;
        private readonly SignInManager<Staff> signInManager;
        public AcountController(UserManager<Staff> _userManager, SignInManager<Staff> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewLogin ()
        {
            return View();
        } 
        public IActionResult ViewRegistration()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> CreateRegistration(Staff user, string password)
        {
            //MailMessage test = new MailMessage(_from, _to, tieude,);
            var _user = new Staff
            {
                UserName = user.UserName,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
            var result = await userManager.CreateAsync(_user, password);

            return Json(new
            {
                data = result.Succeeded
            });
        }
    }
}
