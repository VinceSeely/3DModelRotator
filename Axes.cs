// You finish verts and comment this file.
// It uses the Singleton pattern

using System;

using OpenTK;
using OpenTK.Graphics.OpenGL4;


public class Axes
{
   private static Axes _instance = null;
   private int vboHandle;
   private int vaoHandle;

   private VertexData[] verts =
   {
      new VertexData(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(1.0f, 0.0f, 0.0f), new Vector3(1.0f, 1.0f, 1.0f)),
      new VertexData(new Vector3(200.0f, 0.0f, 0.0f), new Vector3(1.0f, 0.0f, 0.0f), new Vector3(1.0f, 1.0f, 1.0f)),
      new VertexData(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), new Vector3(1.0f, 1.0f, 1.0f)),
      new VertexData(new Vector3(0.0f, 200.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), new Vector3(1.0f, 1.0f, 1.0f)),
      new VertexData(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 1.0f), new Vector3(1.0f, 1.0f, 1.0f)),
      new VertexData(new Vector3(0.0f, 0.0f, 200.0f), new Vector3(0.0f, 0.0f, 1.0f), new Vector3(1.0f, 1.0f, 1.0f)),
   };

   public static Axes Instance
   {
      get
      {
         if (_instance == null)
            _instance = new Axes();
         return _instance;
      }
   }

   //GL.Enable(EnableCap.ColorTable);
   //GL.Enable(EnableCap.VertexProgramPointSize);

   //Seth was here and here is the reference https://open.gl/drawing
   //--------------------------------------------------------------------
   //var vertexShader = GL.CreateShader(ShaderType.VertexShader);
   //GL.GetShaderSource(vertexShader, 1, out  null)

   private Axes()
   {
      // Make the Vertex Buffer Object (VBO) and Vertex Array Object (VAO)
      GL.GenBuffers(1, out vboHandle);
      GL.BindBuffer(BufferTarget.ArrayBuffer, vboHandle);
      GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(verts.Length * BlittableValueType.StrideOf(verts)), verts, BufferUsageHint.StaticDraw);

      GL.GenVertexArrays(1, out vaoHandle);
      GL.BindVertexArray(vaoHandle);

      var vertexPositionLoc = GL.GetAttribLocation(ShaderLoader.Instance.ProgramHandle, "VertexPosition");
      GL.EnableVertexAttribArray(vertexPositionLoc);
      GL.VertexAttribPointer(vertexPositionLoc, 3, VertexAttribPointerType.Float, true, 36, 0);

      var vertexNormalLoc = GL.GetAttribLocation(ShaderLoader.Instance.ProgramHandle, "VertexNormal");
      GL.EnableVertexAttribArray(vertexNormalLoc);
      GL.VertexAttribPointer(vertexNormalLoc, 3, VertexAttribPointerType.Float, true, 36, 0);

      var vertColorLoc = GL.GetAttribLocation(ShaderLoader.Instance.ProgramHandle, "VertexColor");
      GL.EnableVertexAttribArray(vertColorLoc);
      GL.VertexAttribPointer(vertColorLoc, 3, VertexAttribPointerType.Float, true, 36, 0);

      GL.BindVertexArray(0);
   }


   public void Show(Matrix4 lookat)
   {

      var viewMatrixLoc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "ViewMatrix");
      GL.UniformMatrix4(viewMatrixLoc, false, ref lookat);

      var identity = Matrix4.Identity;
      var modleLoc = GL.GetAttribLocation(ShaderLoader.Instance.ProgramHandle, "ModelMatrix");
      GL.UniformMatrix4(modleLoc, false, ref identity);

      var normal = Matrix4.Transpose(Matrix4.Invert(identity));
      var normalMatrixLoc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "NormalMatrix");
      GL.UniformMatrix4(normalMatrixLoc, false, ref normal);

      GL.BindVertexArray(vaoHandle);

      GL.DrawArrays(PrimitiveType.Lines, 0, verts.Length);
      GL.BindVertexArray(0);
      
   }
}
