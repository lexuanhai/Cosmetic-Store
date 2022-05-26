using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBSITE.Areas.Admin.Models;
using WEBSITE.Data.DatabaseEntity;
using WEBSITE.Service;

namespace WEBSITE.Areas.Admin.Controllers
{
    //[Authorize]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            var model = _roleService.GetAll();
            bool isData = false;
            if (model != null && model.Count > 0)
                isData = true;
            return Json(new
            {
                IsData = isData,
                Data = model
            });
        }
        [HttpGet]
        public async Task<JsonResult> GetById(string id)
        {
            var model = new RoleModelView();
            if (!string.IsNullOrEmpty(id))
            {
                model = await _roleService.GetById(id);
            }
            return Json(new
            {
                Data = model
            });
        }
        [HttpPost]
        public async Task<JsonResult> Add(RoleModelView roleModelView)
        {
            var result = await _roleService.Add(roleModelView);
            return Json(new
            {
                success = result
            });
        }
        [HttpPost]
        public async Task<JsonResult> Update(RoleModelView roleModelView)
        {
            var result = await _roleService.Update(roleModelView);
            return Json(new
            {
                success = result
            });
        }
        [HttpPost]
        public async Task<JsonResult> Delete(string roleId)
        {
            var result = await _roleService.Deleted(roleId);
            return Json(new
            {
                success = result
            });
        }

    }
}
