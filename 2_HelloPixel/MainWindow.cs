using System;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

using OpenTK.Tutorials;

namespace _2_HelloTriangle
{
    public class MainWindow : GameWindow
    {
        // OpenGL Initialization Variables
        private static readonly int frameWidth = 640;
        private static readonly int frameHeight = 480;

        private int shaderProgram;

        // Vertices
        private int vertexArray;

        public MainWindow() : 
            base(frameWidth, frameHeight)
        {
            // Subscribe to the important window events.
            Load += Window_Load;
            RenderFrame += Window_RenderFrame;
            Closed += Window_Closed;
        }

        private void Window_Load(object sender, EventArgs e)
        {
            // Compile our vertex and fragment shader, and store the ID of the "program".
            shaderProgram = Utils.CreateProgram("SimpleShader.vert", "SimpleShader.frag");

            // Generate one Vertex Array Object (VAO), and put the resulting identifier in vertexArray.
            GL.GenVertexArrays(1, out vertexArray);

            // Tell OpenGL to use the resultant VAO.
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
    }
}
