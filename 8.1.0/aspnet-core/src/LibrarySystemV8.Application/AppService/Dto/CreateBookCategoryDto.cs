using Abp.AutoMapper;
using LibrarySystemV8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemV8.AppService.Dto
{
    [AutoMapFrom(typeof(BookCategoryDto))]
    [AutoMapTo(typeof(BookCategory))]
    public class CreateBookCategoryDto
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public Department DepartmentFk { get; set; }
    }
}
