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
        private readonly UserManager<Staff> _userManager;
        private readonly SignInManager<Staff> _signInManager;
        public AcountController(UserManager<Staff> userManager, SignInManager<Staff> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
        public async Task<JsonResult> UserLogin(UserModelView userView)
        {     
            var result = await _signInManager.PasswordSignInAsync(
                    userView.Email,
                    userView.PassWord,
                    userView.RememberMe,
                    lockoutOnFailure: true
                );
            bool status = false;
            if (result != null && result.Succeeded)
            {
                if (_signInManager.IsSignedIn(User))
                {                   
                    status = true;
                }              
            }
            return Json(new
            {
                Status = status
            });          
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
                PhoneNumber = user.PhoneNumber,
                //EmailConfirmed = true,
                //PhoneNumberConfirmed = true,
            };
            var result = await _userManager.CreateAsync(_user, password);
            //Redirect("/home");
            //if (result.Succeeded)
            //{
            //    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            //    // callbackUrl = /Account/ConfirmEmail?userId=useridxx&code=codexxxx
            //    // Link trong email người dùng bấm vào, nó sẽ gọi Page: /Acount/ConfirmEmail để xác nhận
            //    var callbackUrl = Url.Page(
            //        "/Account/ConfirmEmail",
            //        pageHandler: null,
            //        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = "" },
            //        protocol: Request.Scheme);

            //    // Gửi email    
            //    await _emailSender.SendEmailAsync(_user.Email, "Xác nhận địa chỉ email",
            //        $"Hãy xác nhận địa chỉ email bằng cách <a href='{callbackUrl}'>Bấm vào đây</a>.");
            //    if (_userManager.Options.SignIn.RequireConfirmedEmail)
            //    {
            //        // Nếu cấu hình phải xác thực email mới được đăng nhập thì chuyển hướng đến trang
            //        // RegisterConfirmation - chỉ để hiện thông báo cho biết người dùng cần mở email xác nhận
            //        //return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
            //    }
            //    else
            //    {
            //        // Không cần xác thực - đăng nhập luôn
            //        await _signInManager.SignInAsync(user, isPersistent: false);

            //    }
            //}
            await _signInManager.SignInAsync(user, isPersistent: false);
            return Json(new
            {
                data = result.Succeeded
            });
        }
    }
}
