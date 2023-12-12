using monoos.src.Game;
using monoos.src.Render;
using monoos.src.Render.Interface;
using Raylib_cs;
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

    private Vector2 mousePos;
    private Bill test;
    private BillRender br;

    public MainRender(Settings settings)
    {
        this.setting = settings;
        this.board = new(setting);
    }

    public void init()
    {
        br = new(board);
        board.render.SetBoardParams();
        dices = new(setting);
        players.Add(new("carlos", 1500, Player.PlayerPosition.BOTTOM, board, setting));
        players.Add(new("elDiablo", 1500, Player.PlayerPosition.BOTTOM, board, setting));

        Raylib.SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT);

        Raylib.InitWindow(setting.ScreenWidth, setting.ScreenHeight, "Monooo");

        Raylib.SetTargetFPS(60);
        board.LoadLocationInfo();
        board.LoadTextures();
        test = new Bill(100, Bill.BillType.FIVE, players[0], 100f, 100f);

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
        players.First().isTurn = true;
        br.SpawnStartingBills(players);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.BeginMode2D(camera);
            Raylib.ClearBackground(Color.WHITE);

            board.render.Draw();

            board.RenderLocations();

            br.renderAllBills(players, board.textures);
            mousePos = Raylib.GetMousePosition();

            Vector2 delta = Vector2.Subtract(prevMousePos, mousePos);
            prevMousePos = mousePos;

            Vector2 mousePosition = Raylib.GetScreenToWorld2D(Raylib.GetMousePosition(), camera);
            Raylib.DrawCircleV(mousePosition, 5, Color.BLUE);
            if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
            {
            }

            if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_RIGHT))
            {
                camera.Target = Raylib.GetScreenToWorld2D(Vector2.Add(camera.Offset, delta), camera);
                //camera.Rotation += (delta.X - delta.Y) / 10;
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
                foreach (Bill bill in player.wallet)
                {
                    br.HoldBill(bill, camera);
                }

                Raylib.DrawText($"Current Player:{player.name}", 1700, 500, 20, Color.BLUE);
                Raylib.DrawText($"Current Square:{player.render.CurrentSquare}", 1700, 500, 20, Color.BLUE);
                Raylib.DrawText($"Current Square:{player.render.CurrentSquare}", 1600, 500, 20, Color.BLUE);
                Raylib.DrawText($"Dice  :{dices.DiceNumber1} Dice  : {dices.DiceNumber2}", 1200, 700, 20, Color.BLUE);
                if (firstTime)
                {
                    player.render.GetPosition();
                    firstTime = false;
                }
                else
                { }
                player.render.GoToTargetSquare();

                player.render.RenderPlayer();
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                if (players.Where(x => x.isTurn == true).First().Turn(Player.PlayerAction.BUY_PROPERTY, board, ref camera))
                {
                }

                Raylib.EndMode2D();

                score.DrawPlayerMoney();
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }