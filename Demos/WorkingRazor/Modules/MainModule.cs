using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Nancy.ModelBinding;
using Nancy.Validation;
using Razor.Models;


namespace Razor.Modules
{
    public class MainModule : NancyModule
    {
        public MainModule()
        {
            Get["/"] = x =>
            { 
                var model = DB.Customers.OrderBy(e => e.RenewalDate).ToArray();

                return View["Customers", model];
            };

            Get["/poke"] = parameters =>
            {
                var validator =
                    this.ValidatorLocator.GetValidatorForType(typeof(Customer));

                return this.Response.AsJson(validator.Description);
            };

            Post["/"] = x =>
            {
                Customer model = this.Bind();
                var result = this.Validate(model);

                if (!result.IsValid)
                {
                    return View["CustomerError", result];
                }

                DB.Customers.Add(model);

                return this.Response.AsRedirect("/Customers");
            };
        }
    }

}