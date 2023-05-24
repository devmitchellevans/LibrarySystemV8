using LibrarySystem.AppService.Dto;
using LibrarySystemV8.AppService.Dto;

using System;
using System.Collections.Generic;

namespace LibrarySystem.Web.Models.Borrowers
{
    public class CreateOrEditBorrowerViewModel
    {
        public int Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int BookId { get; set; }
        public List<BookDto> Books { get; set; }
        public int StudentId { get; set; }
        public List<StudentDto> Students { get; set; }

    }
}
