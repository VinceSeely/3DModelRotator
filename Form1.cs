using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            xLabel.Text = "x = 0";
            yLabel.Text = "y = 0";
            zLable.Text = "z = 0";
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            glControl1.SwapBuffers();
        }

        private void zSlider_MouseMove(object sender, MouseEventArgs e)
        {
            zLable.Text = $"z = {zSlider.Value}";

        }

        private void xSlider_MouseMove(object sender, MouseEventArgs e)
        {
            xLabel.Text = $"x = {xSlider.Value}";
        }

        private void ySlider_Scroll(object sender, EventArgs e)
        {
            yLabel.Text = $"y = {ySlider.Value}";
        }
    }
}
