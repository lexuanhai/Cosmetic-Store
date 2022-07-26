using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBSITE.Areas.Admin.Models;
using WEBSITE.Areas.Admin.Models.Search;
using WEBSITE.Data.DatabaseEntity;
using WEBSITE.Service;

namespace WEBSITE.Areas.Admin.Controllers
{    
    public class RoleController : BaseController
    {
        private readonly IAppRoleService _appRoleService;
        public RoleController(IAppRoleService appRoleService)
        {
            _appRoleService = appRoleService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            var model = _appRoleService.GetAll();
            return Json(new
            {
                Data = model
            });
        }
        [HttpGet]
        public JsonResult GetById(int id)
        {
            var model = new RoleModelView();
            if (id > 0)
            {
                model = _appRoleService.GetById(id);
            }
            return Json(new
            {
                Data = model
            });
        }
        [HttpPost]
        public JsonResult Add(RoleModelView roleModelView)
        {
            var result = _appRoleService.Add(roleModelView);
            _appRoleService.Save();
            return Json(new
            {
                success = result
            });
        }
        [HttpPost]
        public JsonResult Update(RoleModelView roleModelView)
        {
            var result = _appRoleService.Update(roleModelView);
            _appRoleService.Save();
            return Json(new
            {
                success = result
            });
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var result = _appRoleService.Deleted(id);
            _appRoleService.Save();
            return Json(new
            {
                success = result
            });
        }
        [HttpGet]
        public JsonResult GetAllPaging(RoleViewModelSearch roleViewModelSearch)
        {
            var data = _appRoleService.GetAllPaging(roleViewModelSearch);
            return Json(new { data = data });
        }

    }
}
