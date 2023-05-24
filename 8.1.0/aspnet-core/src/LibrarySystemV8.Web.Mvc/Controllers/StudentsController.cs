using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LibrarySystem.AppService;
using LibrarySystem.AppService.Dto;
using LibrarySystem.Web.Models.Students;
using System.Linq;
using Abp.Application.Services.Dto;
using LibrarySystemV8.Controllers;
using LibrarySystemV8.AppService;
using LibrarySystemV8.Entities;

namespace LibrarySystem.Web.Controllers
{
    public class StudentsController : LibrarySystemV8ControllerBase
    {
        private readonly IStudentAppService _studentAppService;
        private readonly IDepartmentAppService _departmentAppService;

        public StudentsController(IStudentAppService studentAppService, IDepartmentAppService departmentAppService)
        {
            _studentAppService = studentAppService;
            _departmentAppService = departmentAppService;

        }
        public async Task<IActionResult> Index()
        {
            var students = await _studentAppService.GetAllStudentsWithDepartment(new PagedStudentResultRequestDto { MaxResultCount = int.MaxValue });

            var model = new StudentListViewModel()
            {
                Students = students.Items.ToList(),
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrEditStudents(int id)
        {
            var model = new CreateOrEditStudentViewModel();
            var departments = await _departmentAppService.GetAllDepartmentAsync();


            if (id > 0)
            {
                var selectedStudent = await _studentAppService.GetAsync(new EntityDto<int>(id));
                 model = new CreateOrEditStudentViewModel()
                {

                    Id = selectedStudent.Id,
                    StudentName = selectedStudent.StudentName,
                    StudentContactNumber = selectedStudent.StudentContactNumber,
                    StudentEmail = selectedStudent.StudentEmail,
                    DepartmentId = selectedStudent.DepartmentId

                 };
             
            }
            model.Departments = departments.ToList();
            return View(model);


        }
    }
}
