using Nancy;
using System.Collections.Generic;
using System.Linq;
using Nancy.ModelBinding;

namespace End.DragonAPI
{
    public class DragonModule : NancyModule
    {
        private readonly List<Dragon> _dragonList;

        public DragonModule()
            : base("/dragon")
        {
            _dragonList = new List<Dragon>()
            {
                new Dragon(){ BreathesFire = true, Id = 1, Mass = 12000}
            };

            Get["/"] = _ => _dragonList;

            Get["/{id:int}"] = _ => GetDragon(_.id);

            Post["/"] = _ =>
            {
                var dragon = this.Bind<Dragon>();

                return AddDragon(dragon);
            };
        }

        private int? AddDragon(Dragon dragon)
        {
            if (dragon == null) return null;

            dragon.Id = _dragonList.Max(d => d.Id) + 1;
            _dragonList.Add(dragon);

            return dragon.Id;
        }

        public Dragon GetDragon(int? id)
        {
            return _dragonList.FirstOrDefault(d => d.Id == id);
        }
    }
}