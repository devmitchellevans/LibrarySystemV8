using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LibrarySystem.AppService;
using LibrarySystem.AppService.Dto;
using LibrarySystem.Web.Models.Authors;
using System.Linq;
using Abp.Application.Services.Dto;
using LibrarySystemV8.Controllers;
using LibrarySystemV8.Web.Models.Users;
using System.Diagnostics;

namespace LibrarySystem.Web.Controllers
{
    public class AuthorsController : LibrarySystemV8ControllerBase
    {
        private readonly IAuthorAppService _authorAppService;
        public AuthorsController(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }
        public async Task<ActionResult> Index()
        {
            var authors = await _authorAppService.GetAllAuthorAsync();
            var model = new AuthorListViewModel
            {
                 Authors = authors
            };
            return View(model);
        }

        public async Task<ActionResult> EditModal(int id)
        {
            var author = await _authorAppService.GetAsync(new EntityDto<int>(id));
            var model = new EditAuthorModalViewModel
            {
                Author = author,
            };
            return PartialView("_EditModal", model);
        }
    }
}
