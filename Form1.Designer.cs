namespace Prog2
{
    partial class Form1
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
            this.glControl1 = new OpenTK.GLControl();
            this.xSlider = new System.Windows.Forms.TrackBar();
            this.ySlider = new System.Windows.Forms.TrackBar();
            this.zSlider = new System.Windows.Forms.TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.abortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.xLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.zLable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.xSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zSlider)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(3, 133);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(406, 272);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            // 
            // xSlider
            // 
            this.xSlider.LargeChange = 1;
            this.xSlider.Location = new System.Drawing.Point(6, 49);
            this.xSlider.Maximum = 25;
            this.xSlider.Minimum = -25;
            this.xSlider.Name = "xSlider";
            this.xSlider.Size = new System.Drawing.Size(104, 45);
            this.xSlider.TabIndex = 1;
            this.xSlider.MouseMove += new System.Windows.Forms.MouseEventHandler(this.xSlider_MouseMove);
            // 
            // ySlider
            // 
            this.ySlider.LargeChange = 1;
            this.ySlider.Location = new System.Drawing.Point(120, 49);
            this.ySlider.Maximum = 25;
            this.ySlider.Minimum = -25;
            this.ySlider.Name = "ySlider";
            this.ySlider.Size = new System.Drawing.Size(104, 45);
            this.ySlider.TabIndex = 2;
            this.ySlider.Scroll += new System.EventHandler(this.ySlider_Scroll);
            // 
            // zSlider
            // 
            this.zSlider.LargeChange = 1;
            this.zSlider.Location = new System.Drawing.Point(226, 49);
            this.zSlider.Maximum = 25;
            this.zSlider.Minimum = -25;
            this.zSlider.Name = "zSlider";
            this.zSlider.Size = new System.Drawing.Size(104, 45);
            this.zSlider.TabIndex = 3;
            this.zSlider.MouseMove += new System.Windows.Forms.MouseEventHandler(this.zSlider_MouseMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(409, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.abortToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Text = "Open";
            // 
            // abortToolStripMenuItem
            // 
            this.abortToolStripMenuItem.Name = "abortToolStripMenuItem";
            this.abortToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.abortToolStripMenuItem.Text = "Abort";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.zLable);
            this.groupBox1.Controls.Add(this.yLabel);
            this.groupBox1.Controls.Add(this.xLabel);
            this.groupBox1.Controls.Add(this.ySlider);
            this.groupBox1.Controls.Add(this.zSlider);
            this.groupBox1.Controls.Add(this.xSlider);
            this.groupBox1.Location = new System.Drawing.Point(29, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "X, Y, and Z view value sliders";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(15, 33);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(0, 13);
            this.xLabel.TabIndex = 4;
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(117, 33);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(0, 13);
            this.yLabel.TabIndex = 5;
            // 
            // zLable
            // 
            this.zLable.AutoSize = true;
            this.zLable.Location = new System.Drawing.Point(227, 33);
            this.zLable.Name = "zLable";
            this.zLable.Size = new System.Drawing.Size(0, 13);
            this.zLable.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 408);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.glControl1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "SUCC";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.xSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zSlider)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.TrackBar xSlider;
        private System.Windows.Forms.TrackBar ySlider;
        private System.Windows.Forms.TrackBar zSlider;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem abortToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label zLable;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label xLabel;
    }
}

