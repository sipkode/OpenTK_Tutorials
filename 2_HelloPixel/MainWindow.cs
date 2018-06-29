using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace _2_HelloTriangle
{
    public class MainWindow : GameWindow
    {
        // OpenGL Initialization Variables
        private static readonly int frameWidth = 640;
        private static readonly int frameHeight = 480;

        private int shaderProgram;

        // Vertices
        private readonly Vertex[] vertexBufferData = new Vertex[]
        {
            new Vertex(new Vector3(0.0f,  0.5f,  0.0f), Color4.CornflowerBlue),
            new Vertex(new Vector3(0.5f, -0.5f,  0.0f), Color4.CornflowerBlue),
            new Vertex(new Vector3(-0.5f, -0.5f,  0.0f), Color4.CornflowerBlue)
        };
        private int vertexArray;

        public MainWindow() : 
            base(frameWidth, frameHeight)
        {
            Load += Window_Load;
            RenderFrame += Window_RenderFrame;
            Closed += Window_Closed;
        }

        private void Window_Load(object sender, EventArgs e)
        {
            shaderProgram = CreateProgram("SimpleShader.vert", "SimpleShader.frag");
            GL.GenVertexArrays(1, out vertexArray);
            GL.BindVertexArray(vertexArray);
        }

        private void Window_RenderFrame(object sender, FrameEventArgs e)
        {
            // Set the clear flags
            Color4 backColor = Color4.CornflowerBlue;
            GL.ClearColor(backColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Use our custom shaders
            GL.UseProgram(shaderProgram);

            // Draw a single point
            GL.DrawArrays(PrimitiveType.Points, 0, 1);
            GL.PointSize(10);
            SwapBuffers();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            GL.DeleteVertexArrays(1, ref vertexArray);
            GL.DeleteProgram(shaderProgram);
        }

        private int CreateProgram(string vertexShaderPath, string fragmentShaderPath)
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

        private int CompileShader(ShaderType type, string path)
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
