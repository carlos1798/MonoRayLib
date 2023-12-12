namespace monoos.src.Game.Interfaces
{
    public interface IProperty
    {
        void Execute(Player player);

        void BuyProperty(Player player);

        void PayRent(Player player);
    }
}