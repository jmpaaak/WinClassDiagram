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
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.panelCanvas.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCanvas
            // 
            this.panelCanvas.Location = new System.Drawing.Point(12, 12);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(670, 347);
            this.panelCanvas.TabIndex = 0;
            this.panelCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseDown);
            this.panelCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseMove);
            this.panelCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseUp);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 371);
            this.Controls.Add(this.panelCanvas);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.panelCanvas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCanvas;
    }
}

