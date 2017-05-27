using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgBasedDiagramMaker
{
    class Diagram
    {
        // propertis
        public Point leftTop { get; set; }
        public Point rightTop { get; set; }
        public Point leftBottom { get; set; }
        public Point rightBottom { get; set; }
        public List<Rectangle> pinRects { get; set; }


        public bool isImgDiagram { get; set; }
        public bool isUpdateStage { get; set; }
        public string imageUrl { get; set; }

        public Diagram()
        {
            pinRects = new List<Rectangle>();
            isUpdateStage = false;
        }

        public Rectangle getRect()
        {
            return new Rectangle(leftTop.X, leftTop.Y,
                                 rightTop.X - leftTop.X, rightBottom.Y - rightTop.Y);
        }

        public bool contains(Point p)
        {
            Rectangle boundingBox = new Rectangle(leftTop.X, leftTop.Y, 
                                                  rightTop.X - leftTop.X, rightBottom.Y - rightTop.Y);
            if (boundingBox.Contains(p))
                return true;
            else
                return false;
        }

        public void createPins()
        {
            for(int pinIndex = 0; pinIndex < 8; pinIndex++)
            {
                Point center = Point.Empty;
                Rectangle res = Rectangle.Empty;

                Rectangle dRect = this.getRect();

                if (pinIndex == 0)
                    center = new Point(dRect.Left, dRect.Top);
                else if (pinIndex == 1)
                    center = new Point(dRect.Left, dRect.Top + (dRect.Height / 2));
                else if (pinIndex == 2)
                    center = new Point(dRect.Left, dRect.Bottom);
                else if (pinIndex == 3)
                    center = new Point(dRect.Left + (dRect.Width / 2), dRect.Top);
                else if (pinIndex == 4)
                    center = new Point(dRect.Left + (dRect.Width / 2), dRect.Bottom);
                else if (pinIndex == 5)
                    center = new Point(dRect.Right, dRect.Top);
                else if (pinIndex == 6)
                    center = new Point(dRect.Right, dRect.Top + (dRect.Height / 2));
                else if (pinIndex == 7)
                    center = new Point(dRect.Right, dRect.Bottom);

                center.Offset(-2, -2);
                Rectangle r = new Rectangle(center, new Size(5, 5));
                pinRects.Add(r);
            }
        }

        public Rectangle getPinRect(int pinIndex)
        {
            return pinRects[pinIndex];
        }
    }

}
