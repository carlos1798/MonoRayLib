using monoos.src.Game.Interfaces;

namespace monoos.src.Game.EventLocations
{
    public abstract class EventLocation : Location, IEvent
    {
        public EventLocation(string name, int square) : base(name, square)
        {
        }

        public abstract void ExecuteEvent(Player player);
    }
}