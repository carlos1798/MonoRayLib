using monoos.src.Game.Interfaces;
using monoos.src.Render;
using System.Transactions;

namespace monoos.src.Game
{
    public class Player
    {
        private string name;
        private double money;
        public List<IProperty> properties;
        private PlayerRender render;
        public bool isTurn = false;
        public Dices dices;
        public bool Bankrupt = false;

        public Player(string name, double money, List<IProperty> properties, PlayerRender render)
        {
            this.name = name;
            this.money = 1500;
            this.properties = new();
            this.render = render;
        }
    }
}