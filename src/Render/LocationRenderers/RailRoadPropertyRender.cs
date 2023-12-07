using monoos.src.Game.PropertiesTypes;
using monoos.src.Render.BaseRenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Render.LocationRenderers
{
    internal class RailRoadPropertyRender(RailRoadProperty locationInfo, BoardRectangle locationRender) : ConcreteRender<RailRoadProperty>(locationInfo, locationRender)
    {
        public override void RenderLocation()
        {
            LoadTexture(locationInfo.square);
        }
    }
}