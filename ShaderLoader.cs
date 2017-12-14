// Only handles Vertex and Fragment Shaders.  
// You Comment it!  Be sure to note the Singleton pattern


using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using OpenTK;
using OpenTK.Graphics.OpenGL;


public class ShaderLoader
{
   private string loadError = "";
   private int vertexHandle = 0;
   private int fragmentHandle = 0;
   private int programHandle = 0;

   private static ShaderLoader _instance = null;

   public static ShaderLoader Instance
   {
      get
      {
         if (_instance == null)
            _instance = new ShaderLoader();
         return _instance;
      }
   }

   private ShaderLoader()
   {
      // An instance cannot be created outside of this class - Singleton!
   }
   

   public int ProgramHandle
   {
      get { return programHandle; }
   }

   public bool Load (string vertexShaderFileName, string fragmentShaderFileName)
   {
      Unload();   // Unload just in case something was loaded

      vertexHandle = GL.CreateShader(ShaderType.VertexShader);
      fragmentHandle = GL.CreateShader(ShaderType.FragmentShader);

      if (vertexHandle == 0 || fragmentHandle == 0)
      {
         loadError = "CreateShader call failed";
         return false;
      }

      if (!LoadAndCompileShader(vertexShaderFileName, vertexHandle))
         return false;

      if (!LoadAndCompileShader(fragmentShaderFileName, fragmentHandle))
      {
         Unload();
         return false;
      }

      programHandle = GL.CreateProgram();
      if (programHandle == 0)
      {
         Unload();
         loadError = "CreateProgram call failed";
         return false;
      }

      try
      {
         GL.AttachShader(programHandle, vertexHandle);
         GL.AttachShader(programHandle, fragmentHandle);

         GL.LinkProgram(programHandle);

         GL.UseProgram(programHandle);

         GL.DetachShader(programHandle, vertexHandle);
         GL.DetachShader(programHandle, fragmentHandle);

         return true;
      }
      catch (Exception ex)
      {
         Unload();
         loadError = ex.Message;
         return false;
      }
   }

   public void Unload()
   {
      if (programHandle != 0)
      {
         GL.DeleteProgram(programHandle);
         programHandle = 0;
      }

      if (fragmentHandle != 0)
      {
         GL.DeleteShader(fragmentHandle);
         fragmentHandle = 0;
      }

      if (vertexHandle != 0)
      {
         GL.DeleteShader(vertexHandle);
         vertexHandle = 0;
      }
      loadError = "";
   }

   public string LastLoadError
   {
      get { return loadError; }
   }

   private bool LoadAndCompileShader(string fileName, int handle)
   {
      int status;
      string logInfo;

      try
      {
         StreamReader streamReader = new StreamReader(fileName);
         string shaderSource = streamReader.ReadToEnd();
         streamReader.Close();
         GL.ShaderSource(handle, shaderSource);
         GL.CompileShader(handle);
         GL.GetShaderInfoLog(handle, out logInfo);
         GL.GetShader(handle, ShaderParameter.CompileStatus, out status);
         if (status == 0)
         {
            GL.DeleteShader(handle);
            loadError = logInfo;
            return false;
         }
         return true;
      }
      catch (Exception ex)
      {
         loadError = ex.Message;
         return false;
      }
   }

}
