using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBSITE.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Authorize]
    public class BaseController : Controller
    {
    }
}
