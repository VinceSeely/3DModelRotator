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
         this.timerLabel = new System.Windows.Forms.Label();
         this.StartStopButton = new System.Windows.Forms.Button();
         this.ResetButton = new System.Windows.Forms.Button();
         this.zLable = new System.Windows.Forms.Label();
         this.yLabel = new System.Windows.Forms.Label();
         this.xLabel = new System.Windows.Forms.Label();
         this.openFolder = new System.Windows.Forms.FolderBrowserDialog();
         this.moveTimer = new System.Windows.Forms.Timer(this.components);
         this.timerTickSlider = new System.Windows.Forms.TrackBar();
         this.globalAmbientLight = new System.Windows.Forms.TrackBar();
         this.globalAmbientLightLabel = new System.Windows.Forms.Label();
         this.LightSourceXpos = new System.Windows.Forms.TrackBar();
         this.LightSourceYpos = new System.Windows.Forms.TrackBar();
         this.LightSourceZpos = new System.Windows.Forms.TrackBar();
         this.LightXposLabel = new System.Windows.Forms.Label();
         this.LightYposLabel = new System.Windows.Forms.Label();
         this.LightZposLabel = new System.Windows.Forms.Label();
         this.ColorBox = new System.Windows.Forms.ComboBox();
         ((System.ComponentModel.ISupportInitialize)(this.xSlider)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ySlider)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.zSlider)).BeginInit();
         this.menuStrip1.SuspendLayout();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.timerTickSlider)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.globalAmbientLight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.LightSourceXpos)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.LightSourceYpos)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.LightSourceZpos)).BeginInit();
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
         this.abortToolStripMenuItem.Click += new System.EventHandler(this.abortToolStripMenuItem_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.timerLabel);
         this.groupBox1.Controls.Add(this.StartStopButton);
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
         // timerLabel
         // 
         resources.ApplyResources(this.timerLabel, "timerLabel");
         this.timerLabel.Name = "timerLabel";
         // 
         // StartStopButton
         // 
         resources.ApplyResources(this.StartStopButton, "StartStopButton");
         this.StartStopButton.Name = "StartStopButton";
         this.StartStopButton.UseVisualStyleBackColor = true;
         this.StartStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
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
         // openFolder
         // 
         resources.ApplyResources(this.openFolder, "openFolder");
         // 
         // moveTimer
         // 
         this.moveTimer.Interval = 10;
         this.moveTimer.Tick += new System.EventHandler(this.moveTimer_Tick);
         // 
         // timerTickSlider
         // 
         resources.ApplyResources(this.timerTickSlider, "timerTickSlider");
         this.timerTickSlider.LargeChange = 1;
         this.timerTickSlider.Maximum = 90;
         this.timerTickSlider.Minimum = 1;
         this.timerTickSlider.Name = "timerTickSlider";
         this.timerTickSlider.Value = 90;
         this.timerTickSlider.ValueChanged += new System.EventHandler(this.timerTickSlider_ValueChanged);
         // 
         // globalAmbientLight
         // 
         this.globalAmbientLight.LargeChange = 1;
         resources.ApplyResources(this.globalAmbientLight, "globalAmbientLight");
         this.globalAmbientLight.Name = "globalAmbientLight";
         this.globalAmbientLight.Value = 5;
         this.globalAmbientLight.ValueChanged += new System.EventHandler(this.globalAmbientLight_ValueChanged);
         // 
         // globalAmbientLightLabel
         // 
         resources.ApplyResources(this.globalAmbientLightLabel, "globalAmbientLightLabel");
         this.globalAmbientLightLabel.Name = "globalAmbientLightLabel";
         // 
         // LightSourceXpos
         // 
         resources.ApplyResources(this.LightSourceXpos, "LightSourceXpos");
         this.LightSourceXpos.LargeChange = 1;
         this.LightSourceXpos.Maximum = 200;
         this.LightSourceXpos.Name = "LightSourceXpos";
         this.LightSourceXpos.Value = 5;
         this.LightSourceXpos.ValueChanged += new System.EventHandler(this.LightSourceXpos_ValueChanged);
         // 
         // LightSourceYpos
         // 
         resources.ApplyResources(this.LightSourceYpos, "LightSourceYpos");
         this.LightSourceYpos.LargeChange = 1;
         this.LightSourceYpos.Maximum = 200;
         this.LightSourceYpos.Name = "LightSourceYpos";
         this.LightSourceYpos.Value = 5;
         this.LightSourceYpos.ValueChanged += new System.EventHandler(this.LightSourceYpos_ValueChanged);
         // 
         // LightSourceZpos
         // 
         resources.ApplyResources(this.LightSourceZpos, "LightSourceZpos");
         this.LightSourceZpos.LargeChange = 1;
         this.LightSourceZpos.Maximum = 200;
         this.LightSourceZpos.Name = "LightSourceZpos";
         this.LightSourceZpos.Value = 5;
         this.LightSourceZpos.ValueChanged += new System.EventHandler(this.LightSourceZpos_ValueChanged);
         // 
         // LightXposLabel
         // 
         resources.ApplyResources(this.LightXposLabel, "LightXposLabel");
         this.LightXposLabel.Name = "LightXposLabel";
         // 
         // LightYposLabel
         // 
         resources.ApplyResources(this.LightYposLabel, "LightYposLabel");
         this.LightYposLabel.Name = "LightYposLabel";
         // 
         // LightZposLabel
         // 
         resources.ApplyResources(this.LightZposLabel, "LightZposLabel");
         this.LightZposLabel.Name = "LightZposLabel";
         // 
         // ColorBox
         // 
         this.ColorBox.FormattingEnabled = true;
         this.ColorBox.Items.AddRange(new object[] {
            resources.GetString("ColorBox.Items"),
            resources.GetString("ColorBox.Items1"),
            resources.GetString("ColorBox.Items2"),
            resources.GetString("ColorBox.Items3"),
            resources.GetString("ColorBox.Items4"),
            resources.GetString("ColorBox.Items5"),
            resources.GetString("ColorBox.Items6")});
         resources.ApplyResources(this.ColorBox, "ColorBox");
         this.ColorBox.Name = "ColorBox";
         this.ColorBox.Sorted = true;
         this.ColorBox.SelectedIndexChanged += new System.EventHandler(this.ColorBox_SelectedIndexChanged);
         // 
         // Form1
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.ColorBox);
         this.Controls.Add(this.LightZposLabel);
         this.Controls.Add(this.LightYposLabel);
         this.Controls.Add(this.LightXposLabel);
         this.Controls.Add(this.LightSourceZpos);
         this.Controls.Add(this.LightSourceYpos);
         this.Controls.Add(this.LightSourceXpos);
         this.Controls.Add(this.globalAmbientLightLabel);
         this.Controls.Add(this.globalAmbientLight);
         this.Controls.Add(this.timerTickSlider);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.glControl1);
         this.Controls.Add(this.menuStrip1);
         this.Name = "Form1";
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
         this.Load += new System.EventHandler(this.Form1_Load);
         this.Shown += new System.EventHandler(this.Form1_Shown);
         this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
         this.Resize += new System.EventHandler(this.Form1_Resize);
         ((System.ComponentModel.ISupportInitialize)(this.xSlider)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ySlider)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.zSlider)).EndInit();
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.timerTickSlider)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.globalAmbientLight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.LightSourceXpos)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.LightSourceYpos)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.LightSourceZpos)).EndInit();
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
        private Button StartStopButton;
        private Label timerLabel;
        private TrackBar timerTickSlider;
      private TrackBar globalAmbientLight;
      private Label globalAmbientLightLabel;
      private TrackBar LightSourceXpos;
      private TrackBar LightSourceYpos;
      private TrackBar LightSourceZpos;
      private Label LightXposLabel;
      private Label LightYposLabel;
      private Label LightZposLabel;
      private ComboBox ColorBox;
   }
}

