using System;
using System.Collections.Generic;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Elmah;
using Nancy.TinyIoc;

namespace Elmah
{
	public class Bootstrapper : DefaultNancyBootstrapper
	{
		protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
		{
			base.ApplicationStartup(container, pipelines);
			Elmahlogging.Enable(pipelines, "admin/elmah");
		}
	}
}