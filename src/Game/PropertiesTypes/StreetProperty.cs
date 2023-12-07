using monoos.src.Game.Interfaces;
using monoos.src.Render;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Game.PropertiesTypes
{
    public class StreetProperty(string name, int square) : PropertyLocation(name, square), IProperty
    {
        private List<Building> Buildings = new();
        private int housecost;
        private int rentFullColorSet;
        private int rent1H;
        private int rent2H;
        private int rent3H;
        private int rent4H;
        private int rentH;
        private Color colorSet;

        public int Housecost { get => housecost; set => housecost = value; }
        public int RentFullColorSet { get => rentFullColorSet; set => rentFullColorSet = value; }
        public int Rent1H { get => rent1H; set => rent1H = value; }
        public int Rent2H { get => rent2H; set => rent2H = value; }
        public int Rent3H { get => rent3H; set => rent3H = value; }
        public int Rent4H { get => rent4H; set => rent4H = value; }
        public int RentH { get => rentH; set => rentH = value; }
        public Color ColorSet { get => colorSet; set => colorSet = value; }

        public override void BuyProperty(Player player)
        {
            throw new NotImplementedException();
        }

        public override void Execute(Player player)
        {
            throw new NotImplementedException();
        }

        public override void LocationRender(Board board)
        {
            new StreetPropertyRender(this, board.render.Squares[square], board.textures).RenderLocation();
        }

        public override void PayRent(Player player)
        {
            throw new NotImplementedException();
        }
    }
}