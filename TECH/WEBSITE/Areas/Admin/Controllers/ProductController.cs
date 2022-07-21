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
        private readonly IAppImagesService _appImagesService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandsService _brandsService;
        public ProductController(IProductService productService,
            IImagesProductService imagesProductService,
            ICategoryService categoryService,
            IBrandsService brandsService,
            IAppImagesService appImagesService,
        IHostingEnvironment hostingEnvironment)
        {
            _productService = productService;
            _imagesProductService = imagesProductService;
            _hostingEnvironment = hostingEnvironment;
            _categoryService = categoryService;
            _brandsService = brandsService;
            _appImagesService = appImagesService;
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
                    var lstImageName = files.Select(i => i.FileName).ToArray();                    

                    var appImages = _appImagesService.AddImages(Convert.ToInt32(files[0].Name), lstImageName);
                    if (appImages != null && appImages.Count > 0)
                    {
                        _imagesProductService.AddImages(Convert.ToInt32(files[0].Name), appImages);
                    }

                    _productService.Save();
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
        public JsonResult ProductColors(ProductModelView productModelView)
        {
            var result = _productService.Add(productModelView);

            return Json(new
            {
                success = result > 0 ? true : false,
                id = result
            });
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
        public JsonResult Update(ProductModelView productModelView)
        {
            var result =  _productService.Update(productModelView);
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

            if (data != null && data.Results != null && data.Results.Count > 0)
            {
                foreach (var item in data.Results)
                {
                    if (item.CategoryId.HasValue && item.CategoryId.Value > 0)
                    {
                        var categoryModel = _categoryService.GetById(item.CategoryId.Value);
                        if (categoryModel != null)
                        {
                            item.CategoryName = categoryModel.Name;
                        }
                    }
                    if (item.BrandsId.HasValue && item.BrandsId.Value > 0)
                    {
                        var brandsModel = _brandsService.GetById(item.CategoryId.Value);
                        if (brandsModel != null)
                        {
                            item.BrandName = brandsModel.Name;
                        }
                    }
                }
            }

            return Json(new { data = data });
        }

        //[HttpGet]
        //public JsonResult GetImagesByProductId(int id)
        //{
        //    var model = new List<ImagesProductModelView>();
        //    if (id > 0)
        //    {
        //        model = _imagesProductService.GetAll(id);
        //    }
        //    return Json(new
        //    {
        //        Data = model
        //    });
        //}

    }
}
