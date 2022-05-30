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
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public  JsonResult GetById(int id)
        {
            var model = new ProductModelView();
            if (id > 0)
            {
                model =  _productService.GetById(id);
            }
            return Json(new
            {
                Data = model
            });
        }

        [HttpPost]
        public JsonResult Add(ProductModelView ProductModelView)
        {
            var result =  _productService.Add(ProductModelView);
            if (result > 0)
            {
                // check ảnh
            }
            
            return Json(new
            {
                success = result
            });
        }
        [HttpPost]
        public JsonResult Update(ProductModelView ProductModelView)
        {
            var result =  _productService.Update(ProductModelView);
            _productService.Save();
            return Json(new
            {
                success = result
            });
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var result =  _productService.Deleted(id);
            _productService.Save();
            return Json(new
            {
                success = result
            });
        }
        [HttpGet]
        public JsonResult GetAllPaging(ProductViewModelSearch productViewModelSearch)
        {
            var data = _productService.GetAllPaging(productViewModelSearch);
            return Json(new { data = data });
        }       

    }
}
