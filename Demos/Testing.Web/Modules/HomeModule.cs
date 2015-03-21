using Nancy;

namespace Testing.Web.Modules
{
	public class HomeModule : NancyModule
	{
		public HomeModule()
		{
			Get["/"] = _ => "root path";

			Post["/login"] = _ => Response.AsRedirect("/login?error=true&username=username");


			Get["/login"] = _ => 
				"<body>" +
					"<div id=\"errorBox\" class=\"floatingError\">" +
						"testing invalid testing" +
					"</div>" +
				"</body>";
		}
	}
}