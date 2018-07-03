using System;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

using OpenTK.Tutorials;

namespace _3_Triangle
{
    public class MainWindow : GameWindow
    {
        // OpenGL Initialization Variables
        private static readonly int frameWidth = 640;
        private static readonly int frameHeight = 480;

        private int shaderProgram;

        // Vertices
        private int vertexArray;
        private int vertexBuffer;
        private readonly Vertex[] vertexBufferData = new Vertex[]
        {
            new Vertex(new Vector3(0.0f,  0.5f,  0.0f), Color4.CornflowerBlue),
            new Vertex(new Vector3(0.5f, -0.5f,  0.0f), Color4.CornflowerBlue),
            new Vertex(new Vector3(-0.5f, -0.5f,  0.0f), Color4.CornflowerBlue)
        };

        public MainWindow() :
            base(frameWidth, frameHeight)
        {
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

            // Create a Vertex Buffer Object (VBO).
            vertexBuffer = GL.GenBuffer();

            // Tell OpenGL to use the resultant VBO.
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBuffer);

            // Fill the VBO with vertex data.
            unsafe
            {
                GL.NamedBufferStorage(
                    vertexBuffer,
                    sizeof(Vertex) * vertexBufferData.Length,   // The size needed by this buffer
                    vertexBufferData,                           // Data to initialize with
                    BufferStorageFlags.MapWriteBit);            // At this point we will only write to the buffer
            }

            // Tell OpenGL about each element of our Vertex definition.
            GL.VertexArrayAttribBinding(vertexArray, 0, 0);
            GL.EnableVertexArrayAttrib(vertexArray, 0);
            GL.VertexArrayAttribFormat(
                vertexArray,
                0,                      // Attribute index, from the shader location = 0
                4,                      // Size of attribute, vec4
                VertexAttribType.Float, // Contains floats
                false,                  // Does not need to be normalized as it is already, floats ignore this flag anyway
                0);                     // Relative offset, first item
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
