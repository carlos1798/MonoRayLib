using monoos.src.Render;
using Raylib_cs;
using System.Numerics;

namespace monoos.src.Game
{
    public class Bill
    {
        public int id;
        public BillType type;
        public string spriteName;
        public Player owner;
        public Vector2 position;
        public Rectangle rec;
        public Vector2 startPoint = new() { X = 30, Y = 30 };
        public Vector2 endPoint = new() { X = (float)Settings.BoardWidth - 30, Y = (float)Settings.BoardHeight - 30 };
        public bool moveStartPoint = false;
        public bool moveEndPoint = false;
        public Texture2D texture;

        public Bill(int id, BillType type, Player owner, float x, float y)
        {
            this.id = id;
            this.type = type;
            this.spriteName = getSpriteName(type);
            this.owner = owner;
            rec = new(x, y, 200f, 100f);
        }

        private string? getSpriteName(BillType type)
        {
            return $"{((int)type)}Bill";
        }

        public enum BillType
        {
            ONE = 1,
            FIVE = 5,
            TEN = 10,
            TWENTY = 20,
            FIFTY = 50,
            HUNDRED = 100,
            FIVE_HUNDRED = 500
        }
    }
}