using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using OpenTK.Graphics.OpenGL4;

namespace OpenTK_Tutorials
{
    internal class Utils
    {
        public static int CreateProgram(string vertexShaderPath, string fragmentShaderPath)
        {
            try
            {
                int program = GL.CreateProgram();
                List<int> shaders = new List<int>
                {
                    CompileShader(ShaderType.VertexShader, vertexShaderPath),
                    CompileShader(ShaderType.FragmentShader, fragmentShaderPath)
                };

                foreach (var shader in shaders)
                {
                    GL.AttachShader(program, shader);
                }

                GL.LinkProgram(program);
                string info = GL.GetProgramInfoLog(program);

                if (!string.IsNullOrWhiteSpace(info))
                {
                    throw new Exception($"CompileShaders ProgramLinking had errors: {info}");
                }

                foreach (var shader in shaders)
                {
                    GL.DetachShader(program, shader);
                    GL.DeleteShader(shader);
                }
                return program;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        public static int CompileShader(ShaderType type, string path)
        {
            int shader = GL.CreateShader(type);
            string src = File.ReadAllText(path);
            GL.ShaderSource(shader, src);
            GL.CompileShader(shader);
            string info = GL.GetShaderInfoLog(shader);

            if (!string.IsNullOrWhiteSpace(info))
            {
                throw new Exception($"CompileShader {type} had errors: {info}");
            }

            return shader;
        }
    }
}