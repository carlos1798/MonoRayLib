using monoos.src.Game.EventLocations.BigSquareLocations;
using monoos.src.Render.BaseRenders;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Render.LocationRenderers
{
    internal class GoToJailLocationRender(GoToJailLocation location, BoardRectangle br, Dictionary<string, Texture2D> textures) : ConcreteRender<GoToJailLocation>(location, br, textures)
    {
        public override void RenderLocation()
        {
            RenderBigSquare(location.square, "GoToJail");
        }
    }

    internal class ParkingLocationRender(ParkingLocation location, BoardRectangle br, Dictionary<string, Texture2D> textures) : ConcreteRender<ParkingLocation>(location, br, textures)
    {
        public override void RenderLocation()
        {
            RenderBigSquare(location.square, "Parking");
        }
    }

    internal class JailLocationRender(JailLocation location, BoardRectangle br, Dictionary<string, Texture2D> textures) : ConcreteRender<JailLocation>(location, br, textures)
    {
        public override void RenderLocation()
        {
            RenderBigSquare(location.square, "Jail");
        }
    }

    internal class StartLocationRender(StartLocation location, BoardRectangle br, Dictionary<string, Texture2D> textures) : ConcreteRender<StartLocation>(location, br, textures)
    {
        public override void RenderLocation()
        {
            RenderBigSquare(location.square, "Start");
        }
    }
}