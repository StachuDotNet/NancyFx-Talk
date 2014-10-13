using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bootstrapper
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // Initializes the boostrapper.
        // Can be used for adding hooks or other initialization tasks that aren't container-related
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
        }

        // Similar to ApplicationStart, but fired per-request!
        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);
        }

        // Here in case you need to make any general changes to your IOC container config
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
        }

        // Used to change Nancy-wide convensions, such as:
        // -where to look for views
        // -where to look for static content (.css, .js, .png, etc)
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);
        }

        // Used to manually register instances of an interface rather than using the default
        protected override void RegisterInstances(TinyIoCContainer container, IEnumerable<InstanceRegistration> instanceRegistrations)
        {
            base.RegisterInstances(container, instanceRegistrations);
        }
    }
}