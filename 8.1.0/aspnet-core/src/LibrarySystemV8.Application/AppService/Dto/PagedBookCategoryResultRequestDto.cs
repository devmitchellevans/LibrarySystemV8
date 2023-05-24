using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemV8.AppService.Dto
{
    public class PagedBookCategoryResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }

        public bool? isActive { get; set; }
    }
}
