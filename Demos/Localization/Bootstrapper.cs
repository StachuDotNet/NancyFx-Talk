using Nancy;
using Nancy.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Localization
{
    public class DemoBoostrapper : DefaultNancyBootstrapper
    {
        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(x => x.ResourceAssemblyProvider = typeof(CustomResourceAssemblyProvider));
            }
        }
    }
}