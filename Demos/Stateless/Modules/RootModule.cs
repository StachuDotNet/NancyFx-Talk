using Nancy;

namespace Stateless
{
    public class RootModule : NancyModule
    {
        public RootModule()
        {
            Get["/"] = _ => Response.AsText("Un-secure content.");
        }
    }
}