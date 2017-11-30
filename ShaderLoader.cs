//-----------------------------------------------------------------------
// This class loads the shaders from the Prog4_FS and Prog4_VS files.
// Contributers: Vince Seeley, William Maclay
//-----------------------------------------------------------------------

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

   /// <summary>
   /// Creates an instance of ShaderLoader.
   /// </summary>
   public static ShaderLoader Instance
   {
      get
      {
         if (_instance == null)
            _instance = new ShaderLoader();
         return _instance;
      }
   }

   /// <summary>
   /// Default constructor to ensure that the class only has one 
   /// instance of ShaderLoader.
   /// </summary>
   private ShaderLoader()
   {
      // An instance cannot be created outside of this class - Singleton!
   }

   /// <summary>
   /// returns the Program Handle.
   /// </summary>
   /// <returns> int programHandle </returns>
   public int ProgramHandle
   {
      get { return programHandle; }
   }

   /// <summary>
   /// Loads the shaders from the files Prog4_FS and Prog4_VS to get the
   /// fragment shader and the vertex shader respectively and returns the
   /// load check as a boolean value.
   /// </summary>
   /// <param name="vertexShaderFileName"></param>
   /// <param name="fragmentShaderFileName"></param>
   /// <returns> boolean </returns>
   public bool Load(string vertexShaderFileName, string fragmentShaderFileName)
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

   /// <summary>
   /// Unloads the current active shader.
   /// </summary>
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

   /// <summary>
   /// Returns the most recent load error as a string.
   /// </summary>
   /// <returns> string loadError </returns>
   public string LastLoadError
   {
      get { return loadError; }
   }

   /// <summary>
   /// Loads and Compiles the shader into the program from a file and
   /// returns the load check in the form of a boolean value.
   /// </summary>
   /// <param name="fileName"></param>
   /// <param name="handle"></param>
   /// <returns> boolean </returns>
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
