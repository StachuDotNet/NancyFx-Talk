using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace Hooks
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // can also wire up these hooks in RequestStartup in some more advanced scenarios.
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            pipelines.BeforeRequest += ctx =>
            {
                return null;
                // return null or a Response
            };

            pipelines.AfterRequest += (ctx) =>
            {
                // modify ctx.request
            };

            pipelines.OnError += (ctx, ex) =>
            {
                // can either return null, or a Response object.
                return null;
            };
        }
    }
}