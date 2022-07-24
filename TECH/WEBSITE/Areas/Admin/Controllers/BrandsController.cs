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
    public class BrandsController : BaseController
    {
        private readonly IBrandsService _brandsService;
        public BrandsController(IBrandsService brandsService)
        {
            _brandsService = brandsService;
        }
         public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public  JsonResult GetById(int id)
        {
            var model = new BrandsModelView();
            if (id > 0)
            {
                model =  _brandsService.GetById(id);
            }
            return Json(new
            {
                Data = model
            });
        }

        [HttpPost]
        public JsonResult Add(BrandsModelView BrandsModelView)
        {
            var result =  _brandsService.Add(BrandsModelView);
            _brandsService.Save();
            return Json(new
            {
                success = result
            });
        }
        [HttpPost]
        public JsonResult Update(BrandsModelView BrandsModelView)
        {
            var result =  _brandsService.Update(BrandsModelView);
            _brandsService.Save();
            return Json(new
            {
                success = result
            });
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var result =  _brandsService.Deleted(id);
            _brandsService.Save();
            return Json(new
            {
                success = result
            });
        }
        [HttpGet]
        public JsonResult GetAllPaging(ColorViewModelSearch colorViewModelSearch)
        {
            var data = _brandsService.GetAllPaging(colorViewModelSearch);
            return Json(new { data = data });
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            var data = _brandsService.GetAll();
            return Json(new { Data = data });
        }

    }
}
