using System;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

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

         var vertexPositionLoc = GL.GetAttribLocation(ShaderLoader.Instance.ProgramHandle, "VertexPosition");
         GL.EnableVertexAttribArray(vertexPositionLoc);
         GL.VertexAttribPointer(vertexPositionLoc, 3, VertexAttribPointerType.Float, false, BlittableValueType.StrideOf(verts), (IntPtr)0);

         var vertexNormalLoc = GL.GetAttribLocation(ShaderLoader.Instance.ProgramHandle, "VertexNormal");
         GL.EnableVertexAttribArray(vertexNormalLoc);
         GL.VertexAttribPointer(vertexNormalLoc, 3, VertexAttribPointerType.Float, false, BlittableValueType.StrideOf(verts), (IntPtr)24);

         var vertColorLoc = GL.GetAttribLocation(ShaderLoader.Instance.ProgramHandle, "VertexColor");
         GL.EnableVertexAttribArray(vertColorLoc);
         GL.VertexAttribPointer(vertColorLoc, 3, VertexAttribPointerType.Float, false, BlittableValueType.StrideOf(verts), (IntPtr)12);

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
         display = display * Matrix4.CreateTranslation(-midPoint);

         display = display * Matrix4.CreateRotationX(rotateX);
         display = display * Matrix4.CreateRotationY(rotateY);
         display = display * Matrix4.CreateRotationZ(rotateZ);

         display = display * Matrix4.CreateTranslation(translateAmount);
         display = display * Matrix4.CreateTranslation(midPoint);
      }



      public void Translate(float translateX, float translateY, float translateZ)
      {
         Matrix4 temp;
         translateAmount = translateAmount + new Vector3(translateX, translateY, translateZ);
         Matrix4.CreateTranslation(translateX, translateY, translateZ, out temp);
         Matrix4.Mult(display, temp);
      }

      public void Scale(float scaleX, float scaleY, float scaleZ)
      {
         display = display * Matrix4.CreateTranslation(-translateAmount);
         display = display * Matrix4.CreateTranslation(-midPoint);

         display = display * Matrix4.CreateScale(scaleX, scaleY, scaleZ);

         display = display * Matrix4.CreateTranslation(translateAmount);
         display = display * Matrix4.CreateTranslation(midPoint);
      }

      public void Show(Matrix4 lookAt)
      {
         GL.BindVertexArray(vaoHandle);

         var viewMatrixLoc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "ViewMatrix");
         GL.UniformMatrix4(viewMatrixLoc, false, ref lookAt);

         var modelview = display * Matrix4.CreateTranslation(translateAmount);
         var modelLoc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "ModelMatrix"); //ModelMatrix
         GL.UniformMatrix4(modelLoc, false, ref modelview);

         var normal = Matrix4.Transpose(Matrix4.Invert(modelview));
         var normalMatrixLoc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "NormalMatrix");
         GL.UniformMatrix4(normalMatrixLoc, false, ref normal);


         GL.DrawArrays(PrimitiveType.Triangles, 0, verts.Length);
         GL.BindVertexArray(0);
      }
      
      public void Reset()
      {
         display = Matrix4.CreateTranslation(-midPoint);

         translateAmount = new Vector3();
      }
   }
}