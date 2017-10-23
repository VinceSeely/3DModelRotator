using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Prog2
{
   public class Figure
   {
      private VertexData[] verts;
      private string name = null;
      private int vboHandle;
      private int vaoHandle;

      public Figure(VertexDataList vertextData)
      {
         verts = vertextData.VertexArray();
         // Make the Vertex Buffer Object (VBO) and Vertex Array Object (VAO)
         GL.GenBuffers(1, out vboHandle);
         GL.BindBuffer(BufferTarget.ArrayBuffer, vboHandle);
         GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(verts.Length * BlittableValueType.StrideOf(verts)), verts, BufferUsageHint.StaticDraw);

         GL.GenVertexArrays(1, out vaoHandle);
         GL.BindVertexArray(vaoHandle);

         GL.EnableClientState(ArrayCap.VertexArray);
         GL.EnableClientState(ArrayCap.ColorArray);

         GL.VertexPointer(3, VertexPointerType.Float, BlittableValueType.StrideOf(verts), (IntPtr)0);
         GL.ColorPointer(3, ColorPointerType.Float, BlittableValueType.StrideOf(verts), (IntPtr)12);

         GL.BindVertexArray(0);
      }


      public void Show()
      {
         GL.BindVertexArray(vaoHandle);
         GL.DrawArrays(PrimitiveType.Triangles, 0, verts.Length);
         GL.BindVertexArray(0);
      }
   }
}