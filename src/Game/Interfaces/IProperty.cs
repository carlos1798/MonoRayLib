using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace monoos.src.Game.Interfaces
{
    internal interface IProperty
    {
        void Execute(Player player);

        void BuyProperty(Player player);

        void PayRent(Player player);
    }
}