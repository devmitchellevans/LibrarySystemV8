using Abp.AspNetCore.Mvc.ViewComponents;

namespace LibrarySystemV8.Web.Views
{
    public abstract class LibrarySystemV8ViewComponent : AbpViewComponent
    {
        protected LibrarySystemV8ViewComponent()
        {
            LocalizationSourceName = LibrarySystemV8Consts.LocalizationSourceName;
        }
    }
}
