using System.Windows.Forms;

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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
         this.glControl1 = new OpenTK.GLControl();
         this.xSlider = new System.Windows.Forms.TrackBar();
         this.ySlider = new System.Windows.Forms.TrackBar();
         this.zSlider = new System.Windows.Forms.TrackBar();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.abortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.ResetButton = new System.Windows.Forms.Button();
         this.zLable = new System.Windows.Forms.Label();
         this.yLabel = new System.Windows.Forms.Label();
         this.xLabel = new System.Windows.Forms.Label();
         this.openFolder = new System.Windows.Forms.FolderBrowserDialog();
         this.moveTimer = new System.Windows.Forms.Timer(this.components);
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
         resources.ApplyResources(this.glControl1, "glControl1");
         this.glControl1.Name = "glControl1";
         this.glControl1.VSync = false;
         // 
         // xSlider
         // 
         this.xSlider.LargeChange = 1;
         resources.ApplyResources(this.xSlider, "xSlider");
         this.xSlider.Maximum = 90;
         this.xSlider.Minimum = -90;
         this.xSlider.Name = "xSlider";
         this.xSlider.MouseMove += new System.Windows.Forms.MouseEventHandler(this.xSlider_MouseMove);
         // 
         // ySlider
         // 
         this.ySlider.LargeChange = 1;
         resources.ApplyResources(this.ySlider, "ySlider");
         this.ySlider.Maximum = 90;
         this.ySlider.Minimum = -90;
         this.ySlider.Name = "ySlider";
         this.ySlider.Scroll += new System.EventHandler(this.ySlider_Scroll);
         // 
         // zSlider
         // 
         this.zSlider.LargeChange = 1;
         resources.ApplyResources(this.zSlider, "zSlider");
         this.zSlider.Maximum = 90;
         this.zSlider.Minimum = -90;
         this.zSlider.Name = "zSlider";
         this.zSlider.MouseMove += new System.Windows.Forms.MouseEventHandler(this.zSlider_MouseMove);
         // 
         // menuStrip1
         // 
         this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
         resources.ApplyResources(this.menuStrip1, "menuStrip1");
         this.menuStrip1.Name = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.abortToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
         // 
         // openToolStripMenuItem
         // 
         this.openToolStripMenuItem.Name = "openToolStripMenuItem";
         resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
         this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
         // 
         // abortToolStripMenuItem
         // 
         this.abortToolStripMenuItem.Name = "abortToolStripMenuItem";
         resources.ApplyResources(this.abortToolStripMenuItem, "abortToolStripMenuItem");
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.ResetButton);
         this.groupBox1.Controls.Add(this.zLable);
         this.groupBox1.Controls.Add(this.yLabel);
         this.groupBox1.Controls.Add(this.xLabel);
         this.groupBox1.Controls.Add(this.ySlider);
         this.groupBox1.Controls.Add(this.zSlider);
         this.groupBox1.Controls.Add(this.xSlider);
         resources.ApplyResources(this.groupBox1, "groupBox1");
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.TabStop = false;
         // 
         // ResetButton
         // 
         resources.ApplyResources(this.ResetButton, "ResetButton");
         this.ResetButton.Name = "ResetButton";
         this.ResetButton.UseVisualStyleBackColor = true;
         this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
         // 
         // zLable
         // 
         resources.ApplyResources(this.zLable, "zLable");
         this.zLable.Name = "zLable";
         // 
         // yLabel
         // 
         resources.ApplyResources(this.yLabel, "yLabel");
         this.yLabel.Name = "yLabel";
         // 
         // xLabel
         // 
         resources.ApplyResources(this.xLabel, "xLabel");
         this.xLabel.Name = "xLabel";
         // 
         // moveTimer
         // 
         this.moveTimer.Tick += new System.EventHandler(this.moveTimer_Tick);
         // 
         // Form1
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.glControl1);
         this.Controls.Add(this.menuStrip1);
         this.Name = "Form1";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.Shown += new System.EventHandler(this.Form1_Shown);
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
        private System.Windows.Forms.ToolStripMenuItem abortToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label zLable;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label xLabel;
      private FolderBrowserDialog openFolder;
      private System.Windows.Forms.Button ResetButton;
      private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
      private Timer moveTimer;
   }
}

