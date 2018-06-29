using OpenTK;
using OpenTK.Graphics;

namespace _3_Triangle
{
    public class Vertex
    {
        private readonly Vector3 position;
        private readonly Color4 color;

        public Vertex(Vector3 position, Color4 color)
        {
            this.position = position;
            this.color = color;
        }
    }
}
