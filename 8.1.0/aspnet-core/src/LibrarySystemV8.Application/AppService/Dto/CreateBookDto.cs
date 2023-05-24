using Abp.AutoMapper;
using LibrarySystemV8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemV8.AppService.Dto
{
    [AutoMapFrom(typeof(BookDto))]
    [AutoMapTo(typeof(Book))]
    public class CreateBookDto
    {

        public string BookTitle { get; set; }
        public string BookPublisher { get; set; }   
        public string BookAuthor { get; set; }
        public bool? IsBorrowed { get; set; }
        public int BookCategoryId { get; set; }
        public BookCategory BookCategoryFk { get; set; }
    }
}
