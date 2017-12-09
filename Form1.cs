using System;
using System.Windows.Forms;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using AlienSpaceShooter.MovePatterns;

namespace AlienSpaceShooter
{
   public partial class Form1 : Form
   {
      private const int defaultSliderVal = 5;
      private Axes axis;
      private FigureList figures;
      private const int intervalTiming = 10;
      private ShaderLoader _shader;
      private Vector3 lightSource;

      // LookAt Coordinates Group
      private float xCoord;
      private float yCoord;
      private float zCoord;
     
      // Mouse position coordinates
      private float mouse_hor;
      private float mouse_ver;

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
      
      private void loadShip()
      {
         VertexDataList ship = new VertexDataList();
         ship.LoadDataFromVRML(Path.Combine(Directory.GetCurrentDirectory(), "ObjectsToLoad\\Base_Zeta.wrl"));
         var shipFigure = new Figure(ship, 300);
         figures.Add(shipFigure, new AlienShipMovement());
      }

      private void loadRock()
      {
         VertexDataList rock = new VertexDataList();
         rock.LoadDataFromVRML(Path.Combine(Directory.GetCurrentDirectory(), "ObjectsToLoad\\small_cave.wrl"));
         var rockFigure = new Figure(rock, 300);
         figures.Add(rockFigure, new AlienShipMovement());
      }

      private void drawShape()
      {
         GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
         Matrix4 lookat = Matrix4.LookAt(xCoord, yCoord, 0.0f, 0f, 0f, 0f, 0f, 1.0f, 0f);

         //light
         lightSource = new Vector3((float)5, (float) 5, (float)5);
         var lightSourceLocaiton = GL.GetUniformLocation(_shader.ProgramHandle, "LightPosition");
         GL.Uniform3(lightSourceLocaiton, lightSource);

         //global shiny
         var shininessLoc = GL.GetUniformLocation(_shader.ProgramHandle, "Shininess");
         GL.Uniform1(shininessLoc, 1f);

         //color
         var lightColorLoc = GL.GetUniformLocation(_shader.ProgramHandle, "LightColor");
         _SetColor(lightColorLoc);
         var viewMatrixLoc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "ViewMatrix");


         GL.UniformMatrix4(viewMatrixLoc, false, ref lookat);

         //ambient
         var ambientLoc = GL.GetUniformLocation(_shader.ProgramHandle, "GlobalAmbient");
         GL.Uniform1(ambientLoc, (0.5f));

         figures?.Show(lookat);

         axis.Show(lookat);
         glControl1.SwapBuffers();
      }

      private void _SetColor(int lightColorLoc)
      {
         switch(ColorBox.Text)
         {
            case "White":
               GL.Uniform3(lightColorLoc, new Vector3(1f, 1f, 1f));
               break;
            case "Black":
               GL.Uniform3(lightColorLoc, new Vector3(0f,0f,0f));
               break;
            case "Red":
               GL.Uniform3(lightColorLoc, new Vector3(1f,0f,0f));
               break;
            case "Green":
               GL.Uniform3(lightColorLoc, new Vector3(0f,1f,0f));
               break;
            case "Blue":
               GL.Uniform3(lightColorLoc, new Vector3(0f,0f,1f));
               break;
            case "Magenta":
               GL.Uniform3(lightColorLoc, new Vector3(1f,0f,1f));
               break;
            case "Yellow":
               GL.Uniform3(lightColorLoc, new Vector3(1f,1f,0f));
               break;
         }
      }

      private void Form1_Shown(object sender, EventArgs e)
      {
         moveTimer.Interval = 10;
         moveTimer.Start();
         LoadObjectTimer.Interval = 900;
         LoadObjectTimer.Start();
         drawShape();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         _LoadShaders();
         _SetUpViewingField();

         glControl1.SwapBuffers();

         figures = new FigureList();

         mouse_hor = glControl1.Size.Width / 2;
         mouse_ver = glControl1.Size.Height / 2;
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

         var projMatrixLoc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "ProjectionMatrix");
         GL.UniformMatrix4(projMatrixLoc, false, ref projMat);
      }

      private void moveTimer_Tick(object sender, EventArgs e)
      {
         figures.Move();
         drawShape();
      }

      private void ColorBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         drawShape();
      }

      private void Form1_FormClosed(object sender, FormClosedEventArgs e)
      {
         _shader.Unload();
      }

      private void Form1_Resize(object sender, EventArgs e)
      {
         
         mouse_hor = glControl1.Size.Width / 2;
         mouse_ver = glControl1.Size.Height / 2;
         drawShape();
      }

      private void abortToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void how20ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         string Caption = "Help";
         string help = "This is Space Shooter. Shooting objects increases your score! \n A = Rotate left \n D = Rotate right \n W = Move forward \n L = Force close \n P = Pause \n";
         var result = MessageBox.Show(help, Caption, MessageBoxButtons.OK);
      }

      /// <summary>
      /// In progress
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void glControl1_MouseMove(object sender, MouseEventArgs e)
      {
         Cursor.Position = new System.Drawing.Point((int)mouse_hor, (int)mouse_ver);

         int mx = e.X - MousePosition.X;
         int my = e.Y - MousePosition.Y;

         xCoord += mx;
         yCoord += my;

         while (xCoord >= 360 || xCoord < 0)
         {
            if (xCoord >= 360)
               xCoord -= 360;
            if (xCoord < 0)
               xCoord += 360;
         }
         while (yCoord >= 360 || yCoord < 0)
         {
            if (yCoord >= 360)
               yCoord -= 360;
            if (yCoord < 0)
               yCoord += 360;
         }

         drawShape();

         glxLabel.Text = "GLX: " + e.X;
         glyLabel.Text = "GLY: " + e.Y;

         xyViewLabel.Text = "{X: " + xCoord + ", Y: " + yCoord + "}";
      }

      /// <summary>
      /// In Progress
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Form1_KeyDown(object sender, KeyEventArgs e)
      {
         if( e.KeyCode == Keys.P )
         {
            // Freeze glControl
            // Unlock mouse from center of glControl1
         }

         if (e.KeyCode == Keys.L)
            Application.Exit();

         Vector3 direction = new Vector3(xCoord, yCoord, zCoord);
         if (e.KeyCode == Keys.W)
         {
            drawShape();
         }

         if (e.KeyCode == Keys.A)
         {
            // Rotate camera left
            drawShape();
         }

         if (e.KeyCode == Keys.D)
         {
            // Rotate camera right
            drawShape();
         }
      }

      private void Form1_MouseMove(object sender, MouseEventArgs e)
      {
         mouseXLabel.Text = "Form X: " + e.X;
         mouseYLabel.Text = "Form Y: " + e.Y;
      }

      private void Form1_Move(object sender, EventArgs e)
      {
         formLoc.Text = "Form: " + Form1.ActiveForm.Location;
      }

      private void LoadObjectTimer_Tick(object sender, EventArgs e)
      {
         loadShip();
         loadRock();
      }
   }
}