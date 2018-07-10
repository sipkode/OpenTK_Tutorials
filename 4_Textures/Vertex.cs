using OpenTK;
using OpenTK.Graphics;

namespace _4_Textures
{
    public struct Vertex
    {
        private readonly Vector3 position;
        private readonly Vector2 texCoord;

        public Vertex(Vector3 position, Vector2 texCoord)
        {
            this.position = position;
            this.texCoord = texCoord;
        }
    }
}
