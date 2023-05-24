using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace LibrarySystemV8.Controllers
{
    public abstract class LibrarySystemV8ControllerBase: AbpController
    {
        protected LibrarySystemV8ControllerBase()
        {
            LocalizationSourceName = LibrarySystemV8Consts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
