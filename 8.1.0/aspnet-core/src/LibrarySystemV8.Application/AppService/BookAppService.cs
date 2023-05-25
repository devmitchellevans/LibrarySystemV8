using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LibrarySystemV8.AppService.Dto;
using LibrarySystemV8.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemV8.AppService
{
    public class BookAppService : AsyncCrudAppService<Book, BookDto, int, PagedBookResultRequestDto, CreateBookDto, BookDto>, IBookAppService
    {
        public readonly IRepository<Book> _bookRepository;
        public BookAppService(IRepository<Book, int> repository, IRepository<Book> bookRepository) : base(repository)
        {
            _bookRepository = bookRepository;
        }

        public override Task<BookDto> CreateAsync(CreateBookDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PagedResultDto<BookDto>> GetAllAsync(PagedBookResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public override Task<BookDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<BookDto> UpdateAsync(BookDto input)
        {
            return base.UpdateAsync(input);
        }
        public async Task<PagedResultDto<BookDto>> GetAllBooksWithBookCategory(PagedBookResultRequestDto input)
        {
            var query = await _bookRepository.GetAll()
                .Include(x => x.BookCategoryFk)
                .Include(x => x.AuthorFk)
                .Select(x => ObjectMapper.Map<BookDto>(x))
                .ToListAsync();

                return new PagedResultDto<BookDto>(query.Count(), query);
        }
        public async Task<List<BookDto>> GetAllBookAsync()
        {
            var books = await _bookRepository.GetAll()
                .Select(x => ObjectMapper.Map<BookDto>(x))
                .ToListAsync();
            return books;
        }
    }
}
