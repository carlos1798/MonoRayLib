using monoos;
using monoos.src.Game;
using monoos.src.Render;
using monoos.src.Render.LocationRenderers;

public class Board
{
    public BoardRenderer render;
    public List<Location> locations;

    public Board(Settings settings)
    {
        locations = new();
        render = new(settings);
    }

    public List<Location> Locations { get => locations; set => locations = value; }

    public void LoadLocationInfo()
    {
    }

    public Location GetLocationBySquare(int square)
    {
        square = 1;
        return Locations[square];
    }
}