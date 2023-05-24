using Abp.Application.Services;
using LibrarySystemV8.AppService;
using LibrarySystemV8.AppService.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LibrarySystem.Web.Models.Borrowers;
using Abp.AutoMapper;
using System.Linq;
using LibrarySystemV8.Controllers;
using Abp.Application.Services.Dto;
using Newtonsoft.Json.Converters;

namespace LibrarySystemV8.Web.Controllers
{
    public class BorrowersController : LibrarySystemV8ControllerBase
    {
        private readonly IBorrowerAppService _borrowerAppService;
        private readonly IBookAppService _bookAppService;
        private readonly IStudentAppService _studentAppService;

        public BorrowersController(IBorrowerAppService borrowerAppService, IBookAppService bookAppService, IStudentAppService studentAppService)
        {
            _borrowerAppService = borrowerAppService;
            _bookAppService = bookAppService;
            _studentAppService = studentAppService;
        }

        public async Task<IActionResult> Index()
        {
            var borrowers = await _borrowerAppService.GetAllBorrowersWithBookCategory(new PagedBorrowerResultRequestDto { MaxResultCount = int.MaxValue});
            var model = new BorrowerListViewModel()
            {
                Borrowers = borrowers.Items.Where(x => x.BookFk.IsBorrowed == true).ToList()
            };
            return View(model);  
        }

        public async Task<IActionResult> EditBorrowers(int id)
        {
            var students = await _studentAppService.GetAllStudentAsync();
            var books = await _bookAppService.GetAllBookAsync();

            
                var selectedBorrower = await _borrowerAppService.GetAsync(new EntityDto<int>(id));
                 var model = new CreateOrEditBorrowerViewModel()
                {

                    Id = selectedBorrower.Id,
                    BorrowDate = selectedBorrower.BorrowDate,
                    ExpectedReturnDate = selectedBorrower.ExpectedReturnDate,
                    ReturnDate = selectedBorrower.ReturnDate,
                    BookId = selectedBorrower.BookId,
                    StudentId = selectedBorrower.StudentId

                };
           


            model.Students = students.ToList();
            model.Books = books.ToList();
            return View(model);
        }

        public async Task<IActionResult> CreateBorrowers()
        {
            var model = new CreateOrEditBorrowerViewModel();
            var students = await _studentAppService.GetAllStudentAsync();
            var books = await _bookAppService.GetAllBooksWithBookCategory(new PagedBookResultRequestDto { MaxResultCount = int.MaxValue });

            model.Students = students.ToList();
            model.Books = books.Items.ToList();
            
            return View(model);
        }
    }
}
    