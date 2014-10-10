using Nancy;
using Nancy.Testing;
using Xunit;

namespace Tests
{
    public class HomeModuleTests
    {
        [Fact]
        public void should_answer_200_on_root_path()
        {
            var sut = new Browser(new DefaultNancyBootstrapper());
            var actual = sut.Get("/");

            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);
        }

        [Fact]
        public void hello_something_should_respond_appropriately()
        {
            var word = "world";
            var sut = new Browser(new DefaultNancyBootstrapper());
            var actual = sut.Get("/" + word);

            Assert.True(actual.Body.AsString().Contains(word));
        }
    }
}
