using Abp.AutoMapper;
using LibrarySystemV8.Roles.Dto;
using LibrarySystemV8.Web.Models.Common;

namespace LibrarySystemV8.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
