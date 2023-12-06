using monoos.src.Game.PropertiesTypes;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Render
{
    public class StreetPropertyRender
    {
        private StreetProperty prop;
        private BoardRectangle location;
        private const double CIProportion = 0.7;

        public StreetPropertyRender(StreetProperty prop, BoardRectangle location)
        {
            this.prop = prop;
            this.location = location;
        }

        public void RedenderLocation()
        {
            if (prop.square <= 9)
            {
                GetBottomColorRectangle().RenderRec();
            }
            else if (prop.square > 10 && prop.square <= 19)
            {
                GetLeftColorRectangle().RenderRec();
            }
            else if (prop.square > 20 && prop.square <= 29)
            {
                GetTopColorRectangle().RenderRec();
            }
            else if (prop.square > 30 && prop.square <= 39)
            {
                GetRightColorRectangle().RenderRec();
            }
        }

        public BoardRectangle GetBottomColorRectangle()
        {
            return new BoardRectangle(location.x, location.y, location.width, (int)(location.height - location.height * CIProportion), Color.RED, 8);
        }

        public BoardRectangle GetLeftColorRectangle()
        {
            return new BoardRectangle(location.x + (int)(location.width * CIProportion), location.y, (int)(location.width - (location.width * CIProportion)), location.height, Color.RED, 8);
        }

        public BoardRectangle GetTopColorRectangle()
        {
            return new BoardRectangle(location.x, location.y + (int)(location.height * CIProportion), location.width, (int)(location.height - location.height * CIProportion), Color.RED, 8);
        }

        public BoardRectangle GetRightColorRectangle()
        {
            return new BoardRectangle(location.x, location.y, (int)(location.width - (location.width * CIProportion)), location.height, Color.RED, 8);
        }

        ////        public BoardRectangle GetColorRectangle()
        //        {
        //            throw NotImplented()
        //        }
    }
}