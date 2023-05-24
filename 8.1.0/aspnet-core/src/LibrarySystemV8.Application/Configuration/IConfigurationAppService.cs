using System.Threading.Tasks;
using LibrarySystemV8.Configuration.Dto;

namespace LibrarySystemV8.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
