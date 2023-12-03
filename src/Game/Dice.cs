using monoos.src.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Game
{
    public class Dices
    {
        private Settings settings;
        private Random Rdice1 = new Random();
        private Random Rdice2 = new Random();

        public bool SameResult = false;
        public int DiceNumber1;
        public int DiceNumber2;

        public Dices(Settings settings)
        {
            this.settings = settings;
        }

        public void RollDices()
        {
            DiceNumber1 = Rdice1.Next(1, 6);
            DiceNumber2 = Rdice2.Next(1, 6);
        }
    }
}