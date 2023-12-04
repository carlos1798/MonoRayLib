using monoos.src.Game;
using monoos.src.Render;

namespace monoos;

public class Game
{
    private Player[] Players;
    private Board Board;
    private Settings settings;

    public Game(Player[] players, Board board, Settings settings)
    {
        Players = players;
        Board = board;
        this.settings = settings;
    }

    public void init()
    {
        Players[0].isTurn = true;
    }

    public void setTurn()
    {
        for (int i = 0; i < Players.Length; i++)
        {
            if (Players[i].isTurn)
            {
                Players[i].isTurn = false;

                if ((i + 1) > Players.Length)
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