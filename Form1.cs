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
      private Axes axes;

      public Form1()
      {
         InitializeComponent();
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

         GL.LoadIdentity();

         GL.Rotate(xSlider.Value, 1, 0, 0);             //Leave this.
         GL.Rotate(ySlider.Value, 0, 1, 0);
         GL.Rotate(zSlider.Value, 0, 0, 1);

         axes.Show();

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
         axes.Show();
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
         OpenFileDialog.Filter = "VMRL files (*.wrl)|*.wrl|All Files (*.*)|*.*";
         axes = Axes.Instance;
         GL.Enable(EnableCap.DepthTest);
         GL.MatrixMode(MatrixMode.Projection);
         Matrix4 projMat = Matrix4.CreateOrthographic(20.0f, 20.0f, 0.5f, 100.0f);
         GL.LoadMatrix(ref projMat);
         glControl1.SwapBuffers();
      }

      private void openToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var openFile = OpenFileDialog.ShowDialog();
         drawShape();
      }
   }
}
