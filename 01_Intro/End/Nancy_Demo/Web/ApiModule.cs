using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{
    public class Person
    {
        public string Name { get; set; }
        public int Mass { get; set; }
    }

    public class ApiModule : NancyModule
    {
        public static List<Person> People = new List<Person>();

        public ApiModule() : base("api")
        {
            Get["/"] = _ => Response.AsJson(People);

            Post["/"] = _ => {
                var person = this.Bind<Person>();

                People.Add(person);
                return Response.AsJson(People).WithStatusCode(HttpStatusCode.Created);
            };
        }
    }
}