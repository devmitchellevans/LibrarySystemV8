using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Abp.Application.Services.Dto;
using LibrarySystemV8.Controllers;
using LibrarySystemV8.AppService;
using LibrarySystemV8.Web.Models.Books;
using LibrarySystemV8.AppService.Dto;
using LibrarySystem.Web.Models.Books;
using LibrarySystem.AppService;

namespace LibrarySystem.Web.Controllers
{
    public class BooksController : LibrarySystemV8ControllerBase
    {
        private readonly IBookAppService _bookAppService;
        private readonly IBookCategoryAppService _bookCategoryAppService;
        private readonly IAuthorAppService _authorAppService;


        public BooksController(IBookAppService bookAppService, IBookCategoryAppService bookCategoryAppService, IAuthorAppService authorAppService)
        {
            _bookAppService = bookAppService;
            _bookCategoryAppService = bookCategoryAppService;
            _authorAppService = authorAppService;
        }
        public async Task<IActionResult> Index()
        {
            var books = await _bookAppService.GetAllBooksWithBookCategory(new PagedBookResultRequestDto { MaxResultCount = int.MaxValue });

            var model = new BookListViewModel()
            {
                Books = books.Items.ToList(),
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrEditBooks(int id)
        {
            var model = new CreateOrEditBookViewModel();
            var bookCategories = await _bookCategoryAppService.GetAllBookCategoryAsync();
            var authors = await _authorAppService.GetAllAuthorAsync();


            if (id > 0)
            {
            var selectedBook = await _bookAppService.GetAsync(new EntityDto<int>(id));
                model = new CreateOrEditBookViewModel()
                {

                    Id = selectedBook.Id,
                    BookTitle = selectedBook.BookTitle,
                    AuthorId = selectedBook.AuthorId,
                    BookPublisher = selectedBook.BookPublisher,
                    BookCategoryId = selectedBook.BookCategoryId,
                    IsBorrowed = selectedBook.IsBorrowed,

                 };

            }
            model.Authors = authors.ToList();
            model.BookCategories = bookCategories.ToList();
            return View(model);


        }
    }
}
