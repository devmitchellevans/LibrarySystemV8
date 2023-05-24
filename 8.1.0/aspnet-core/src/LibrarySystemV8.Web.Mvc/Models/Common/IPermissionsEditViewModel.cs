using System.Collections.Generic;
using LibrarySystemV8.Roles.Dto;

namespace LibrarySystemV8.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}