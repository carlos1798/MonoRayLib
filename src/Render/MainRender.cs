using monoos.src.Game;
using monoos.src.Game.PropertiesTypes;
using monoos.src.Render;
using Raylib_cs;
using System.Net;
using System.Numerics;

namespace monoos;

public class MainRender
{
    public Settings setting;
    private Board board;
    private List<Player> players = new();
    private bool firstTime = true;
    private Dices dices;

    public MainRender(Settings settings)
    {
        this.setting = settings;
        this.board = new(setting);
    }

    public void init()
    {
        board.render.SetBoardParams();
        dices = new(setting);
        players.Add(new("carlos", 1500, new(setting, board.render)));
        Raylib.InitWindow(setting.ScreenWidth, setting.ScreenHeight, "Monooo");

        Raylib.SetTargetFPS(60);
        board.LoadLocationInfo();
        mainLoop();
    }

    public void mainLoop()
    {
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.DrawFPS(setting.ScreenWidth - 100, setting.ScreenHeight + 100);
            Raylib.ClearBackground(Color.WHITE);
            board.render.Draw();
            board.RenderLocations();

            foreach (Player player in players)
            {
                Raylib.DrawText($"Current Square:{player.render.CurrentSquare}", 1200, 500, 20, Color.BLUE);
                Raylib.DrawText($"Dice  :{dices.DiceNumber1} Dice  : {dices.DiceNumber2}", 1200, 700, 20, Color.BLUE);
                if (firstTime)
                {
                    player.render.GetPosition();
                    firstTime = false;
                }
                else
                {
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {
                        player.Turn(Player.PlayerAction.BUY_PROPERTY, board);
                        dices.RollDices();
                        player.render.SetDiceResult(dices.DiceNumber1 + dices.DiceNumber2);
                    }
                }
                player.render.GoToTargetSquare();

                player.render.RenderPlayer();
            }

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}