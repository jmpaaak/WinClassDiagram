using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgBasedDiagramMaker
{
    class Line
    {
        public Point Start { get; set; }
        public Point End { get; set; }
        public Rectangle Start_boundary { get; set; }
        public Rectangle End_boundary { get; set; }
        public int type { get; set; }
        public int Width = 5;
        public Color Color = Color.Black;
        public bool pin_visible = false;
    }
}
