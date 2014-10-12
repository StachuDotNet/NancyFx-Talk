using Nancy;

namespace End
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => "Hello, from Nancy";
            Get["/funcEquivalent"] = FuncEquivalent;

            Get["/{capturedValue}"] = _ => "Value captured in route: " + _.capturedValue;

            Get["/htmlPage"] = _ => View["index"];
        }

        // This is equivalent to _ => "Hello, from Nancy".
        // This is a C# feature, and is not specific to Nancy at all!
        private dynamic FuncEquivalent(dynamic input)
        {
            return "Hello, from Nancy";
        }
    }
}