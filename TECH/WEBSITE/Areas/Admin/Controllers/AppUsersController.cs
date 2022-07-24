using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBSITE.Areas.Admin.Models;
using WEBSITE.Areas.Admin.Models.Search;
using WEBSITE.Service;

namespace WEBSITE.Areas.Admin.Controllers
{
    public class AppUsersController : BaseController
    {
        private readonly IAppUserService _appUserService;
        public AppUsersController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetById(int id)
        {
            var model = new UserModelView();
            if (id > 0)
            {
                model = _appUserService.GetById(id);
            }
            return Json(new
            {
                Data = model
            });
        }

        [HttpGet]
        public IActionResult AddOrUpdate()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Add(UserModelView UserModelView)
        {
            var result = _appUserService.Add(UserModelView);
            _appUserService.Save();
            return Json(new
            {
                success = result
            });
        }
        [HttpPost]
        public JsonResult Update(UserModelView UserModelView)
        {
            var result = _appUserService.Update(UserModelView);
            _appUserService.Save();
            return Json(new
            {
                success = result
            });
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var result = _appUserService.Deleted(id);
            _appUserService.Save();
            return Json(new
            {
                success = result
            });
        }
        [HttpGet]
        public JsonResult GetAllPaging(UserModelViewSearch colorViewModelSearch)
        {
            var data = _appUserService.GetAllPaging(colorViewModelSearch);
            return Json(new { data = data });
        }
        //[HttpGet]
        //public JsonResult GetAll()
        //{
        //    var data = _appUserService.GetAll();
        //    return Json(new { Data = data });
        //}
    }
}
