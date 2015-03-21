using Nancy;

namespace Routing.Modules
{
    public class ConditionsModule : NancyModule
    {
        public ConditionsModule()
        {
            // Conditions must be of the form Func<NancyContext, bool> !

            Post["/login", (ctx) => ctx.Request.Form.remember] = _ => 
				"Handling code when remember is true!";

            Post["/login", (ctx) => !ctx.Request.Form.remember] = _ =>
				"Handling code when remember is false!";
        }
    }
}