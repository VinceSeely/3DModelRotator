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

   private Axes()
   {
      // Make the Vertex Buffer Object (VBO) and Vertex Array Object (VAO)
      GL.GenBuffers(1, out vboHandle);
      GL.BindBuffer(BufferTarget.ArrayBuffer, vboHandle);
      GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(verts.Length * BlittableValueType.StrideOf(verts)), verts, BufferUsageHint.StaticDraw);

      GL.GenVertexArrays(1, out vaoHandle);
      GL.BindVertexArray(vaoHandle);
      GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);

      //GL.Enable(EnableCap.ColorTable);
      //GL.Enable(EnableCap.VertexProgramPointSize);

      var vertColorLoc = GL.GetAttribLocation(ShaderLoader.Instance.ProgramHandle, "Vertex Color");
      GL.EnableVertexAttribArray(vertColorLoc);
      GL.VertexAttribPointer(vertColorLoc, 3, VertexAttribPointerType.Float, true, 36, 12);

      GL.BindVertexArray(0);
   }


   public void Show(Matrix4 lookat)
   {
      GL.BindVertexArray(vaoHandle);

      var viewMatrixLoc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "ViewMatrix");
      GL.UniformMatrix4(viewMatrixLoc, false, ref lookat);

      GL.DrawArrays(PrimitiveType.Lines, 0, verts.Length);
      GL.BindVertexArray(0);
   }
}
