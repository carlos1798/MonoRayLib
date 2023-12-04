using monoos.src.Game.Interfaces;
using monoos.src.Game.PropertiesTypes;
using monoos.src.Render;
using System.Transactions;

namespace monoos.src.Game
{
    public class Player
    {
        public enum PlayerAction
        {
            BUY_PROPERTY,
            ROLL_DICE,
            BUY_BUILDING
        }

        private string name;
        private double money;
        public List<IProperty> properties;
        public PlayerRender render;
        public bool isTurn = false;
        public Dices dices;
        public bool Bankrupt = false;

        public Player(string name, double money, PlayerRender render)
        {
            this.name = name;
            this.money = 1500;
            this.properties = new();
            this.render = render;
            properties = new();
        }

        public void Turn(PlayerAction action, Board board)
        {
            //if (!this.isTurn)
            //{
            //    return;
            //}
            switch (action)
            {
                case PlayerAction.BUY_PROPERTY:

                    if (board.GetLocationBySquare(render.CurrentSquare) is PropertyLocation)
                    {
                        var Property = (PropertyLocation)board.GetLocationBySquare(render.CurrentSquare);
                        if (Property.owner is null)
                        {
                            Console.WriteLine("comprable");
                            Property.BuyProperty(this);
                        }
                    }; break;

                default:
                    break;
            }
        }
    }
}