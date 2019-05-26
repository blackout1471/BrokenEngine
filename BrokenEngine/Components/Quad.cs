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

        /// <summary>
        /// Create a quad with multiple colors
        /// </summary>
        /// <param name="size"></param>
        /// <param name="color1"></param>
        /// <param name="color2"></param>
        /// <param name="color3"></param>
        /// <param name="color4"></param>
        public Quad(Vec2 size, Color color1, Color color2, Color color3, Color color4)
        {
            this.size = size / 2;
            Colors = new Color[4];
            Vertices = new Vec2[4];

            Colors[0] = color1;
            Colors[1] = color2;
            Colors[2] = color3;
            Colors[3] = color4;

            Vertices[0] = new Vec2(0 - this.size.X, 0 - this.size.Y);
            Vertices[1] = new Vec2(0 + this.size.X, 0 - this.size.Y);
            Vertices[2] = new Vec2(0 + this.size.X, 0 + this.size.Y);
            Vertices[3] = new Vec2(0 - this.size.X, 0 + this.size.Y);
        }
    }
}
