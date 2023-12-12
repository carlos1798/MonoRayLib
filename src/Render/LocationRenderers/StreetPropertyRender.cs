using monoos.src.Game.PropertiesTypes;
using monoos.src.Render.BaseRenders;
using Raylib_cs;
using System.Numerics;

namespace monoos.src.Render
{
    public class StreetPropertyRender(StreetProperty property, BoardRectangle renderLocation, Dictionary<string, Texture2D> textures) : ConcreteRender<StreetProperty>(property, renderLocation, textures)
    {
        private const double CIProportion = 0.7;
        private const int padding = 5;
        private string name;

        public override void RenderLocation()
        {
            name = FormatName(property.name);
            if (property.square <= 9)
            {
                var propertyUpper = GetBottomColorRectangle();
                propertyUpper.RenderRec();

                Raylib.DrawText($"{name}",
                                renderLocation.x + padding * 2,
                                renderLocation.y + propertyUpper.height + padding,
                                Settings.fontSize,
                                Color.BLACK);

                Raylib.DrawText($"{property.Price}{Settings.currency}",
                                renderLocation.x + renderLocation.width / 2 - renderLocation.Outline,
                                renderLocation.y + renderLocation.height - padding * 2 - renderLocation.Outline,
                                Settings.fontSize,
                                Color.BLACK);
            }
            else if (property.square > 10 && property.square <= 19)
            {
                var propertyUpper = GetLeftColorRectangle();
                propertyUpper.RenderRec();

                Raylib.DrawTextPro(Raylib.GetFontDefault(), $"{name}", new Vector2()
                {
                    X = renderLocation.x + (renderLocation.width - propertyUpper.width) - padding * 2,

                    Y = renderLocation.y + padding * 2
                }, new Vector2()
                {
                    X = 0,
                    Y = 0
                }, 90, Settings.fontSize, 1, Color.BLACK);

                Raylib.DrawTextPro(Raylib.GetFontDefault(), $"{property.Price}{Settings.currency}", new Vector2()
                {
                    X = renderLocation.x + padding * 2 + renderLocation.Outline,

                    Y = renderLocation.y + renderLocation.height / 2 - renderLocation.Outline
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
                    X = renderLocation.x + (renderLocation.width / 2) + renderLocation.Outline * 2,

                    Y = propertyUpper.y + renderLocation.Outline * 2 - padding * 4
                }, new Vector2()
                {
                    X = 0,
                    Y = 0
                }, 180, Settings.fontSize, 1, Color.BLACK);

                Raylib.DrawTextPro(Raylib.GetFontDefault(), $"{property.Price}{Settings.currency}", new Vector2()
                {
                    X = renderLocation.x + (renderLocation.width / 2) + renderLocation.Outline * 2,

                    Y = renderLocation.y + renderLocation.Outline + padding * 2
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
                    X = renderLocation.x + (propertyUpper.width) + renderLocation.Outline,

                    Y = renderLocation.y + renderLocation.width / 2 + renderLocation.Outline - padding
                }, new Vector2()
                {
                    X = 0,
                    Y = 0
                }, 270, Settings.fontSize, 1, Color.BLACK);

                Raylib.DrawTextPro(Raylib.GetFontDefault(), $"{property.Price}{Settings.currency}", new Vector2()
                {
                    X = renderLocation.x + renderLocation.width - padding * 2 - renderLocation.Outline,

                    Y = renderLocation.y + renderLocation.width / 2 - renderLocation.Outline - padding * 2
                }, new Vector2()
                {
                    X = 0,
                    Y = 0
                }, 270, Settings.fontSize, 1, Color.BLACK);
            }
        }

        public BoardRectangle GetBottomColorRectangle()
        {
            return new BoardRectangle(renderLocation.x, renderLocation.y, renderLocation.width, (int)(renderLocation.height - renderLocation.height * CIProportion), property.ColorSet, 8);
        }

        public BoardRectangle GetLeftColorRectangle()
        {
            return new BoardRectangle(renderLocation.x + (int)(renderLocation.width * CIProportion), renderLocation.y, (int)(renderLocation.width - (renderLocation.width * CIProportion)), renderLocation.height, property.ColorSet, 8);
        }

        public BoardRectangle GetTopColorRectangle()
        {
            return new BoardRectangle(renderLocation.x, renderLocation.y + (int)(renderLocation.height * CIProportion), renderLocation.width, (int)(renderLocation.height - renderLocation.height * CIProportion), property.ColorSet, 8);
        }

        public BoardRectangle GetRightColorRectangle()
        {
            return new BoardRectangle(renderLocation.x, renderLocation.y, (int)(renderLocation.width - (renderLocation.width * CIProportion)), renderLocation.height, property.ColorSet, 8);
        }
    }
}