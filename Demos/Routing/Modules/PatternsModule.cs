using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Routing
{
    public class PatternsModule : NancyModule
    {
        public PatternsModule() : base("/base/route")
        {
            // literal string
            Get["/literal/string"] = _ => "";
            
            // {} pair can be used to capture a value from the URL and match to an ambiguous audience
            Get["/captured/{value}"] = _ => "Captured value" + _.value;

            // You can add route restraints to capture only certain types of values
            Get["/{words:alpha}"] = _ => "Words!: " + _.words;
        }
    }
}