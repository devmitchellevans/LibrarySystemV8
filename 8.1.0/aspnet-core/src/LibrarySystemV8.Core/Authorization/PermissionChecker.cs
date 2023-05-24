using Abp.Authorization;
using LibrarySystemV8.Authorization.Roles;
using LibrarySystemV8.Authorization.Users;

namespace LibrarySystemV8.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
