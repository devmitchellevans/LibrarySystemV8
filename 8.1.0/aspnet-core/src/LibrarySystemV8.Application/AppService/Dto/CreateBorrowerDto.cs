using Abp.AutoMapper;
using LibrarySystemV8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemV8.AppService.Dto
{
    [AutoMapFrom(typeof(BorrowerDto))]
    [AutoMapTo(typeof(Borrower))]
    public class CreateBorrowerDto
    {

        public DateTime BorrowDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int BookId { get; set; }
        public Book BookFk { get; set; }
        public int StudentId { get; set; }
        public Student StudentFk { get; set; }
    }
}
