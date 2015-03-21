using Nancy;
using System.Globalization;

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
                Context.Culture = new CultureInfo("de-DE");
                return View["CultureView"];
            };
        }
    }
}