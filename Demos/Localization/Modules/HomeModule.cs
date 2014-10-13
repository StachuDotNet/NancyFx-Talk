using Nancy;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Localization.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {

            Get["/"] = parameters => View["Index"];

            Get["/cultureview"] = parameters => View["CultureView"];

            Get["/cultureviewgerman"] = parameters =>
            {
                this.Context.Culture = new CultureInfo("de-DE");
                return View["CultureView"];
            };
        }
    }
}