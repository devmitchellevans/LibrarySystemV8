using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LibrarySystemV8.AppService.Dto;
using LibrarySystemV8.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemV8.AppService
{
    public class BookCategoryAppService : AsyncCrudAppService<BookCategory, BookCategoryDto, int, PagedBookCategoryResultRequestDto, CreateBookCategoryDto, BookCategoryDto>, IBookCategoryAppService
    {
        public readonly IRepository<BookCategory> _bookCategoryRepository;
        public BookCategoryAppService(IRepository<BookCategory, int> repository, IRepository<BookCategory> bookCategoryRepository) : base(repository)
        {
            _bookCategoryRepository = bookCategoryRepository;
        }

        public override Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PagedResultDto<BookCategoryDto>> GetAllAsync(PagedBookCategoryResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public override Task<BookCategoryDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<BookCategoryDto> UpdateAsync(BookCategoryDto input)
        {
            return base.UpdateAsync(input);
        }
        public async Task<PagedResultDto<BookCategoryDto>> GetAllBookCategoriesWithDepartment(PagedBookCategoryResultRequestDto input)
        {
            var query = await _bookCategoryRepository.GetAll()
                .Include(x => x.DepartmentFk)
                .Select(x => ObjectMapper.Map<BookCategoryDto>(x))
                .ToListAsync();



            return new PagedResultDto<BookCategoryDto>(query.Count(), query);
        }

        public async Task<List<BookCategoryDto>> GetAllBookCategoryAsync()
        {
            var bookCategories = await _bookCategoryRepository.GetAll()
                .Select(x => ObjectMapper.Map<BookCategoryDto>(x))
                .ToListAsync();
            return bookCategories;
        }
    }
}
