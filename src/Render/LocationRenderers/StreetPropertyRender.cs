using monoos.src.Game.PropertiesTypes;
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
    public class StreetPropertyRender
    {
        private StreetProperty prop;
        private BoardRectangle location;
        private const double CIProportion = 0.7;
        private const int padding = 5;

        public StreetPropertyRender(StreetProperty prop, BoardRectangle location)
        {
            this.prop = prop;
            this.location = location;
        }

        public string FormatPropertyName(string input)
        {
            var regex = new Regex(@"\b[a-zA-Z]+\b");
            input = input.Replace(" ", "\n");
            var result = regex.Replace(input, m =>
            {
                var word = m.Value;
                if (word.Length > 8)
                {
                    return word.Insert(word.Length - (word.Length - 7), "-\n");
                }
                else
                {
                    return word;
                }
            });
            return result;
        }

        public void RedenderLocation()
        {
            if (prop.square <= 9)
            {
                var propertyUpper = GetBottomColorRectangle();
                propertyUpper.RenderRec();
                var name = FormatPropertyName(prop.name);

                Raylib.DrawText($"{name}",
                                location.x + padding * 2,
                                location.y + propertyUpper.height + padding,
                                Settings.fontSize,
                                Color.BLACK);

                Raylib.DrawText($"{prop.Price}{Settings.currency}",
                                location.x + location.width / 2 - location.Outline,
                                location.y + location.height - padding * 2 - location.Outline,
                                Settings.fontSize,
                                Color.BLACK);
            }
            else if (prop.square > 10 && prop.square <= 19)
            {
                var propertyUpper = GetLeftColorRectangle();
                propertyUpper.RenderRec();
                var name = FormatPropertyName(prop.name);

                Raylib.DrawTextPro(Raylib.GetFontDefault(), $"{name}", new Vector2()
                {
                    X = location.x + (location.width - propertyUpper.width) - padding * 2,

                    Y = location.y + padding * 2
                }, new Vector2()
                {
                    X = 0,
                    Y = 0
                }, 90, Settings.fontSize, 1, Color.BLACK);

                Raylib.DrawTextPro(Raylib.GetFontDefault(), $"{prop.Price}{Settings.currency}", new Vector2()
                {
                    X = location.x + padding * 2 + location.Outline,

                    Y = location.y + location.height / 2 - location.Outline
                }, new Vector2()
                {
                    X = 0,
                    Y = 0
                }, 90, Settings.fontSize, 1, Color.BLACK);
            }
            else if (prop.square > 20 && prop.square <= 29)
            {
                var propertyUpper = GetTopColorRectangle();
                propertyUpper.RenderRec();
                var name = FormatPropertyName(prop.name);

                Raylib.DrawTextPro(Raylib.GetFontDefault(), $"{name}", new Vector2()
                {
                    X = location.x + (location.width / 2) + location.Outline * 2,

                    Y = propertyUpper.y + location.Outline * 2 - padding * 4
                }, new Vector2()
                {
                    X = 0,
                    Y = 0
                }, 180, Settings.fontSize, 1, Color.BLACK);

                Raylib.DrawTextPro(Raylib.GetFontDefault(), $"{prop.Price}{Settings.currency}", new Vector2()
                {
                    X = location.x + (location.width / 2) + location.Outline * 2,

                    Y = location.y + location.Outline + padding * 2
                }, new Vector2()
                {
                    X = 0,
                    Y = 0
                }, 180, Settings.fontSize, 1, Color.BLACK);
            }
            else if (prop.square > 30 && prop.square <= 39)
            {
                var propertyUpper = GetRightColorRectangle();
                propertyUpper.RenderRec();
                var name = FormatPropertyName(prop.name);

                Raylib.DrawTextPro(Raylib.GetFontDefault(), $"{name}", new Vector2()
                {
                    X = location.x + (propertyUpper.width) + location.Outline,

                    Y = location.y + location.width / 2 + location.Outline - padding
                }, new Vector2()
                {
                    X = 0,
                    Y = 0
                }, 270, Settings.fontSize, 1, Color.BLACK);

                Raylib.DrawTextPro(Raylib.GetFontDefault(), $"{prop.Price}{Settings.currency}", new Vector2()
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
            return new BoardRectangle(location.x, location.y, location.width, (int)(location.height - location.height * CIProportion), prop.ColorSet, 8);
        }

        public BoardRectangle GetLeftColorRectangle()
        {
            return new BoardRectangle(location.x + (int)(location.width * CIProportion), location.y, (int)(location.width - (location.width * CIProportion)), location.height, prop.ColorSet, 8);
        }

        public BoardRectangle GetTopColorRectangle()
        {
            return new BoardRectangle(location.x, location.y + (int)(location.height * CIProportion), location.width, (int)(location.height - location.height * CIProportion), prop.ColorSet, 8);
        }

        public BoardRectangle GetRightColorRectangle()
        {
            return new BoardRectangle(location.x, location.y, (int)(location.width - (location.width * CIProportion)), location.height, prop.ColorSet, 8);
        }

        ////        public BoardRectangle GetColorRectangle()
        //        {
        //            throw NotImplented()
        //        }
    }
}