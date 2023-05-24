using Abp.AutoMapper;
using LibrarySystemV8.Sessions.Dto;

namespace LibrarySystemV8.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
