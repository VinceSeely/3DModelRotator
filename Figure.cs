using System;
using System.Windows.Forms;
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
      private Vector3 max;
      private Vector3 min;

      public Figure(VertexDataList vertextData)
      {
         _FindBoundaries(vertextData);
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

      private void _FindBoundaries(VertexDataList vertextData)
      {
         foreach (var vertex in vertextData.VertexArray())
         {
            if (vertex.Equals(vertextData.VertexArray()[0]))
            {
               min = vertex.Position;
               max = vertex.Position;
            }
            _CompareX(vertex.Position.X);
            _CompareY(vertex.Position.Y);
            _CompareZ(vertex.Position.Z);
         }
      }

      private void _CompareZ(float positionZ)
      {
         throw new NotImplementedException();
      }

      private void _CompareY(float positionY)
      {
         throw new NotImplementedException();
      }

      private void _CompareX(float positionX)
      {
         throw new NotImplementedException();
      }

      public void Rotate(float rotateX, float rotateY, float rotateZ)
      {
         _RotateX(rotateX);
         _RotateY(rotateY);
         _RotateZ(rotateZ);
      }

      private void _RotateY(float rotateY)
      {
         throw new NotImplementedException();
      }

      private void _RotateX(float rotateX)
      {
         throw new NotImplementedException();
      }

      private void _RotateZ(float rotateZ)
      {
         throw new NotImplementedException();
      }

      public void Translate(float translateX, float translateY, float translateZ)
      {
         _TranslateY(translateY);
         _TranslateX(translateX);
         _TranslateZ(translateZ);
      }

      private void _TranslateY(float translateY)
      {
         throw new NotImplementedException();
      }

      private void _TranslateX(float translateX)
      {
         throw new NotImplementedException();
      }

      private void _TranslateZ(float translateZ)
      {
         throw new NotImplementedException();
      }

      public void Scale(float scaleX, float scaleY, float scaleZ)
      {
         _ScaleY(scaleY);
         _ScaleX(scaleX);
         _ScaleZ(scaleZ);
      }

      private void _ScaleZ(float scaleZ)
      {
         throw new NotImplementedException();
      }

      private void _ScaleX(float scaleX)
      {
         throw new NotImplementedException();
      }

      private void _ScaleY(float scaleY)
      {
         throw new NotImplementedException();
      }

      public void Show()
      {
         GL.BindVertexArray(vaoHandle);
         GL.DrawArrays(PrimitiveType.Triangles, 0, verts.Length);
         GL.BindVertexArray(0);
      }
   }
}