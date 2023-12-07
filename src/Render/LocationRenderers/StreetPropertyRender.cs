using monoos.src.Game.PropertiesTypes;
using monoos.src.Render.BaseRenders;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace monoos.src.Render
{
    public class StreetPropertyRender : ConcreteRender<StreetProperty>
    {
        private const double CIProportion = 0.7;
        private const int padding = 5;
        private string name;

        public StreetPropertyRender(StreetProperty property, BoardRectangle br) : base(property, br)
        {
        }

        public override void RenderLocation()
        {
            name = FormatName(property.name);
            if (property.square <= 9)
            {
                var propertyUpper = GetBottomColorRectangle();
                propertyUpper.RenderRec();

                Raylib.DrawText($"{name}",
                                location.x + padding * 2,
                                location.y + propertyUpper.height + padding,
                                Settings.fontSize,
                                Color.BLACK);

                Raylib.DrawText($"{property.Price}{Settings.currency}",
                                location.x + location.width / 2 - location.Outline,
                                location.y + location.height - padding * 2 - location.Outline,
                                Settings.fontSize,
                                Color.BLACK);
            }
            else if (property.square > 10 && property.square <= 19)
            {
                var propertyUpper = GetLeftColorRectangle();
                propertyUpper.RenderRec();

                Raylib.DrawTextPro(Raylib.GetFontDefault(), $"{name}", new Vector2()
                {
                    X = location.x + (location.width - propertyUpper.width) - padding * 2,

                    Y = location.y + padding * 2
                }, new Vector2()
                {
                    X = 0,
                    Y = 0
                }, 90, Settings.fontSize, 1, Color.BLACK);

                Raylib.DrawTextPro(Raylib.GetFontDefault(), $"{property.Price}{Settings.currency}", new Vector2()
                {
                    X = location.x + padding * 2 + location.Outline,

                    Y = location.y + location.height / 2 - location.Outline
                }, new Vector2()
                {
                    X = 0,
                    Y = 0
                }, 90, Settings.fontSize, 1, Color.BLACK);
            }
            else if (property.square > 20 && property.square <= 29)
            {
                var propertyUpper = GetTopColorRectangle();
                propertyUpper.RenderRec();

                Raylib.DrawTextPro(Raylib.GetFontDefault(), $"{name}", new Vector2()
                {
                    X = location.x + (location.width / 2) + location.Outline * 2,

                    Y = propertyUpper.y + location.Outline * 2 - padding * 4
                }, new Vector2()
                {
                    X = 0,
                    Y = 0
                }, 180, Settings.fontSize, 1, Color.BLACK);

                Raylib.DrawTextPro(Raylib.GetFontDefault(), $"{property.Price}{Settings.currency}", new Vector2()
                {
                    X = location.x + (location.width / 2) + location.Outline * 2,

                    Y = location.y + location.Outline + padding * 2
                }, new Vector2()
                {
                    X = 0,
                    Y = 0
                }, 180, Settings.fontSize, 1, Color.BLACK);
            }
            else if (property.square > 30 && property.square <= 39)
            {
                var propertyUpper = GetRightColorRectangle();
                propertyUpper.RenderRec();

                Raylib.DrawTextPro(Raylib.GetFontDefault(), $"{name}", new Vector2()
                {
                    X = location.x + (propertyUpper.width) + location.Outline,

                    Y = location.y + location.width / 2 + location.Outline - padding
                }, new Vector2()
                {
                    X = 0,
                    Y = 0
                }, 270, Settings.fontSize, 1, Color.BLACK);

                Raylib.DrawTextPro(Raylib.GetFontDefault(), $"{property.Price}{Settings.currency}", new Vector2()
                {
                    X = location.x + location.width - padding * 2 - location.Outline,

                    Y = location.y + location.width / 2 - location.Outline - padding * 2
                }, new Vector2()
                {
                    X = 0,
                    Y = 0
                }, 270, Settings.fontSize, 1, Color.BLACK);
            }
        }

        public BoardRectangle GetBottomColorRectangle()
        {
            return new BoardRectangle(location.x, location.y, location.width, (int)(location.height - location.height * CIProportion), property.ColorSet, 8);
        }

        public BoardRectangle GetLeftColorRectangle()
        {
            return new BoardRectangle(location.x + (int)(location.width * CIProportion), location.y, (int)(location.width - (location.width * CIProportion)), location.height, property.ColorSet, 8);
        }

        public BoardRectangle GetTopColorRectangle()
        {
            return new BoardRectangle(location.x, location.y + (int)(location.height * CIProportion), location.width, (int)(location.height - location.height * CIProportion), property.ColorSet, 8);
        }

        public BoardRectangle GetRightColorRectangle()
        {
            return new BoardRectangle(location.x, location.y, (int)(location.width - (location.width * CIProportion)), location.height, property.ColorSet, 8);
        }
    }
}