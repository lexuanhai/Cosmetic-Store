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
    //[Authorize]
    public class ColorsController : BaseController
    {
        private readonly IColorsService _colorsService;
        public ColorsController(IColorsService colorsService)
        {
            _colorsService = colorsService;
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
                model =  _colorsService.GetById(id);
            }
            return Json(new
            {
                Data = model
            });
        }

        [HttpPost]
        public JsonResult Add(ColorModelView colorModelView)
        {
            var result =  _colorsService.Add(colorModelView);
            _colorsService.Save();
            return Json(new
            {
                success = result
            });
        }
        [HttpPost]
        public JsonResult Update(ColorModelView colorModelView)
        {
            var result =  _colorsService.Update(colorModelView);
            _colorsService.Save();
            return Json(new
            {
                success = result
            });
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var result =  _colorsService.Deleted(id);
            _colorsService.Save();
            return Json(new
            {
                success = result
            });
        }
        [HttpGet]
        public JsonResult GetAllPaging(ColorViewModelSearch colorViewModelSearch)
        {
            var data = _colorsService.GetAllPaging(colorViewModelSearch);
            return Json(new { data = data });
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            var data = _colorsService.GetAll();
            return Json(new { Data = data });
        }

    }
}
