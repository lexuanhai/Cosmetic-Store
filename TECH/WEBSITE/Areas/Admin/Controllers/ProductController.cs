using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WEBSITE.Areas.Admin.Models;
using WEBSITE.Areas.Admin.Models.Search;
using WEBSITE.Data.DatabaseEntity;
using WEBSITE.Service;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace WEBSITE.Areas.Admin.Controllers
{
    //[Authorize]
    public class ProductController : BaseController
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IProductService _productService;
        private readonly IImagesProductService _imagesProductService;

        public ProductController(IProductService productService,
            IImagesProductService imagesProductService,
            IHostingEnvironment hostingEnvironment)
        {
            _productService = productService;
            _imagesProductService = imagesProductService;
            _hostingEnvironment = hostingEnvironment;
        
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddOrUpdate()
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
        public IActionResult UploadImageProduct()
        {
            var files = Request.Form.Files;
            if (files != null && files.Count > 0)
            {
                string folerProductId = "product_" + files[0].Name;

                var imageFolder = $@"\product-image\" + folerProductId;

                string folder = _hostingEnvironment.WebRootPath + imageFolder;

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);

                    foreach (var itemFile in files)
                    {
                        string fileNameFormat = Regex.Replace(itemFile.FileName.ToLower(), @"\s+", "");
                        string filePath = Path.Combine(folder, fileNameFormat);
                        using (FileStream fs = System.IO.File.Create(filePath))
                        {
                            itemFile.CopyTo(fs);
                            fs.Flush();
                        }

                    }
                }
            }
            return Json(new
            {
                success = true
            }) ;
        }

        [HttpPost]
        public JsonResult Add(ProductModelView productModelView)
        {
            var result = _productService.Add(productModelView);

            return Json(new
            {
                success = result > 0? true: false,
                id = result
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
