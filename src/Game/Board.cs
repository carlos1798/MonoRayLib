using monoos;
using monoos.src;
using monoos.src.Game;
using monoos.src.Render;
using monoos.src.Render.LocationRenderers;

public class Board
{
    public BoardRenderer render;
    public List<Location> locations;
    public Loader loader;
    public Settings settings;

    public Board(Settings settings)
    {
        locations = new();
        render = new(settings);
    }

    public void LoadLocationInfo()
    {
        loader = new(settings);
        locations = loader.LoadBoardInformation();
    }

    public Location GetLocationBySquare(int square)
    {
        return locations[square];
    }

    public void RenderLocations()
    {
        foreach (Location location in locations)
        {
            location.LocationRender(this);
        }
    }
}