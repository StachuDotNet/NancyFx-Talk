using Nancy;
using Nancy.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web;
using Xunit;

namespace Tests
{
    public class ApiModuleTests
    {
        private Browser sut;

        public ApiModuleTests()
        {
            ApiModule.People.Clear();
            sut = new Browser(new DefaultNancyBootstrapper());
        }

        [Fact]
        public void should_return_empty_list_before_inserts()
        {
            var actual = sut.Get("/api/");

            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);
            Assert.Empty(actual.Body.DeserializeJson<Person[]>());
        }

        [Fact]
        public void should_return_201_create_on_person_post()
        {
            var person = new Person { Name = "Stachu", Mass = 1 };
            var actual = sut.Post("/api/", with => with.JsonBody(person));

            Assert.Equal(HttpStatusCode.Created, actual.StatusCode);
        }

        [Fact]
        public void post_actually_posts()
        {
            var person = new Person { Name = "Stachu", Mass = 1 };
            var actual = sut.Post("/api/", with => with.JsonBody(person))
                .Then.Get("/api/");

            var actualBody = actual.Body.DeserializeJson<Person[]>();
            
            Assert.Equal(1, actualBody.Length);
            Assert.Equal(person.Name, actualBody[0].Name);
        }
    }
}
