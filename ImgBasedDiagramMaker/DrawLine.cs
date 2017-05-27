using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgBasedDiagramMaker
{
    class DrawLine
    {
        public List<Line> Lines { get; set; }
        public Line Selectline { get; set; }
        public moveline Moveline_instance { get; set; }

        public DrawLine()
        {
            Lines = new List<Line>();
            Selectline = new Line();
            Moveline_instance = new moveline();
        }
    }
}
