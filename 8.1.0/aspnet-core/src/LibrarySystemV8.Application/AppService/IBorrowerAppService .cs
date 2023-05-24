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
    public interface IBorrowerAppService : IAsyncCrudAppService<BorrowerDto, int, PagedBorrowerResultRequestDto, CreateBorrowerDto, BorrowerDto>
    {
        Task<PagedResultDto<BorrowerDto>> GetAllBorrowersWithBookCategory(PagedBorrowerResultRequestDto input);

    }
}
