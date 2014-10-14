using Nancy;
using Nancy.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testing.Tests
{
    public class HomeModuleTests
    {
        [Fact]
        public void Should_return_status_ok_when_route_exists()
        {
            // Given
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper, defaults: to => to.Accept("application/json"));

            // When
            var result = browser.Get("/", with => { with.HttpRequest(); });

            // Then
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void Should_redirect_to_login_with_error_details_incorrect()
        {
            // Given
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper);

            // When
            var response = browser.Post("/login/", (with) =>
            {
                with.HttpRequest();
                with.FormValue("Username", "username");
                with.FormValue("Password", "wrongpassword");
            });

            // Then
            response.ShouldHaveRedirectedTo("/login?error=true&username=username");
        }


        [Fact]
        public void Should_display_error_message_when_error_passed()
        {
            // Given
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper);

            // When
            var response = browser.Get("/login", (with) =>
            {
                with.HttpRequest();
                with.Query("error", "true");
            });

            // Then
            response.Body["#errorBox"]
                    .ShouldExistOnce()
                    .And.ShouldBeOfClass("floatingError")
                    .And.ShouldContain(
                        "invalid",
                        StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
