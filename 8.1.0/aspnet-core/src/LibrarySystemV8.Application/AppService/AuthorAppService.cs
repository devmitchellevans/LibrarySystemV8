using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LibrarySystem.AppService.Dto;
using LibrarySystemV8.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.AppService
{
    public class AuthorAppService : AsyncCrudAppService<Author, AuthorDto, int, PagedAuthorResultRequestDto, CreateAuthorDto, AuthorDto>, IAuthorAppService
    {

        public readonly IRepository<Author> _authorRepository;
        public AuthorAppService(IRepository<Author, int> repository, IRepository<Author> authorRepository) : base(repository)
        {
            _authorRepository = authorRepository;
        }

        public override Task<PagedResultDto<AuthorDto>> GetAllAsync(PagedAuthorResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public override Task<AuthorDto> CreateAsync(CreateAuthorDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task<AuthorDto> UpdateAsync(AuthorDto input)
        {
                return base.UpdateAsync(input);
        }

        public override Task<AuthorDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public async Task<List<AuthorDto>> GetAllAuthorAsync()
        {
            var authors = await _authorRepository.GetAll()
                .Select(x => ObjectMapper.Map<AuthorDto>(x))
                .ToListAsync();

            return authors;
        }

    }
}
