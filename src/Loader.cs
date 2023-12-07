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
        private const string PATH_SPECIAL = "C:\\Users\\carlos\\repos\\monoos\\src\\Resources\\Default\\SpecialSquares.json";

        public Loader(Settings settings)
        {
            this.settings = settings;
        }

        public List<Location> LoadBoardInformation()
        {
            string propInfo = File.ReadAllText(PATH);
            try
            {
                List<Location> propLocations = JsonConvert.DeserializeObject<List<Location>>(propInfo, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });
                string speInfo = File.ReadAllText(PATH_SPECIAL);
                List<Location> speLoc = JsonConvert.DeserializeObject<List<Location>>(speInfo, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

                propLocations.AddRange(speLoc);

                return propLocations;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}