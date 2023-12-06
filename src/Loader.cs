using monoos.src.Game;
using monoos.src.Render;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src
{
    public class Loader
    {
        private Settings settings;

        private const string PATH = "C:\\Users\\carlos\\repos\\monoos\\src\\Resources\\Default\\Properties.json";

        public Loader(Settings settings)
        {
            this.settings = settings;
        }

        public List<Location> LoadBoardInformation()
        {
            string info = File.ReadAllText(PATH);
            List<Location> locations = JsonConvert.DeserializeObject<List<Location>>(info, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
            return locations;
        }
    }
}