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
        public FormMain()
        {
            InitializeComponent();
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {

                string fileName = ofd.SafeFileName;
                string fileFullName = ofd.FileName;
                string filePath = fileFullName.Replace(fileName, "");

                String text = System.IO.File.ReadAllText(ofd.FileName);



                // string prog = "C:\\Users\\kjh\\Documents\\Visual Studio 2015\\Projects\\MiDiagram1\\MiDiagram1\\bin\\Debug\\MiDiagram1.exe";
                Process.Start("MiDiagram1.exe", fileName);

                /*
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
                t.Start();
                */

            }
        }

        private void 새창으로열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {

                string fileName = ofd.SafeFileName;
                string fileFullName = ofd.FileName;
                string filePath = fileFullName.Replace(fileName, "");

                String text = System.IO.File.ReadAllText(ofd.FileName);



                // string prog = "C:\\Users\\kjh\\Documents\\Visual Studio 2015\\Projects\\MiDiagram1\\MiDiagram1\\bin\\Debug\\MiDiagram1.exe";
                Process.Start("MiDiagram1.exe", fileName);
            }
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "다른 이름으로 저장";
            sfd.DefaultExt = "txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //System.IO.StreamWriter file = new System.IO.StreamWriter(sfd.FileName);
                ////int nr_list = di.member.Count;
                //file.WriteLine(nr_list.ToString());
                //for (int i = 0; i < nr_list; i++)
                //{
                //    file.WriteLine(di.member[i]);

                //}
                //file.Close();
            }
        }

        private void 이미지기반ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // addMovableImgDiagram();
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
                            timerForLongClick.Tick += new EventHandler(goToUpdateStage);

                            break; // BREAK for waiting upcoming update stage
                        }
                        else
                            return; // return for nothing to do with updating stage diagram
                                    // updating stage diagram must be controlled in Mouse Move Event Callback
                    }
                }

                /* click event for OUT OF diagrams (background click event) */
                for (int i = 0; i < diagrams.Count; i++)
                {
                    // updated stage TO waiting stage
                    if (stageUpdate)
                    {
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
            if (!stageAdd) // only waiting stage
            {
                timerForLongClick.Stop();
                timerForLongClick = new Timer(); // reset timer
            }
        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(stageAdd)
                reDraw(e);
            //else if()
            //{

            //}
        }

        private void goToUpdateStage(object sender, EventArgs e)
        {
            timerForLongClick.Stop();
            timerForLongClick = new Timer(); // reset timer

            diagrams[updateCandidateIndex].isUpdateStage = true;
            stageUpdate = true;

            System.Console.WriteLine("Update stage of diag index "+ updateCandidateIndex + "!!");
            reDraw(null);
        }

        private void reDraw(MouseEventArgs e)
        {
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
                // draw classes
                Rectangle tempRect = diagrams[i].getRect();
                Graphics tempGraphics = this.panelCanvas.CreateGraphics();

                if (diagrams[i].isImgDiagram)
                {
                    Image img = Image.FromFile(diagrams[i].imageUrl);
                    bmpImg = new Bitmap(img, tempRect.Width, tempRect.Height);

                    tempGraphics.DrawImage(bmpImg, tempRect.X, tempRect.Y);
                }
                else
                {
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
                        diagrams[updateCandidateIndex].isUpdateStage = false;
                    }
                }
            }

            // remove pins
            else if (stageWait)
            {
                if (gPins.Count != 0)
                { 
                    for (int i = 0; i < 8; i++)
                    {
                        gPins.RemoveAt(0);
                    }
                }
            }

        } // end of reDraw()
    } // end of Form class
} //end of Namespace
