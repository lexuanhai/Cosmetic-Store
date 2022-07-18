using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBSITE.Areas.Admin.Models;
using WEBSITE.Service;

namespace WEBSITE.Areas.Admin.Controllers
{
    public class AppUsersController : BaseController
    {
    //    private readonly IUserService _userService;
    //    public AppUsersController(IUserService userService)
    //    {
    //        _userService = userService;
    //    }
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }
    //    [HttpGet]
    //    public JsonResult GetAll()
    //    {
    //        var model = _userService.GetAllUser();
    //        bool isData = false;
    //        if (model != null && model.Count > 0)
    //             isData = true;
    //        return Json(new
    //        {
    //            IsData = isData,
    //            Data = model
    //        });
    //    }
    //    [HttpGet]
    //    public async Task<JsonResult> GetById(string id)
    //    {
    //        var model = new UserModelView();
    //        if (!string.IsNullOrEmpty(id))
    //        {
    //           model = await _userService.GetUserById(id);
    //        }            
    //        return Json(new
    //        {
    //            Data = model
    //        });
    //    }
    //    [HttpPost]
    //    public async Task<JsonResult> AddUser(UserModelView userModelView)
    //    {
    //        var result = await _userService.AddUser(userModelView);            
    //        return Json(new
    //        {
    //            success = result
    //        });
    //    }
    //    [HttpPost]
    //    public async Task<JsonResult> UpdateUser(UserModelView userModelView)
    //    {
    //        var result = await _userService.UpdateUser(userModelView);
    //        return Json(new
    //        {
    //            success = result
    //        });
    //    }
    //    [HttpPost]
    //    public async Task<JsonResult> DeleteUser(string userId)
    //    {
    //        var result = await _userService.DeletedUser(userId);
    //        return Json(new
    //        {
    //            success = result
    //        });
    //    }
    }
}
