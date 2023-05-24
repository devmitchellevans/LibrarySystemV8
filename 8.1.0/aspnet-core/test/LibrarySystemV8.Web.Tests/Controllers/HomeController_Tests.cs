using System.Threading.Tasks;
using LibrarySystemV8.Models.TokenAuth;
using LibrarySystemV8.Web.Controllers;
using Shouldly;
using Xunit;

namespace LibrarySystemV8.Web.Tests.Controllers
{
    public class HomeController_Tests: LibrarySystemV8WebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}