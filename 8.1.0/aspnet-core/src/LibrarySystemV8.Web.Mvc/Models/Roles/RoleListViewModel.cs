using System.Collections.Generic;
using LibrarySystemV8.Roles.Dto;

namespace LibrarySystemV8.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
