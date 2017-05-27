using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace ImgBasedDiagramMaker
{
    public partial class FormMain : Form
    {
        public FormMain(string path)
        {
            InitializeComponent();
            
            if(path=="")
            {
                tempGraphics = this.panelCanvas.CreateGraphics();
                curDiagram = new Diagram();
                stageWait = true;
            } else
            {
                Console.WriteLine("FormMain");
                tempGraphics = this.panelCanvas.CreateGraphics();            
                curDiagram = new Diagram();
                stageWait = true;
                openFileRead(path);
            }
        }

        private void openFileSave(string path)
        {

          

            System.IO.StreamWriter file = new System.IO.StreamWriter(path);
            int nr_list = diagrams.Count;
            file.WriteLine(nr_list.ToString());
            for (int i = 0; i < nr_list; i++)
            {
                Diagram di = diagrams[i];
                if (di.isImgDiagram)
                {
                    file.WriteLine("1");
                    file.WriteLine(di.imageUrl);
                }
                else file.WriteLine("2");

                file.WriteLine(Convert.ToString(di.leftTop.X));
                file.WriteLine(Convert.ToString(di.leftTop.Y));
                file.WriteLine(Convert.ToString(di.rightTop.X));
                file.WriteLine(Convert.ToString(di.rightTop.Y));
                file.WriteLine(Convert.ToString(di.leftBottom.X));
                file.WriteLine(Convert.ToString(di.leftBottom.Y));
                file.WriteLine(Convert.ToString(di.rightBottom.X));
                file.WriteLine(Convert.ToString(di.rightBottom.Y));
                Console.WriteLine(Convert.ToString(di.rightBottom.Y));
            }

            file.Close();
        }

        private void openFileRead(string path)
        {
            Console.WriteLine(path);
            Point leftT = new Point();  Point rightT = new Point();
            Point leftB = new Point();  Point rightB = new Point();
            string url = "";
            System.IO.StreamReader rd = new System.IO.StreamReader(path);
            int nr_class = Int32.Parse(rd.ReadLine());
            Console.WriteLine(Convert.ToString(nr_class));
            for (int i=0; i<nr_class; i++)
            {
                int type = Int32.Parse(rd.ReadLine());
                if(type == 1) // IMG 
                {
                    url = rd.ReadLine();
                }
                leftT.X = Int32.Parse(rd.ReadLine());
                leftT.Y = Int32.Parse(rd.ReadLine());
                rightT.X = Int32.Parse(rd.ReadLine());
                rightT.Y = Int32.Parse(rd.ReadLine());
                leftB.X = Int32.Parse(rd.ReadLine());
                leftB.Y = Int32.Parse(rd.ReadLine());
                rightB.X = Int32.Parse(rd.ReadLine());
                rightB.Y = Int32.Parse(rd.ReadLine());
                Console.WriteLine(Convert.ToString(rightB.Y));
                if(type==1)
                {
                    addMovableImgDiagram(url);
                    addCurDiagramToList(leftT, rightT, leftB, rightB);
                    Console.WriteLine(Convert.ToString("IMG"));

                } else if( type ==2)
                {
                    addMovableRectDiagram();
                    addCurDiagramToList(leftT, rightT, leftB, rightB);
                    Console.WriteLine(Convert.ToString("NOIMG"));
                }
            }
            reDraw(null);
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* proprocess */

           


            OpenFileDialog ofd = new OpenFileDialog();

            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                openFileRead(ofd.FileName);                               
            }
        }

        private void 새창열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            /*
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                Process.Start("ImgBasedDiagramMaker.exe", ofd.FileName);
            }
            */
            Process.Start("ImgBasedDiagramMaker.exe", "");
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "다른 이름으로 저장";
            sfd.DefaultExt = "dia";
            sfd.Filter = "Diagram File(*.dia)|*.dia";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                openFileSave(sfd.FileName);
             
            }
        }

        private void 이미지기반ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {

                string fileName = ofd.FileName.ToString();
                
                //Console.WriteLine(ofd.SafeFileName.ToString());
               addMovableImgDiagram(fileName);
             
            }
        }

        private void 이미지로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "다른 이름으로 저장";
            sfd.Filter = "Bitmap File(*.bmp)|*.bmp|" + "Gif File(*.gif)|*.gif|" + "JPEG File(*.jpg)|*.jpg|" + "PNG File(*.png)|*.png";



            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string fileName = sfd.FileName;
                Pen blackPen = new Pen(Color.Black, 3);
                // Rectangle rect = new Rectangle(0, 0, 2000, 2000);

                Bitmap b = new Bitmap(1000, 800);
                Graphics g = Graphics.FromImage(b);
                g.Clear(Color.White);
                for (int i = 0; i < diagrams.Count; i++)
                {
                    // draw classes
                    Rectangle tempRect = diagrams[i].getRect();

                    Console.WriteLine(Convert.ToString(tempRect.X));
                    Console.WriteLine(Convert.ToString(tempRect.Y));
                    if (diagrams[i].isImgDiagram)
                    {
                        Image img = Image.FromFile(diagrams[i].imageUrl);

                        bmpImg = new Bitmap(img, tempRect.Width, tempRect.Height);

                        g.DrawImage(bmpImg, tempRect.X, tempRect.Y);
                    }
                    else
                    {

                        g.DrawRectangle(penRect, tempRect);
                    }
                }

                string strFilExtn = fileName.Remove(0, fileName.Length - 3);
                switch (strFilExtn)
                {
                    case "bmp": b.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp); break;
                    case "jpg": b.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                    case "gif": b.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif); break;
                    case "tif": b.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff); break;
                    case "png": b.Save(fileName, System.Drawing.Imaging.ImageFormat.Png); break;
                    default: break;
                }


                // g.DrawRectangle(blackPen,rect);
                //b.Save(path, System.Drawing.Imaging.ImageFormat.Gif);
                MessageBox.Show(fileName);

            }

        }

        private void 일반사각형ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addMovableRectDiagram();
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /**************************************************************************************************/
        /**************************************************************************************************/
        /**************************************************************************************************/



        /** stage variables **/
        bool stageAdd = false;      // moving diagram for adding
        bool stageWait = false;     // waiting long click in diagram
        bool stageUpdate = false;   // Updating with Pins

        List<Diagram> diagrams = new List<Diagram>();
        List<Graphics> gPins = new List<Graphics>();
        Diagram curDiagram = new Diagram();

        int initImgW = 50;
        int initImgH = 50;

        Pen penRect = new Pen(Color.Black, 3);
        Bitmap bmpImg;

        Graphics tempGraphics = null;     // temp Grapics

        Timer timerForLongClick = new Timer(); // for waiting stage
        int updateCandidateIndex = -1;            // for waiting stage

        int draggedPinIndex = -1;
        int resizableDiagramIndex = -1;
        Rectangle rectOld = new Rectangle();
        Rectangle rectUpdated = new Rectangle();

        Point tempPos = new Point(); // only used for movable updating
        bool dragFlag = false;


        // 주어진 url에 따라 Image Diagram이 마우스를 따라다님
        private void addMovableImgDiagram(string url)
        {
            Image img = Image.FromFile(url); // ../../ -> prject root dir 
            bmpImg = new Bitmap(img, initImgW, initImgH);

            tempGraphics = this.panelCanvas.CreateGraphics();

            curDiagram.isImgDiagram = true;
            curDiagram.imageUrl = url;

            stageAdd = true; // start of add stage
        }

        // Rect Diagram이 마우스를 따라다님
        private void addMovableRectDiagram()
        {
            tempGraphics = this.panelCanvas.CreateGraphics();

            stageAdd = true; // start of add stage
        }

        private void addCurDiagramToList(Point lt, Point rt, Point lb, Point rb)
        {
            curDiagram.leftTop = lt;
            curDiagram.rightTop = rt;
            curDiagram.leftBottom = lb;
            curDiagram.rightBottom= rb;
            TextBox new_class_name = new TextBox();
            stageAdd = false; // end of add stage 
            stageWait = true;
            diagrams.Add(curDiagram);
            curDiagram.createPins(); // this line must be next to set lt, rt, lb, rb
            curDiagram = new Diagram(); // init for waiting next Diagram
        }



        /** Event callbacks **/

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (stageAdd) // adding stage
            {
                addCurDiagramToList(new Point(e.X, e.Y),
                                    new Point(e.X + initImgW, e.Y),
                                    new Point(e.X, e.Y + initImgH),
                                    new Point(e.X + initImgW, e.Y + initImgH));

                stageAdd = false;
            }
            else if (stageWait || stageUpdate)     // wait or update stage
            {
                
                for (int i = 0; i < diagrams.Count; i++)
                {
                    if (diagrams[i].contains(e.Location))
                    {
                        if (!diagrams[i].isUpdateStage)
                        {
                            System.Console.WriteLine("diagram clicked!");
                            updateCandidateIndex = i; // set candidate of updating diagram
                            timerForLongClick.Interval = 500;
                            timerForLongClick.Start();
                            tempPos = new Point(e.X, e.Y); // only
                            timerForLongClick.Tick += new EventHandler(goToUpdateStage);

                            draggedPinIndex = -1;
                            break; // BREAK for waiting upcoming update stage
                        }
                        else
                        {
                            for (int k = 0; k < 8; k++)
                            {
                                System.Console.WriteLine(diagrams[i].getPinRect(k).X+" "+ diagrams[i].getPinRect(k).Y+ " getpin!! k: "+k);

                                // if e.Location in Pin Rect, find Pin index and save current rect to OLD
                                if (diagrams[i].getPinRect(k).Contains(e.Location))
                                {
                                    System.Console.WriteLine(" resize!!");

                                    resizableDiagramIndex = i;
                                    draggedPinIndex = k;
                                    rectOld = diagrams[i].getRect();

                                    break;
                                }

                                resizableDiagramIndex = -1;
                                draggedPinIndex = -1;

                                //if (k == 7) return; // return for doing next with updating stage diagram
                                                    // updating stage diagram must be continued in Mouse Move Event Callback
                            }
                        }
                    }
                }


                /* click event for OUT OF diagrams (background click event) */
                for (int i = 0; i < diagrams.Count; i++)
                {
                    // updated stage TO waiting stage
                    if (stageUpdate && resizableDiagramIndex == -1)
                    {
                        System.Console.WriteLine(" int change!!");

                        stageWait = true;  // start of wait stage
                        stageUpdate = false; // end of update stage

                        // for removing Pins
                        if (!diagrams[i].contains(e.Location))
                            diagrams[i].isUpdateStage = false;

                        this.reDraw(null);
                    }
                }

            } // end of else if stageWait || stageUpdate
        }

        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!stageAdd)
            {
                draggedPinIndex = -1;
                dragFlag = false; // release drag
                timerForLongClick.Stop();
                timerForLongClick = new Timer(); // reset timer
            }
        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(stageAdd)
            {
                reDraw(e);
            }
            else if(stageUpdate)
            {
                // drag event for movable 
                if(dragFlag && (draggedPinIndex < 0))
                {
                    int diffX = rectOld.X - e.Location.X;
                    int diffY = rectOld.Y - e.Location.Y;
                    rectUpdated = new Rectangle(rectOld.Left - diffX - rectOld.Width/2, 
                                                rectOld.Top - diffY - rectOld.Height/2,
                                                rectOld.Width, rectOld.Height);
                }
                else if (draggedPinIndex == 3)
                {
                    int diffY = rectOld.Y - e.Location.Y;
                    rectUpdated = new Rectangle(rectOld.Left,
                                                rectOld.Top - diffY,
                                                rectOld.Width, rectOld.Height + diffY);
                }
                else if (draggedPinIndex == 1)
                {
                    int diffX = rectOld.X - e.Location.X;
                    rectUpdated = new Rectangle(rectOld.Left - diffX,
                                                rectOld.Top,
                                                rectOld.Width + diffX, rectOld.Height);
                }
                else if (draggedPinIndex == 6)
                {
                    int diffX = rectOld.X - e.Location.X;
                    rectUpdated = new Rectangle(rectOld.Left,
                                                rectOld.Top,
                                                rectOld.Width - diffX - rectOld.Width, rectOld.Height);
                }
                else if (draggedPinIndex == 4)
                {
                    int diffY = rectOld.Y - e.Location.Y;
                    rectUpdated = new Rectangle(rectOld.Left,
                                                rectOld.Top,
                                                rectOld.Width, rectOld.Height - diffY - rectOld.Height);
                }
                else if (draggedPinIndex == 0)
                {
                    int diffX = rectOld.X - e.Location.X;
                    int diffY = rectOld.Y - e.Location.Y;
                    rectUpdated = new Rectangle(e.Location.X,
                                                e.Location.Y,
                                                rectOld.Width + diffX, rectOld.Height + diffY);
                }
                else if (draggedPinIndex == 7)
                {
                    int diffX = rectOld.X - e.Location.X;
                    int diffY = rectOld.Y - e.Location.Y;
                    rectUpdated = new Rectangle(rectOld.X,
                                                rectOld.Y,
                                                + e.Location.X - rectOld.X, - rectOld.Y + e.Location.Y);
                }
                else if (draggedPinIndex == 2)
                {
                    int diffX = rectOld.X - e.Location.X;
                    int diffY = rectOld.Y - e.Location.Y;
                    rectUpdated = new Rectangle(e.Location.X,
                                                e.Location.Y - rectOld.Height + diffY,
                                                rectOld.Width + diffX, rectOld.Height - diffY);
                }
                else if (draggedPinIndex == 5)
                {
                    int diffX = rectOld.X - e.Location.X;
                    int diffY = rectOld.Y - e.Location.Y;
                    rectUpdated = new Rectangle(rectOld.X,
                                                e.Location.Y,
                                                (e.Location.X - rectOld.X), rectOld.Height + diffY);
                }


                reDraw(null);

            }
        }

        private void goToUpdateStage(object sender, EventArgs e)
        {
            timerForLongClick.Stop();
            timerForLongClick = new Timer(); // reset timer

            diagrams[updateCandidateIndex].isUpdateStage = true;
            stageUpdate = true;

            // save cur rect for movable
            if (draggedPinIndex < 0)
            {
                dragFlag = true;
                rectOld = diagrams[updateCandidateIndex].getRect();
                rectUpdated = rectOld; // initial position set !
            }

            System.Console.WriteLine("Update stage of diag index "+ updateCandidateIndex + "!!");
            reDraw(null);
        }

        private void reDraw(MouseEventArgs e)
        {
            Console.WriteLine("reDraw");
            this.panelCanvas.Refresh();

            if (stageAdd) // adding stage
            {
                if (curDiagram.isImgDiagram) // Translate Img Diagram
                {
                    tempGraphics.DrawImage(bmpImg, e.X, e.Y);
                }
                else                         // Redraw Rectangle
                {
                    tempGraphics.DrawRectangle(penRect, e.X, e.Y, initImgW, initImgH);
                }
            }


             /** draw all saved **/

            // draw classes
            for (int i = 0; i < diagrams.Count; i++)
            {
                Console.WriteLine(Convert.ToString(i));
                // draw classes
                Rectangle tempRect = diagrams[i].getRect();

                // updating movable
                if (i == updateCandidateIndex && !rectUpdated.IsEmpty)
                {
                    tempRect = rectUpdated;

                    // for repositioning Pins
                    diagrams[i].setRect(tempRect);
                    diagrams[i].createPins();
                }

                Graphics tempGraphics = this.panelCanvas.CreateGraphics();

                if (diagrams[i].isImgDiagram)
                {
                    Image img = Image.FromFile(diagrams[i].imageUrl);
                    bmpImg = new Bitmap(img, tempRect.Width, tempRect.Height);

                    tempGraphics.DrawImage(bmpImg, tempRect.X, tempRect.Y);
                }
                else
                {
                    Console.WriteLine("Not IMG");
                    tempGraphics.DrawRectangle(penRect, tempRect);
                }
            }

            // draw pins
            if (stageUpdate)
            {
                if (diagrams[updateCandidateIndex].isUpdateStage)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Pen p = new Pen(Color.Violet, 4);
                        Rectangle rect = new Rectangle();
                        Graphics graphics = this.panelCanvas.CreateGraphics();
                        rect = diagrams[updateCandidateIndex].getPinRect(j);
                        graphics.DrawRectangle(p, rect);
                        gPins.Add(graphics); // for removing after
                       // diagrams[updateCandidateIndex].isUpdateStage = false;
                    }
                }
            }

            // remove pins
            else if (stageWait && resizableDiagramIndex == -1)
            {
                if (gPins.Count != 0)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        gPins.RemoveAt(0);
                        diagrams[updateCandidateIndex].isUpdateStage = false;
                    }
                }
            }

        } // end of reDraw()

    } // end of Form class
} //end of Namespace
