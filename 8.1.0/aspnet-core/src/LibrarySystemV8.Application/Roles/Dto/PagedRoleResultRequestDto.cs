using Abp.Application.Services.Dto;

namespace LibrarySystemV8.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

