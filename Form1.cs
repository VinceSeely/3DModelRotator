﻿using System;
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
      private const int defaultSliderVal = 5;
      private Axes axis;
      private bool rotateMode;
      private FigureList figures;

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
         Matrix4 lookat = Matrix4.LookAt(xSlider.Value, ySlider.Value, zSlider.Value, 0f, 0f, 0f, 0f, 1.0f, 0f);
         

         figures?.Show(lookat);

         axis.Show(lookat);
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
         figures.Reset();
         drawShape();
      }

      private void Form1_Shown(object sender, EventArgs e)
      {
         drawShape();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         xSlider.Value = defaultSliderVal;
         ySlider.Value = defaultSliderVal;
         zSlider.Value = defaultSliderVal;
         xLabel.Text = $"x = {defaultSliderVal}";
         yLabel.Text = $"y = {defaultSliderVal}";
         zLable.Text = $"z = {defaultSliderVal}";
         axis = Axes.Instance;
         GL.Enable(EnableCap.DepthTest);
         float mult = (float)glControl1.Height / (float)glControl1.Width;
         const float WINDOW_SIZE = 2.0f;
         const float WIN_NEAR = 2.0f;
         const float WIN_FAR = 80.0f;
         Matrix4 projMat = Matrix4.CreatePerspectiveOffCenter(
         -WINDOW_SIZE, WINDOW_SIZE, -WINDOW_SIZE * mult,
         WINDOW_SIZE * mult, WIN_NEAR, WIN_FAR);
         GL.MatrixMode(MatrixMode.Projection);
         GL.LoadMatrix(ref projMat);
         GL.MatrixMode(MatrixMode.Modelview);
         ;
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