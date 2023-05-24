using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using LibrarySystemV8.Configuration.Dto;

namespace LibrarySystemV8.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : LibrarySystemV8AppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
