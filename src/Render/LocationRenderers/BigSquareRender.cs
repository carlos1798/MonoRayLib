using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoos.src.Render.LocationRenderers
{
    internal class BigSquareRender
    {
        private Settings settings { get; set; }
        private BoardRenderer board { get; set; }

        public BigSquareRender(Settings settings, BoardRenderer board)
        {
            this.settings = settings;
            this.board = board;
        }

        public void RenderFirst()
        {
        }
    }
}