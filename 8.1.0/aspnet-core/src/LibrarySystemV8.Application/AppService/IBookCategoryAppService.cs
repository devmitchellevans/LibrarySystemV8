using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AutoMapper.Internal.Mappers;
using LibrarySystem.AppService.Dto;
using LibrarySystemV8.AppService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemV8.AppService
{
    public interface IBookCategoryAppService : IAsyncCrudAppService<BookCategoryDto, int, PagedBookCategoryResultRequestDto, CreateBookCategoryDto, BookCategoryDto>
    {
        Task<PagedResultDto<BookCategoryDto>> GetAllBookCategoriesWithDepartment(PagedBookCategoryResultRequestDto input);
        Task<List<BookCategoryDto>> GetAllBookCategoryAsync();

    }
}
