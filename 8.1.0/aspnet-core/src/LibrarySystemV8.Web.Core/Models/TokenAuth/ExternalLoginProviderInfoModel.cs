using Abp.AutoMapper;
using LibrarySystemV8.Authentication.External;

namespace LibrarySystemV8.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
