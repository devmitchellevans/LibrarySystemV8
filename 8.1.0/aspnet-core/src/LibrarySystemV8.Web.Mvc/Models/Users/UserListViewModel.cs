using System.Collections.Generic;
using LibrarySystemV8.Roles.Dto;

namespace LibrarySystemV8.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
