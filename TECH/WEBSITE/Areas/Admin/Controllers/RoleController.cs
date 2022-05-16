using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBSITE.Data.DatabaseEntity;

namespace WEBSITE.Areas.Admin.Controllers
{
    [Authorize]
    public class RoleController : BaseController
    {
        private readonly RoleManager<Roles> _roleManager;
        public RoleController(RoleManager<Roles> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Add(Roles roles)
        {

            return Json(new
            {
                Status = true
            });
        }
        [HttpGet]
        public  IActionResult Edit(string roleId)
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Edit(Roles roles)
        {
            return Json(new
            {
                Status = true
            });
        }

    }
}
