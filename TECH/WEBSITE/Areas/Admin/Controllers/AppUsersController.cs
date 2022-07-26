using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WEBSITE.Areas.Admin.Models;
using WEBSITE.Areas.Admin.Models.Search;
using WEBSITE.Service;

namespace WEBSITE.Areas.Admin.Controllers
{
    public class AppUsersController : BaseController
    {
        private readonly IAppUserService _appUserService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IAppUserRoleService _appUserRoleService;
        public AppUsersController(IAppUserService appUserService,
            IAppUserRoleService appUserRoleService,
            IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _appUserService = appUserService;
            _appUserRoleService = appUserRoleService;
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
        public IActionResult UploadImageAvatar()
        {
            var files = Request.Form.Files;
            if (files != null && files.Count > 0)
            {
                string folder = _hostingEnvironment.WebRootPath + $@"\avatar";

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                var _lstImageName = new List<string>();

                foreach (var itemFile in files)
                {
                    string filePath = Path.Combine(folder, itemFile.FileName);
                    if (!System.IO.File.Exists(filePath))
                    {
                        _lstImageName.Add(itemFile.FileName);
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
            });
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
        public JsonResult AddUserRoles (int userId, int[] rolesId)
        {
            try
            {
                _appUserRoleService.AddAppUserRole(userId, rolesId);

                return Json(new
                {
                    success = true
                });
            }
            catch (Exception)
            {
                return Json(new
                {
                    success = false
                });
            }

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
