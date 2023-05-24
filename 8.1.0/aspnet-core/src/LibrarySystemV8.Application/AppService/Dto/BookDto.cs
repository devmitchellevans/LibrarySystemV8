using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibrarySystemV8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemV8.AppService.Dto
{
    [AutoMapFrom(typeof(Book))]
    [AutoMapTo(typeof(Book))]
    public class BookDto : EntityDto<int>
    {
        public string BookTitle { get; set; }
        public string BookPublisher { get; set; }
        public string BookAuthor { get; set; }
        public bool IsBorrowed { get; set; }
        public int BookCategoryId { get; set; }
        public BookCategory BookCategoryFk { get; set; }
    }
}
