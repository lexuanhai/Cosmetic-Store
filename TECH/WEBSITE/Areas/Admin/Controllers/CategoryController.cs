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
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            var model = _categoryService.GetAll();
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
        public  JsonResult GetById(int id)
        {
            var model = new CategoryModelView();
            if (id > 0)
            {
                model =  _categoryService.GetById(id);
            }
            return Json(new
            {
                Data = model
            });
        }

        [HttpGet]
        public JsonResult GetAllParent()
        {
            var model = _categoryService.GetAllParent();
            return Json(new
            {
                Data = model
            });
        }

        [HttpPost]
        public JsonResult Add(CategoryModelView CategoryModelView)
        {
            var result =  _categoryService.Add(CategoryModelView);
            _categoryService.Save();
            return Json(new
            {
                success = result
            });
        }
        [HttpPost]
        public JsonResult Update(CategoryModelView categoryModelView)
        {
            var result =  _categoryService.Update(categoryModelView);
            _categoryService.Save();
            return Json(new
            {
                success = result
            });
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var result =  _categoryService.Deleted(id);
            _categoryService.Save();
            return Json(new
            {
                success = result
            });
        }
        [HttpGet]
        public JsonResult GetAllPaging(CategoryViewModelSearch categoryViewModelSearch)
        {
            var data = _categoryService.GetAllPaging(categoryViewModelSearch);
            return Json(new { data = data });
        }

        [HttpGet]
        public JsonResult GetCategoryByParentId(int parentId)
        {
            var data = _categoryService.GetCategoryByParentId(parentId);
            return Json(new { Data = data });
        }

    }
}
