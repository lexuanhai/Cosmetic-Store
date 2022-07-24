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
    public class AppSizeController : BaseController
    {
        private readonly IAppSizeService _appSizeService;
        public AppSizeController(IAppSizeService colorsService)
        {
            _appSizeService = colorsService;
        }
         public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public  JsonResult GetById(int id)
        {
            var model = new ColorModelView();
            if (id > 0)
            {
                model =  _appSizeService.GetById(id);
            }
            return Json(new
            {
                Data = model
            });
        }

        [HttpPost]
        public JsonResult Add(ColorModelView colorModelView)
        {
            var result =  _appSizeService.Add(colorModelView);
            _appSizeService.Save();
            return Json(new
            {
                success = result
            });
        }
        [HttpPost]
        public JsonResult Update(ColorModelView colorModelView)
        {
            var result =  _appSizeService.Update(colorModelView);
            _appSizeService.Save();
            return Json(new
            {
                success = result
            });
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var result =  _appSizeService.Deleted(id);
            _appSizeService.Save();
            return Json(new
            {
                success = result
            });
        }
        [HttpGet]
        public JsonResult GetAllPaging(ColorViewModelSearch colorViewModelSearch)
        {
            var data = _appSizeService.GetAllPaging(colorViewModelSearch);
            return Json(new { data = data });
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            var data = _appSizeService.GetAll();
            return Json(new { Data = data });
        }

    }
}
