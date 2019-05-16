using BrokenEngine.Graphics;
using BrokenEngine.Maths;

namespace BrokenEngine.Components
{
    public class Quad : Renderable
    {
        private Vec2 size;

        public Quad(Vec2 size, Color color)
        {
            this.size = size / 2;
            Colors = new Color[4];
            Vertices = new Vec2[4];

            for (int i = 0; i < Colors.Length; i++)
            {
                Colors[i] = color;
            }

            Vertices[0] = new Vec2(0- this.size.X, 0- this.size.Y);
            Vertices[1] = new Vec2(0+ this.size.X, 0- this.size.Y);
            Vertices[2] = new Vec2(0+ this.size.X, 0+ this.size.Y);
            Vertices[3] = new Vec2(0- this.size.X, 0+ this.size.Y);
        }
    }
}
