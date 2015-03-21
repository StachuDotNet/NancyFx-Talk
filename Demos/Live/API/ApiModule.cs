using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.ModelBinding;

namespace Live.API
{
    public class ApiModule : NancyModule
    {
        List<Dragon> _dragons = new List<Dragon>()
        {
            new Dragon{ BreathesFire = true, Mass = 124100 }
        };

        public ApiModule() : base("/api")
        {
            // Get all dragons
            Get["/"] = _ => _dragons;

            // Get a specific dragon
            Get["/{id}"] = _ => GetDragon(_.id);

            // Add (POST) a new dragon to the API
            Post["/"] = _ =>
            {
                var newDragon = this.Bind<Dragon>();

                return AddDragon(newDragon);
            };
        }

        private int? AddDragon(Dragon newDragon)
        {
            if (newDragon == null) { return null; }

            newDragon.Id = _dragons.Max(d => d.Id) + 1;
            _dragons.Add(newDragon);

            return newDragon.Id;    
        }

        private Dragon GetDragon(int? id)
        {
            return _dragons.FirstOrDefault(d => d.Id == id);
        }
    }
}