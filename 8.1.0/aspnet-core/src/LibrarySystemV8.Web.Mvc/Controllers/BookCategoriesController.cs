using Abp.Application.Services.Dto;
using LibrarySystem.AppService;
using LibrarySystem.Web.Models.Students;
using LibrarySystemV8.AppService;
using LibrarySystemV8.AppService.Dto;
using LibrarySystemV8.Controllers;
using LibrarySystemV8.Web.Models.BookCategories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemV8.Web.Controllers
{
    public class BookCategoriesController : LibrarySystemV8ControllerBase
    {

        private readonly IBookCategoryAppService _bookCategoryAppService;
        private readonly IDepartmentAppService _departmentAppService;

        public BookCategoriesController(IBookCategoryAppService bookCategoryAppService, IDepartmentAppService departmentAppService)
        {
            _bookCategoryAppService = bookCategoryAppService;
            _departmentAppService = departmentAppService;
        }




        // GET: BookCategories
        public async Task<IActionResult> Index()
        {
            var bookCategories = await _bookCategoryAppService.GetAllBookCategoriesWithDepartment(new PagedBookCategoryResultRequestDto { MaxResultCount = int.MaxValue });
            var model = new BookCategoryListViewModel()
            {
                BookCategories = bookCategories.Items.ToList()
            };
            return View(model);
        }

        public async Task<IActionResult> CreateOrEditBookCategories(int id)
        {
            var model = new CreateOrEditBookCategoryViewModel();
            var departments = await _departmentAppService.GetAllDepartmentAsync();

            if (id > 0)
            {
                var bookCategory = await _bookCategoryAppService.GetAsync(new EntityDto<int>(id));
                model = new CreateOrEditBookCategoryViewModel()
                {

                    Id = bookCategory.Id,
                    Name = bookCategory.Name,
                    DepartmentId = bookCategory.DepartmentId

                };

            }
            model.Departments = departments.ToList();
            return View(model);


        }

        // GET: BookCategories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookCategories/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookCategories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookCategories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookCategories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
