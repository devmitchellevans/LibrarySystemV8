using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LibrarySystemV8.AppService.Dto;
using LibrarySystemV8.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemV8.AppService
{
    public class BorrowerAppService : AsyncCrudAppService<Borrower, BorrowerDto, int, PagedBorrowerResultRequestDto, CreateBorrowerDto, BorrowerDto>, IBorrowerAppService
    {
        public readonly IRepository<Borrower> _borrowerRepository;
        public BorrowerAppService(IRepository<Borrower, int> repository, IRepository<Borrower> borrowerRepository) : base(repository)
        {
            _borrowerRepository = borrowerRepository;
        }

        public override Task<BorrowerDto> CreateAsync(CreateBorrowerDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PagedResultDto<BorrowerDto>> GetAllAsync(PagedBorrowerResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public override Task<BorrowerDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<BorrowerDto> UpdateAsync(BorrowerDto input)
        {
            return base.UpdateAsync(input);
        }
        public async Task<PagedResultDto<BorrowerDto>> GetAllBorrowersWithBookCategory(PagedBorrowerResultRequestDto input)
        {
            var query = await _borrowerRepository.GetAll()
                .Include(x => x.BookFk)
                .Include(x => x.StudentFk)
                .Select(x => ObjectMapper.Map<BorrowerDto>(x))
                .ToListAsync();

                return new PagedResultDto<BorrowerDto>(query.Count(), query);
        }


    }
}
