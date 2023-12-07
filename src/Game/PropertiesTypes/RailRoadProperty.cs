using monoos.src.Game.Interfaces;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Game.PropertiesTypes
{
    public class RailRoadProperty : PropertyLocation, IProperty
    {
        private int rentFullSet;
        private int rent2;
        private int rent3;

        public int Rent2 { get => rent2; set => rent2 = value; }
        public int Rent3 { get => rent3; set => rent3 = value; }
        public int RentFullSet { get => rentFullSet; set => rentFullSet = 200; }

        public RailRoadProperty(string name, int square) : base(name, square)
        {
        }

        public override void BuyProperty(Player player)
        {
            throw new NotImplementedException();
        }

        public override void Execute(Player player)
        {
            throw new NotImplementedException();
        }

        public override void PayRent(Player player)
        {
            throw new NotImplementedException();
        }

        public override void LocationRender(Board board)
        {
            new RailRoadPropertyRender(this, board.render.Squares[square]).RenderLocation();
        }
    }
}