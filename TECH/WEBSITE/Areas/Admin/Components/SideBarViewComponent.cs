using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WEBSITE.Service;

namespace WEBSITE.Areas.Admin.Components
{
    public class SideBarViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;

        public SideBarViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var roles = ((ClaimsPrincipal)User).GetSpecificClaim("Roles");
            //List<FunctionViewModel> functions;
            //if (roles.Split(";").Contains(CommonConstants.AdminRole))
            //{
            //    functions = await _functionService.GetAll();
            //}
            //else
            //{
            //    //TODO: Get by permission
            //    functions = new List<FunctionViewModel>();
            //}
            var categoryModel = _categoryService.GetAll();
            return View(categoryModel);
        }
    }
}