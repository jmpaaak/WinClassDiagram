namespace ImgBasedDiagramMaker
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.새창열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.이미지로저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.다이어그ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.다이어그램ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.클래스ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.이미지기반ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.일반사각형ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.관계ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.상속ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.의존ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.클래스ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.관계ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.상속ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.의존ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.다이어그ToolStripMenuItem,
            this.다이어그램ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";

            this.menuStrip1.Size = new System.Drawing.Size(1482, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.열기ToolStripMenuItem,
            this.새창열기ToolStripMenuItem,
            this.저장ToolStripMenuItem,
            this.이미지로저장ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // 열기ToolStripMenuItem
            // 
            this.열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";

            this.열기ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.열기ToolStripMenuItem.Text = "열기";
            this.열기ToolStripMenuItem.Click += new System.EventHandler(this.열기ToolStripMenuItem_Click);
            // 
            // 새창열기ToolStripMenuItem
            // 
            this.새창열기ToolStripMenuItem.Name = "새창열기ToolStripMenuItem";
            this.새창열기ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.새창열기ToolStripMenuItem.Text = "새창 열기";
            this.새창열기ToolStripMenuItem.Click += new System.EventHandler(this.새창열기ToolStripMenuItem_Click);

            // 
            // 저장ToolStripMenuItem
            // 
            this.저장ToolStripMenuItem.Name = "저장ToolStripMenuItem";
            this.저장ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.저장ToolStripMenuItem.Text = "저장";
            this.저장ToolStripMenuItem.Click += new System.EventHandler(this.저장ToolStripMenuItem_Click);
            // 
            // 이미지로저장ToolStripMenuItem
            // 
            this.이미지로저장ToolStripMenuItem.Name = "이미지로저장ToolStripMenuItem";
            this.이미지로저장ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.이미지로저장ToolStripMenuItem.Text = "이미지로 저장";
            this.이미지로저장ToolStripMenuItem.Click += new System.EventHandler(this.이미지로저장ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // 다이어그ToolStripMenuItem
            // 
            this.다이어그ToolStripMenuItem.Name = "다이어그ToolStripMenuItem";
            this.다이어그ToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // 다이어그램ToolStripMenuItem
            // 
            this.다이어그램ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.클래스ToolStripMenuItem1,
            this.관계ToolStripMenuItem1});
            this.다이어그램ToolStripMenuItem.Name = "다이어그램ToolStripMenuItem";
            this.다이어그램ToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.다이어그램ToolStripMenuItem.Text = "다이어그램";
            // 
            // 클래스ToolStripMenuItem1
            // 
            this.클래스ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.이미지기반ToolStripMenuItem,
            this.일반사각형ToolStripMenuItem});
            this.클래스ToolStripMenuItem1.Name = "클래스ToolStripMenuItem1";
            this.클래스ToolStripMenuItem1.Size = new System.Drawing.Size(129, 26);
            this.클래스ToolStripMenuItem1.Text = "클래스";
            // 
            // 이미지기반ToolStripMenuItem
            // 
            this.이미지기반ToolStripMenuItem.Name = "이미지기반ToolStripMenuItem";
            this.이미지기반ToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.이미지기반ToolStripMenuItem.Text = "이미지 기반";
            this.이미지기반ToolStripMenuItem.Click += new System.EventHandler(this.이미지기반ToolStripMenuItem_Click);
            // 
            // 일반사각형ToolStripMenuItem
            // 
            this.일반사각형ToolStripMenuItem.Name = "일반사각형ToolStripMenuItem";
            this.일반사각형ToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.일반사각형ToolStripMenuItem.Text = "일반 사각형";
            this.일반사각형ToolStripMenuItem.Click += new System.EventHandler(this.일반사각형ToolStripMenuItem_Click);
            // 
            // 관계ToolStripMenuItem1
            // 
            this.관계ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.상속ToolStripMenuItem1,
            this.의존ToolStripMenuItem1});
            this.관계ToolStripMenuItem1.Name = "관계ToolStripMenuItem1";
            this.관계ToolStripMenuItem1.Size = new System.Drawing.Size(129, 26);
            this.관계ToolStripMenuItem1.Text = "관계";
            // 
            // 상속ToolStripMenuItem1
            // 
            this.상속ToolStripMenuItem1.Name = "상속ToolStripMenuItem1";
            this.상속ToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.상속ToolStripMenuItem1.Text = "상속";
            // 
            // 의존ToolStripMenuItem1
            // 
            this.의존ToolStripMenuItem1.Name = "의존ToolStripMenuItem1";
            this.의존ToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.의존ToolStripMenuItem1.Text = "의존";
            // 
            // 클래스ToolStripMenuItem
            // 
            this.클래스ToolStripMenuItem.Name = "클래스ToolStripMenuItem";
            this.클래스ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.클래스ToolStripMenuItem.Text = "클래스";
            // 
            // 관계ToolStripMenuItem
            // 
            this.관계ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.상속ToolStripMenuItem,
            this.의존ToolStripMenuItem});
            this.관계ToolStripMenuItem.Name = "관계ToolStripMenuItem";
            this.관계ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.관계ToolStripMenuItem.Text = "관계";
            // 
            // 상속ToolStripMenuItem
            // 
            this.상속ToolStripMenuItem.Name = "상속ToolStripMenuItem";
            this.상속ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.상속ToolStripMenuItem.Text = "상속";
            // 
            // 의존ToolStripMenuItem
            // 
            this.의존ToolStripMenuItem.Name = "의존ToolStripMenuItem";
            this.의존ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.의존ToolStripMenuItem.Text = "의존";
            // 
            // panelCanvas
            // 
            this.panelCanvas.BackColor = System.Drawing.Color.White;
            this.panelCanvas.Location = new System.Drawing.Point(0, 25);
            this.panelCanvas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(1500, 900);
            this.panelCanvas.TabIndex = 0;
            this.panelCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseDown);
            this.panelCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseMove);
            this.panelCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseUp);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 953);
            this.Controls.Add(this.panelCanvas);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 열기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 새창열기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 다이어그ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 클래스ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 관계ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 상속ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 의존ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 다이어그램ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 클래스ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 관계ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 상속ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 의존ToolStripMenuItem1;
        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.ToolStripMenuItem 이미지기반ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 일반사각형ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 이미지로저장ToolStripMenuItem;
    }
}

