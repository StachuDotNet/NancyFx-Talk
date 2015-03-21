using Nancy;

namespace Hooks
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            // Before interceptors will be hit before the routes have a chance to fire.

            // If we return null, then no action was taken by the interceptor.
            Before += (ctx) => {
                return null;
            };

            // Otherwise, the routes won't even have a chance to fire
            Before += ctx => {
                // April Fools Joke from 1998!
                return HttpStatusCode.ImATeapot; // 418
            };

            /****************************
             * Define routes here
             ***************************/

            // After interceptors will be hit after the routes have a chance to fire.
            // They are used to modify the context's Response.

            After += ctx => {
                ctx.Response.AddCookie("cookieName", "cookieValue");
                ctx.Response.WithHeader("SpecialHeader", "value");

                // log stuff here.
            };
        }
    }
}