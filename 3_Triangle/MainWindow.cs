using System;
using OpenTK;
using OpenTK.Graphics;

namespace _3_Triangle
{
    public class MainWindow : GameWindow
    {
        private readonly Vertex[] vertexBufferData = new Vertex[]
        {
            new Vertex(new Vector3(0.0f,  0.5f,  0.0f), Color4.CornflowerBlue),
            new Vertex(new Vector3(0.5f, -0.5f,  0.0f), Color4.CornflowerBlue),
            new Vertex(new Vector3(-0.5f, -0.5f,  0.0f), Color4.CornflowerBlue)
        };

    }
}
