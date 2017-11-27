using System;
using System.Windows.Forms;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace Prog2
{
   public partial class Form1 : Form
   {
      private const int defaultSliderVal = 5;
      private Axes axis;
      private FigureList figures;
      private const int intervalTiming = 10;
      private ShaderLoader _shader;
      private Matrix4 _LookAt;

      public bool timerIsOn { get; private set; }

      public Form1()
      {
         InitializeComponent();
      }

      private void Form1_SizeChanged(object sender, EventArgs e)
      {
         if (!glControl1.Enabled)
            glControl1.SwapBuffers();
      }

      private void zSlider_MouseMove(object sender, MouseEventArgs e)
      {
         zLable.Text = $"z = {zSlider.Value}";

         drawShape();
      }

      private void drawShape()
      {
         GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
         Matrix4 lookat = Matrix4.LookAt(xSlider.Value, ySlider.Value, zSlider.Value, 0f, 0f, 0f, 0f, 1.0f, 0f);

         var viewMatrixLoc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "ViewMatrix");
         GL.UniformMatrix4(viewMatrixLoc, false, ref lookat);

         figures?.Show(lookat);

         axis.Show(lookat);
         glControl1.SwapBuffers();
      }

      private void xSlider_MouseMove(object sender, MouseEventArgs e)
      {
         xLabel.Text = $"x = {xSlider.Value}";

         drawShape();
      }

      private void ySlider_Scroll(object sender, EventArgs e)
      {
         yLabel.Text = $"y = {ySlider.Value}";

         drawShape();
      }

      private void ResetButton_Click(object sender, EventArgs e)
      {
         xSlider.Value = defaultSliderVal;
         ySlider.Value = defaultSliderVal;
         zSlider.Value = defaultSliderVal;
         figures.Reset();
         drawShape();
      }

      private void Form1_Shown(object sender, EventArgs e)
      {
         drawShape();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         _SetSliderss();
         _SetUpViewingField();
         _LoadShaders();

         var lookAtLoc = GL.GetUniformLocation(_shader.ProgramHandle, "ViewMatrix");
         GL.UniformMatrix4(lookAtLoc, true, ref _LookAt);

         glControl1.SwapBuffers();

         openToolStripMenuItem.Text = "Open";
         figures = new FigureList();
         _SetUpTimer();
      }

      private void _LoadShaders()
      {
         _shader = ShaderLoader.Instance;
         _shader.Load(Path.Combine(Directory.GetCurrentDirectory(), "Prog4_VS.glsl"), Path.Combine(Directory.GetCurrentDirectory(), "Prog4_FS.glsl"));
         if (!_shader.LastLoadError.Equals(""))
         {
            MessageBox.Show(_shader.LastLoadError);
         }
      }

      private void _SetUpTimer()
      {
         var moveTiming = timerTickSlider.Value * intervalTiming;
         moveTimer.Interval = moveTiming;
         timerLabel.Text = $"Timer tick time: {moveTiming}";
         timerIsOn = false;
      }

      private void _SetUpViewingField()
      {
         axis = Axes.Instance;
         GL.Enable(EnableCap.DepthTest);
         float mult = (float)glControl1.Height / (float)glControl1.Width;
         const float WINDOW_SIZE = 2.0f;
         const float WIN_NEAR = 2.0f;
         const float WIN_FAR = 80.0f;
         Matrix4 projMat = Matrix4.CreatePerspectiveOffCenter(
            -WINDOW_SIZE, WINDOW_SIZE, -WINDOW_SIZE * mult,
            WINDOW_SIZE * mult, WIN_NEAR, WIN_FAR);

         var viewMatrixLoc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "ViewMatrix");
         GL.UniformMatrix4(viewMatrixLoc, true, ref projMat);
      }

      private void _SetSliderss()
      {
         xSlider.Value = defaultSliderVal;
         ySlider.Value = defaultSliderVal;
         zSlider.Value = defaultSliderVal;
         xLabel.Text = $"x = {defaultSliderVal}";
         yLabel.Text = $"y = {defaultSliderVal}";
         zLable.Text = $"z = {defaultSliderVal}";
      }

      private void openToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var results = openFolder.ShowDialog();
         figures.LoadFigures(openFolder.SelectedPath);
         drawShape();
      }

      private void moveTimer_Tick(object sender, EventArgs e)
      {
         figures.Move();
         drawShape();
      }

      private void StartStopButton_Click(object sender, EventArgs e)
      {
         if (timerIsOn)
         {
            moveTimer.Stop();
            StartStopButton.Text = "Start";
            timerTickSlider.Enabled = false;
            timerIsOn = false;
         }
         else
         {
            moveTimer.Start();
            StartStopButton.Text = "Stop";
            timerTickSlider.Enabled = true;
            timerIsOn = true;
         }
      }

      private void timerTickSlider_TabIndexChanged(object sender, EventArgs e)
      {

      }

      private void timerTickSlider_ValueChanged(object sender, EventArgs e)
      {
         var moveTiming = timerTickSlider.Value * intervalTiming;
         moveTimer.Interval = moveTiming;
         timerLabel.Text = $"Timer tick time: {moveTiming}";
      }
   }
}