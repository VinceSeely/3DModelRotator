using System.Windows.Forms;

namespace AlienSpaceShooter
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
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.abortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.how20ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.moveTimer = new System.Windows.Forms.Timer(this.components);
         this.ColorBox = new System.Windows.Forms.ComboBox();
         this.colorLabel = new System.Windows.Forms.Label();
         this.mouseXLabel = new System.Windows.Forms.Label();
         this.mouseYLabel = new System.Windows.Forms.Label();
         this.glxLabel = new System.Windows.Forms.Label();
         this.glyLabel = new System.Windows.Forms.Label();
         this.devBox = new System.Windows.Forms.GroupBox();
         this.xyViewLabel = new System.Windows.Forms.Label();
         this.formLoc = new System.Windows.Forms.Label();
         this.LoadObjectTimer = new System.Windows.Forms.Timer(this.components);
         this.menuStrip1.SuspendLayout();
         this.devBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // glControl1
         // 
         resources.ApplyResources(this.glControl1, "glControl1");
         this.glControl1.BackColor = System.Drawing.Color.Black;
         this.glControl1.Name = "glControl1";
         this.glControl1.VSync = false;
         this.glControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.glControl1_KeyDown);
         this.glControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseMove);
         // 
         // menuStrip1
         // 
         this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
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
         // 
         // abortToolStripMenuItem
         // 
         this.abortToolStripMenuItem.Name = "abortToolStripMenuItem";
         resources.ApplyResources(this.abortToolStripMenuItem, "abortToolStripMenuItem");
         this.abortToolStripMenuItem.Click += new System.EventHandler(this.abortToolStripMenuItem_Click);
         // 
         // helpToolStripMenuItem
         // 
         this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.how20ToolStripMenuItem});
         this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
         resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
         // 
         // how20ToolStripMenuItem
         // 
         this.how20ToolStripMenuItem.Name = "how20ToolStripMenuItem";
         resources.ApplyResources(this.how20ToolStripMenuItem, "how20ToolStripMenuItem");
         this.how20ToolStripMenuItem.Click += new System.EventHandler(this.how20ToolStripMenuItem_Click);
         // 
         // moveTimer
         // 
         this.moveTimer.Interval = 10;
         this.moveTimer.Tick += new System.EventHandler(this.moveTimer_Tick);
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
         // colorLabel
         // 
         resources.ApplyResources(this.colorLabel, "colorLabel");
         this.colorLabel.Name = "colorLabel";
         this.colorLabel.UseMnemonic = false;
         // 
         // mouseXLabel
         // 
         resources.ApplyResources(this.mouseXLabel, "mouseXLabel");
         this.mouseXLabel.Name = "mouseXLabel";
         // 
         // mouseYLabel
         // 
         resources.ApplyResources(this.mouseYLabel, "mouseYLabel");
         this.mouseYLabel.Name = "mouseYLabel";
         // 
         // glxLabel
         // 
         resources.ApplyResources(this.glxLabel, "glxLabel");
         this.glxLabel.Name = "glxLabel";
         // 
         // glyLabel
         // 
         resources.ApplyResources(this.glyLabel, "glyLabel");
         this.glyLabel.Name = "glyLabel";
         // 
         // devBox
         // 
         this.devBox.Controls.Add(this.xyViewLabel);
         this.devBox.Controls.Add(this.formLoc);
         this.devBox.Controls.Add(this.mouseXLabel);
         this.devBox.Controls.Add(this.glyLabel);
         this.devBox.Controls.Add(this.mouseYLabel);
         this.devBox.Controls.Add(this.glxLabel);
         resources.ApplyResources(this.devBox, "devBox");
         this.devBox.Name = "devBox";
         this.devBox.TabStop = false;
         // 
         // xyViewLabel
         // 
         resources.ApplyResources(this.xyViewLabel, "xyViewLabel");
         this.xyViewLabel.Name = "xyViewLabel";
         // 
         // formLoc
         // 
         resources.ApplyResources(this.formLoc, "formLoc");
         this.formLoc.Name = "formLoc";
         // 
         // LoadObjectTimer
         // 
         this.LoadObjectTimer.Tick += new System.EventHandler(this.LoadObjectTimer_Tick);
         // 
         // Form1
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.devBox);
         this.Controls.Add(this.colorLabel);
         this.Controls.Add(this.ColorBox);
         this.Controls.Add(this.glControl1);
         this.Controls.Add(this.menuStrip1);
         this.Name = "Form1";
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
         this.Load += new System.EventHandler(this.Form1_Load);
         this.Shown += new System.EventHandler(this.Form1_Shown);
         this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
         this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
         this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
         this.Move += new System.EventHandler(this.Form1_Move);
         this.Resize += new System.EventHandler(this.Form1_Resize);
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.devBox.ResumeLayout(false);
         this.devBox.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abortToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
      private Timer moveTimer;
      private ComboBox ColorBox;
        private Label colorLabel;
      private ToolStripMenuItem helpToolStripMenuItem;
      private ToolStripMenuItem how20ToolStripMenuItem;
      private Label mouseXLabel;
      private Label mouseYLabel;
      private Label glxLabel;
      private Label glyLabel;
      private GroupBox devBox;
      private Label formLoc;
      private Label xyViewLabel;
      private Timer LoadObjectTimer;
   }
}

