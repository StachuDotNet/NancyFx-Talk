using Nancy;

namespace Basic.Modules
{
    public class MainModule : NancyModule
    {
        public MainModule()
        {
            Get["/"] = _ => "<a href='/secure'>Enter</a>";
        }
    }
}