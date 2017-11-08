using System;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Prog2
{
   public class Figure
   {
      private VertexData[] verts;
      private string name = "bob";
      private int vboHandle;
      private int vaoHandle;
      private Vector3 max;
      private Vector3 min;
      private Vector3 midPoint;

      private Vector3 translateAmount;

      private Matrix4 display = Matrix4.LookAt(25.0f, 25.0f, 25.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);

      private Vector3 yAxis = new Vector3(0.0f, 1.0f, 0.0f);
      private Vector3 xAxis = new Vector3(1.0f, 0.0f, 0.0f);
      private Vector3 zAxis = new Vector3(0.0f, 0.0f, 1.0f);

      public Figure(VertexDataList vertextData)
      {
         _FindBoundaries(vertextData);
         display = Matrix4.CreateTranslation(-midPoint);
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
         _ComputeMidPoint();
      }

      private void _ComputeMidPoint()
      {
         midPoint = (min + max) / 2.0f;
      }

      private void _CompareZ(float positionZ)
      {
         if ( positionZ < min.Z )
         {
            min.Z = positionZ;
            return;
         }
         
         if ( positionZ > max.Z )
            max.Z = positionZ;
      }

      private void _CompareY(float positionY)
      {
         if ( positionY < min.Y )
         {
            min.Y = positionY;
            return;
         }

         if (positionY > max.Y)
            max.Y = positionY;
      }

      private void _CompareX(float positionX)
      {
         if (positionX < min.X)
         {
            min.X = positionX;
            return;
         }

         if (positionX > max.X)
            max.X = positionX;
      }

      // translate before and after rotates - then + translate amount
      public void Rotate(float rotateX, float rotateY, float rotateZ)
      {
         display = display * Matrix4.CreateTranslation(-translateAmount);

         display = display * Matrix4.CreateRotationX(rotateX);
         display = display * Matrix4.CreateRotationY(rotateY);
         display = display * Matrix4.CreateRotationZ(rotateZ);

         display = display * Matrix4.CreateTranslation(translateAmount);
      }



      public void Translate(float translateX, float translateY, float translateZ)
      {
         Matrix4 temp;
         GL.MatrixMode(MatrixMode.Modelview);
         translateAmount = translateAmount + new Vector3(translateX, translateY, translateZ);
         Matrix4.CreateTranslation(translateX, translateY, translateZ, out temp);
         Matrix4.Mult(display, temp);
      }

      public void Scale(float scaleX, float scaleY, float scaleZ)
      {
         display = display * Matrix4.CreateTranslation(-translateAmount);

         display = display * Matrix4.CreateScale(scaleX, scaleY, scaleZ);

         display = display * Matrix4.CreateTranslation(translateAmount);
      }

      public void Show(Matrix4 lookAt)
      {
         //Matrix4 temp;

         GL.BindVertexArray(vaoHandle);
         var modelview = display * Matrix4.CreateTranslation(translateAmount) * lookAt;
         
         GL.LoadMatrix(ref modelview);


         GL.DrawArrays(PrimitiveType.Triangles, 0, verts.Length);
         GL.BindVertexArray(0);
      }
   }
}