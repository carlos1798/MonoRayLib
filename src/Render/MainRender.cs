﻿using monoos.src.Game;
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
        Camera2D camera = new();
        camera.Target = new Vector2() { X = board.render.Xcenter + setting.OutlineSize * 2, Y = board.render.Ycenter + setting.OutlineSize * 2 };

        camera.Offset = new Vector2() { X = setting.ScreenWidth / 2.0f, Y = setting.ScreenHeight / 2.0f };
        camera.Rotation = 0.0f;
        camera.Zoom = 1.0f;

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.BeginMode2D(camera);
            Raylib.DrawFPS(setting.ScreenWidth - 100, setting.ScreenHeight + 100);
            Raylib.ClearBackground(Color.WHITE);

            board.render.Draw();
            board.RenderLocations();

            // Camera target follows board.render.mainboard

            Raylib.DrawCircle((int)camera.Target.X, (int)camera.Target.Y, 10, Color.RED);
            // Camera rotation controls
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) camera.Rotation--;
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) camera.Rotation++;

            // Limit camera rotation to 80 degrees (-40 to 40)

            // Camera zoom con
            camera.Zoom += ((float)Raylib.GetMouseWheelMove() * 0.05f);

            // Camera reset (zoom and rotation)
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

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}