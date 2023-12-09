using monoos.src.Game;
using monoos.src.Game.PropertiesTypes;
using monoos.src.Render;
using monoos.src.Render.Interface;
using Raylib_cs;
using System;
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
    private int cameraSpeed = 10;
    private PlayerScore score = new();

    private BillRender br = new BillRender();

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
        Raylib.SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT);

        Raylib.InitWindow(setting.ScreenWidth, setting.ScreenHeight, "Monooo");

        Raylib.SetTargetFPS(60);
        board.LoadLocationInfo();
        board.LoadTextures();
        mainLoop();
    }

    public void mainLoop()
    {
        Camera2D camera = new();
        camera.Target = new Vector2() { X = board.render.Xcenter + setting.OutlineSize * 2, Y = board.render.Ycenter + setting.OutlineSize * 4 };

        camera.Offset = new Vector2() { X = setting.ScreenWidth / 2.0f, Y = setting.ScreenHeight / 2.0f };
        camera.Rotation = 0.0f;
        camera.Zoom = 1.0f;
        Vector2 prevMousePos = Raylib.GetMousePosition();

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.BeginMode2D(camera);
            Raylib.DrawFPS(setting.ScreenWidth - 100, setting.ScreenHeight + 100);
            Raylib.ClearBackground(Color.WHITE);

            board.render.Draw();

            board.RenderLocations();
            br.renderBill(board.textures, "500Bill", 100, 100, 0);
            br.renderBill(board.textures, "100Bill", 100, 200, 0);
            br.renderBill(board.textures, "50Bill", 100, 300, 0);
            br.renderBill(board.textures, "20Bill", 100, 400, 0);
            br.renderBill(board.textures, "5Bill", 100, 500, 0);
            br.renderBill(board.textures, "1Bill", 100, 600, 0);

            Vector2 thisPos = Raylib.GetMousePosition();

            Vector2 delta = Vector2.Subtract(prevMousePos, thisPos);
            prevMousePos = thisPos;

            if (Raylib.IsMouseButtonDown(0))
            {
                camera.Target = Raylib.GetScreenToWorld2D(Vector2.Add(camera.Offset, delta), camera);
            }

            if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_RIGHT))
            {
                camera.Rotation += (delta.X - delta.Y) / 10;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_Q)) camera.Rotation--;
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_E)) camera.Rotation++;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) camera.Target.X -= cameraSpeed;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) camera.Target.X += cameraSpeed;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) camera.Target.Y -= cameraSpeed;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) camera.Target.Y += cameraSpeed;
            camera.Zoom += ((float)Raylib.GetMouseWheelMove() * 0.05f);

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_R))
            {
                camera.Zoom = 1.0f;
                camera.Rotation = 1000.0f;
            }

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
            Raylib.EndMode2D();

            score.DrawPlayerMoney();
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}