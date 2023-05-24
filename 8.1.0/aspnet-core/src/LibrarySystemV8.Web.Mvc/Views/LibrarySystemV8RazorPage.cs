using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace LibrarySystemV8.Web.Views
{
    public abstract class LibrarySystemV8RazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected LibrarySystemV8RazorPage()
        {
            LocalizationSourceName = LibrarySystemV8Consts.LocalizationSourceName;
        }
    }
}
