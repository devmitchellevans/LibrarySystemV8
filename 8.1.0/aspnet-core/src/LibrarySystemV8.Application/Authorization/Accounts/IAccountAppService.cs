using System.Threading.Tasks;
using Abp.Application.Services;
using LibrarySystemV8.Authorization.Accounts.Dto;

namespace LibrarySystemV8.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
