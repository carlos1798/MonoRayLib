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

        setLocations();
        mainLoop();
    }

    public void setLocations()
    {
        StreetProperty streetProperty = new("Calle Baja", 1, 100, false, 20);
        streetProperty.Housecost = 50000;
        streetProperty.RentFullColorSet = 500;
        streetProperty.Rent1H = 200;
        streetProperty.Rent2H = 300;
        streetProperty.Rent3H = 400;
        streetProperty.Rent4H = 500;
        streetProperty.RentH = 600;
        streetProperty.ColorSet = Color.RED;

        RailRoadProperty delicias = new("Calle Baja", 1, 100, false, 20);
        delicias.Rent2 = 300;
        delicias.Rent3 = 400;
        delicias.RentFullSet = 500;
        delicias.square = 5;
        board.locations.Add(streetProperty);
        board.locations.Add(delicias);
    }

    public void mainLoop()
    {
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.SetTargetFPS(60);

            Raylib.ClearBackground(Color.WHITE);
            board.render.Draw();

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