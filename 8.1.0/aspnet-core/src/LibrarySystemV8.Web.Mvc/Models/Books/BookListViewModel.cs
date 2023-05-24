using LibrarySystemV8.AppService.Dto;
using LibrarySystemV8.Entities;
using System.Collections.Generic;

namespace LibrarySystemV8.Web.Models.Books
{
    public class BookListViewModel
    {
        public List<BookDto> Books { get; set; }
    }
}
