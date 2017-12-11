using System;
using System.Windows.Forms;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using AlienSpaceShooter.MovePatterns;
using System.Drawing;
using System.Threading.Tasks;

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
      private Point center;
      private bool mouseIsLocked;
      private bool moveFigures;
      private int numberOfmoves;

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
        // Matrix4 lookat = Ship.Instance.LookAt();//Matrix4.LookAt(xCoord, yCoord, 0.0f, 0f, 0f, 0f, 0f, 1.0f, 0f);

         //light
         lightSource = new Vector3((float)5, (float)5, (float)5);
         var lightSourceLocaiton = GL.GetUniformLocation(_shader.ProgramHandle, "LightPosition");
         GL.Uniform3(lightSourceLocaiton, lightSource);

         //global shiny
         var shininessLoc = GL.GetUniformLocation(_shader.ProgramHandle, "Shininess");
         GL.Uniform1(shininessLoc, 1f);

         //color
         var lightColorLoc = GL.GetUniformLocation(_shader.ProgramHandle, "LightColor");
         _SetColor(lightColorLoc);
         var viewMatrixLoc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "ViewMatrix");


         //GL.UniformMatrix4(viewMatrixLoc, false, ref lookat);

         //ambient
         var ambientLoc = GL.GetUniformLocation(_shader.ProgramHandle, "GlobalAmbient");
         GL.Uniform1(ambientLoc, (0.3f));

         figures?.Show(Ship.Instance.LookAt());

         axis.Show(Ship.Instance.LookAt());
         glControl1.SwapBuffers();
      }

      private void _SetColor(int lightColorLoc)
      {
         switch (ColorBox.Text)
         {
            case "White":
               GL.Uniform3(lightColorLoc, new Vector3(1f, 1f, 1f));
               break;
            case "Black":
               GL.Uniform3(lightColorLoc, new Vector3(0f, 0f, 0f));
               break;
            case "Red":
               GL.Uniform3(lightColorLoc, new Vector3(1f, 0f, 0f));
               break;
            case "Green":
               GL.Uniform3(lightColorLoc, new Vector3(0f, 1f, 0f));
               break;
            case "Blue":
               GL.Uniform3(lightColorLoc, new Vector3(0f, 0f, 1f));
               break;
            case "Magenta":
               GL.Uniform3(lightColorLoc, new Vector3(1f, 0f, 1f));
               break;
            case "Yellow":
               GL.Uniform3(lightColorLoc, new Vector3(1f, 1f, 0f));
               break;
         }
      }

      private void Form1_Shown(object sender, EventArgs e)
      {
         center = new Point(this.Location.X + glControl1.Left + glControl1.Width / 2, this.Location.Y + glControl1.Top + glControl1.Height / 2);
         // var centerBox = glControl1.RectangleToScreen(new)
         Cursor.Position = center;
         Cursor.Hide(); //= new Size(0, 0);
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
         ColorBox.SelectedIndex = 2;
         ColorBox.Enabled = false;
         figures = new FigureList();
         mouseIsLocked = true;
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
         if (moveFigures)
         {
            moveFigures = false;
            figures.Move();

            drawShape();
         }
         else
         {
            moveFigures = true;
         }
         
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
         center = new Point(this.Location.X + glControl1.Left + glControl1.Width / 2, this.Location.Y + glControl1.Top + glControl1.Height / 2);
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
         Task.Factory.StartNew(() =>
         {
            //Cursor.Position = center;
            if (!moveFigures)
            {
               moveFigures = true;
               if (mouseIsLocked)
               {
                  Cursor.Position = center;
                  var eventRealx = e.X + glControl1.Location.X + this.Location.X + 8;
                  var eventRealy = e.Y + glControl1.Location.Y + this.Location.Y + 31;
                  var newX = 0.0f;
                  var newY = 0.0f;

                  if (eventRealx < center.X)
                  {
                     newX = -0.01f;
                  }
                  else if (eventRealx > center.X)
                  {
                     newX = .01f;
                  }
                  if (eventRealy < center.Y)
                  {
                     newY = -.01f;
                  }
                  else if (eventRealy > center.Y)
                  {
                     newY = .01f;
                  }

                  Ship.Instance.ChangeDirection(newX, newY);

                  try
                  {
                     glxLabel.Text = "GLX: " + e.X;
                     glyLabel.Text = "GLY: " + e.Y;
                     xyViewLabel.Text = "{X: " + xCoord + ", Y: " + yCoord + "}";
                  }
                  catch (InvalidOperationException v)
                  {

                  }


               }
            }
            //drawShape();
         });
      }

      /// <summary>
      /// In Progress
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Form1_KeyDown(object sender, KeyEventArgs e)
      {
         Task.Factory.StartNew(() =>
         {
            //if (e.KeyCode == Keys.P)
            //{
            //   // Freeze glControl
            //   // Unlock mouse from center of glControl1
            //   mouseLocked = !mouseLocked;
            //   if (mouseLocked)
            //   {
            //      LoadObjectTimer.Stop();
            //      moveTimer.Stop();
            //   }
            //   else
            //   {
            //      LoadObjectTimer.Start();
            //      moveTimer.Start();
            //   }
            //}

            //if (e.KeyCode == Keys.L)
            //{
            //   Form1.ActiveForm.Close();
            //   //Application.Exit();
            //}

            //Vector3 direction = new Vector3(xCoord, yCoord, zCoord);
            //if (e.KeyCode == Keys.W)
            //{
            //   //Ship.Instance.ChangeDirection(;
            //   Ship.Instance.Move(5);
            //   drawShape();
            //}

            //if (e.KeyCode == Keys.A)
            //{
            //   //TODO figure out left move
            //   Ship.Instance.ChangeDirection(90, 90);
            //   Ship.Instance.Move(5);
            //   Ship.Instance.ChangeDirection(-90, -90);
            //   // Rotate camera left
            //   drawShape();
            //}

            //if (e.KeyCode == Keys.D)
            //{
            //   //TODO figure out right move
            //   Ship.Instance.ChangeDirection(-90, -90);
            //   Ship.Instance.Move(5);
            //   Ship.Instance.ChangeDirection(90, 90);
            //   // Rotate camera right
            //   drawShape();
            //}
         });
      }

      private void Form1_MouseMove(object sender, MouseEventArgs e)
      {
         mouseXLabel.Text = "Form X: " + e.X;
         mouseYLabel.Text = "Form Y: " + e.Y;
      }

      private void Form1_Move(object sender, EventArgs e)
      {
         try
         {
            formLoc.Text = "Form: " + Form1.ActiveForm.Location;
         }
         catch (NullReferenceException p)
         {

         }

      }

      private void LoadObjectTimer_Tick(object sender, EventArgs e)
      {
         loadShip();
         loadRock();
         drawShape();
      }

      private void glControl1_KeyDown(object sender, KeyEventArgs e)
      {
         Task.Factory.StartNew(() =>
         {
            if(!moveFigures)
            if (e.KeyCode == Keys.L)
            {
               Form1.ActiveForm.Close();
            }

            if (e.KeyCode == Keys.P)
            {
               // Freeze glControl
               // Unlock mouse from center of glControl1
               mouseIsLocked = !mouseIsLocked;
               if (!mouseIsLocked)
               {
                  ColorBox.Enabled = true;
                  LoadObjectTimer.Stop();
                  moveTimer.Stop();
                  Cursor.Show();
               }
               else
               {
                  ColorBox.Enabled = false;
                  LoadObjectTimer.Start();
                  moveTimer.Start();
                  Cursor.Hide();
               }
            }

            //--------------------------------------------------------------
            //Here are all the controls.
            //--------------------------------------------------------------
            Vector3 direction = new Vector3(xCoord, yCoord, zCoord);
            if (e.KeyCode == Keys.W)
            {
               Ship.Instance.Move(1);
            }

            if (e.KeyCode == Keys.A)
            {
               //TODO figure out left move;
            }

            if (e.KeyCode == Keys.S)
            {
               Ship.Instance.Move(-1);
            }

            if (e.KeyCode == Keys.D)
            {
               //TODO figure out right move
            }
         });
      }
   }
}