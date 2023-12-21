using monoos.src.Game;
using monoos.src.Render;

namespace monoos;

public class GameFlow(List<Player> players, Board board, Settings settings)
{
    private List<Player> Players = players;
    private Board Board = board;
    private Settings settings = settings;

    public void init()
    {
        Players[0].isTurn = true;
    }

    public void setTurn()
    {
        for (int i = 0; i < Players.Count; i++)
        {
            if (Players[i].isTurn)
            {
                Players[i].isTurn = false;

                if ((i + 1) >= Players.Count)
                {
                    Players[0].isTurn = true;
                    return;
                }
                Players[i + 1].isTurn = true;
                return;
            }
        }
    }
}