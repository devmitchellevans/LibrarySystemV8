using System.Threading.Tasks;
using Abp.Application.Services;
using LibrarySystemV8.Sessions.Dto;

namespace LibrarySystemV8.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
