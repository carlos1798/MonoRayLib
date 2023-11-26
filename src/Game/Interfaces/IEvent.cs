using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Game.Interfaces
{
    internal interface IEvent
    {
        void ExecuteEvent(Player player);
    }
}