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
         this.devBox = new System.Windows.Forms.GroupBox();
         this.score_Label = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.LoadObjectTimer = new System.Windows.Forms.Timer(this.components);
         this.start_button = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.label9 = new System.Windows.Forms.Label();
         this.label10 = new System.Windows.Forms.Label();
         this.label11 = new System.Windows.Forms.Label();
         this.menuStrip1.SuspendLayout();
         this.devBox.SuspendLayout();
         this.groupBox1.SuspendLayout();
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
         this.glControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseUp);
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
         this.moveTimer.Interval = 1000;
         this.moveTimer.Tick += new System.EventHandler(this.moveTimer_Tick);
         // 
         // ColorBox
         // 
         this.ColorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
         // devBox
         // 
         this.devBox.Controls.Add(this.score_Label);
         this.devBox.Controls.Add(this.label1);
         resources.ApplyResources(this.devBox, "devBox");
         this.devBox.Name = "devBox";
         this.devBox.TabStop = false;
         // 
         // score_Label
         // 
         resources.ApplyResources(this.score_Label, "score_Label");
         this.score_Label.Name = "score_Label";
         // 
         // label1
         // 
         resources.ApplyResources(this.label1, "label1");
         this.label1.Name = "label1";
         // 
         // LoadObjectTimer
         // 
         this.LoadObjectTimer.Tick += new System.EventHandler(this.LoadObjectTimer_Tick);
         // 
         // start_button
         // 
         resources.ApplyResources(this.start_button, "start_button");
         this.start_button.Name = "start_button";
         this.start_button.UseVisualStyleBackColor = true;
         this.start_button.Click += new System.EventHandler(this.start_button_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label11);
         this.groupBox1.Controls.Add(this.label10);
         this.groupBox1.Controls.Add(this.label9);
         this.groupBox1.Controls.Add(this.label8);
         this.groupBox1.Controls.Add(this.label7);
         this.groupBox1.Controls.Add(this.label6);
         this.groupBox1.Controls.Add(this.label5);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.label2);
         resources.ApplyResources(this.groupBox1, "groupBox1");
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.TabStop = false;
         // 
         // label2
         // 
         resources.ApplyResources(this.label2, "label2");
         this.label2.Name = "label2";
         // 
         // label3
         // 
         resources.ApplyResources(this.label3, "label3");
         this.label3.Name = "label3";
         // 
         // label4
         // 
         resources.ApplyResources(this.label4, "label4");
         this.label4.Name = "label4";
         // 
         // label5
         // 
         resources.ApplyResources(this.label5, "label5");
         this.label5.Name = "label5";
         // 
         // label6
         // 
         resources.ApplyResources(this.label6, "label6");
         this.label6.Name = "label6";
         // 
         // label7
         // 
         resources.ApplyResources(this.label7, "label7");
         this.label7.Name = "label7";
         // 
         // label8
         // 
         resources.ApplyResources(this.label8, "label8");
         this.label8.Name = "label8";
         // 
         // label9
         // 
         resources.ApplyResources(this.label9, "label9");
         this.label9.Name = "label9";
         // 
         // label10
         // 
         resources.ApplyResources(this.label10, "label10");
         this.label10.Name = "label10";
         // 
         // label11
         // 
         resources.ApplyResources(this.label11, "label11");
         this.label11.Name = "label11";
         // 
         // Form1
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.start_button);
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
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
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
      private GroupBox devBox;
      private Timer LoadObjectTimer;
      private Label score_Label;
      private Label label1;
      private Button start_button;
      private GroupBox groupBox1;
      private Label label11;
      private Label label10;
      private Label label9;
      private Label label8;
      private Label label7;
      private Label label6;
      private Label label5;
      private Label label4;
      private Label label3;
      private Label label2;
   }
}

