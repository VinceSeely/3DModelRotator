using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Prog2
{
   public partial class Form1 : Form
   {
      private Matrix4 lookAt = Matrix4.LookAt(25.0f, 25.0f, 25.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
      private const int defaultSliderVal = 5;
      private Axes axis;
      private bool rotateMode;
      private FigureList figures;

      public Form1()
      {
         InitializeComponent();
         // openFolder.RootFolder = Environment.SpecialFolder.MyDocuments;
      }

      private void Form1_SizeChanged(object sender, EventArgs e)
      {
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

         GL.MatrixMode(MatrixMode.Modelview);

         Matrix4 lookat = Matrix4.LookAt(xSlider.Value, ySlider.Value, zSlider.Value, 0f, 0f, 0f, 0f, 1.0f, 0f);
         GL.LoadMatrix(ref lookat);

         figures?.Show(lookat);

         axis.Show();

         GL.Flush();
         glControl1.SwapBuffers();
      }

      private void xSlider_MouseMove(object sender, MouseEventArgs e)            //Displays X value
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
         drawShape();
      }

      private void Form1_Shown(object sender, EventArgs e)
      {
         //Do things with the XYZ coordinate axes
         drawShape();
         glControl1.SwapBuffers();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         xSlider.Value = defaultSliderVal;
         ySlider.Value = defaultSliderVal;
         zSlider.Value = defaultSliderVal;
         xLabel.Text = $"x = {defaultSliderVal}";
         yLabel.Text = $"y = {defaultSliderVal}";
         zLable.Text = $"z = {defaultSliderVal}";
         // OpenFileDialog.Filter = "VMRL files (*.wrl)|*.wrl|All Files (*.*)|*.*";
         axis = Axes.Instance;
         GL.Enable(EnableCap.DepthTest);
         rotateMode = false;
         GL.MatrixMode(MatrixMode.Projection);
         Matrix4 projMat = Matrix4.CreateOrthographic(40.0f, 40.0f, 0.5f, 100.0f);
         GL.LoadMatrix(ref projMat);
         glControl1.SwapBuffers();
         openToolStripMenuItem.Text = "Open";
         figures = new FigureList();
         moveTimer.Start();
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
   }
}