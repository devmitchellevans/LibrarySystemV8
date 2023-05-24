using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using LibrarySystemV8.Controllers;

namespace LibrarySystemV8.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : LibrarySystemV8ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
