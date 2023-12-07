using monoos.src.Game.PropertiesTypes;
using monoos.src.Render.BaseRenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Render.LocationRenderers
{
    internal class RailRoadPropertyRender : ConcreteRender<RailRoadProperty>
    {
        public RailRoadPropertyRender(RailRoadProperty prop, BoardRectangle br) : base(prop, br)
        {
        }

        public override void RenderLocation()
        {
            throw new NotImplementedException();
        }
    }
}