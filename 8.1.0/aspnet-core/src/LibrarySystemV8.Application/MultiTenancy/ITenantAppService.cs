using Abp.Application.Services;
using LibrarySystemV8.MultiTenancy.Dto;

namespace LibrarySystemV8.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

