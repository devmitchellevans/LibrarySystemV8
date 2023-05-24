using Abp.Application.Services.Dto;
using Abp.Application.Services;
using LibrarySystemV8.AppService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemV8.AppService
{
    public interface IBookAppService : IAsyncCrudAppService<BookDto, int, PagedBookResultRequestDto, CreateBookDto, BookDto>
    {
        Task<PagedResultDto<BookDto>> GetAllBooksWithBookCategory(PagedBookResultRequestDto input);
        Task<List<BookDto>> GetAllBookAsync();

    }
}
