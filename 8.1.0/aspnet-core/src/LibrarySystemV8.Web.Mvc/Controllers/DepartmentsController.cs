using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LibrarySystem.AppService;
using LibrarySystem.AppService.Dto;
using LibrarySystem.Web.Models.Departments;
using System.Linq;
using Abp.Application.Services.Dto;
using LibrarySystemV8.Controllers;

namespace LibrarySystem.Web.Controllers
{
    public class DepartmentsController : LibrarySystemV8ControllerBase
    {
        private readonly IDepartmentAppService _departmentAppService;
        public DepartmentsController(IDepartmentAppService departmentAppService)
        {
            _departmentAppService = departmentAppService;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var departments = await _departmentAppService.GetAllAsync(new PagedDepartmentResultRequestDto { MaxResultCount = int.MaxValue });
            var model = new DepartmentListViewModel();

            if (searchString != null)
            {
                model = new DepartmentListViewModel()
                {
                    Departments = departments.Items.Where(x => x.Name!.Contains(searchString)).ToList()
                };

            }
            else
            {
                model = new DepartmentListViewModel()
                {
                    Departments = departments.Items.ToList(),
                };
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrEditDepartments(int id)
        {
            if(id > 0)
            {
                var selectedDepartment = await _departmentAppService.GetAsync(new EntityDto<int>(id));
                var model = new CreateOrEditDepartmentViewModel()
                {

                    Id = selectedDepartment.Id,
                    Name = selectedDepartment.Name

                };
                return View(model);
            }
            else
            {
                return View();
            }

        }
    }
}
