using BrokenEngine.Maths;
using BrokenEngine.Graphics;

namespace BrokenEngine.Components
{
    public class Sprite : Renderable
    {
        #region Properties
        public string TextureName { get => textureName; }
        public string TexturePath { get => Texture.Path; }
        #endregion

        private Vec2 size;
        private string textureName;

        public Sprite(string textureName, Vec2 size, Color color)
        {
            this.size = size / 2;
            Colors = new Color[4];
            Vertices = new Vec2[4];
            TextureOffsets = new Vec2[1, 4];

            for (int i = 0; i < Colors.Length; i++)
            {
                Colors[i] = color;
            }

            Vertices[0] = new Vec2(0 - this.size.X, 0 - this.size.Y);
            Vertices[1] = new Vec2(0 + this.size.X, 0 - this.size.Y);
            Vertices[2] = new Vec2(0 + this.size.X, 0 + this.size.Y);
            Vertices[3] = new Vec2(0 - this.size.X, 0 + this.size.Y);

            this.textureName = textureName;
            Texture = TextureManager.Instance.GetTexture(textureName);
            float xoff = (float)(Tao.LayerWidth - (Tao.LayerWidth - Texture.Width)) / Tao.LayerWidth;
            float yoff = (float)(Tao.LayerHeight - (Tao.LayerHeight - Texture.Height)) / Tao.LayerHeight;

            TextureOffsets[0, 0] = new Vec2(0, 0);
            TextureOffsets[0, 1] = new Vec2(xoff, 0);
            TextureOffsets[0, 2] = new Vec2(xoff, yoff);
            TextureOffsets[0, 3] = new Vec2(0, yoff);
        }

        /// <summary>
        /// Change the sprite of the current component
        /// </summary>
        /// <param name="textureName"></param>
        public void ChangeSprite(string textureName)
        {
            Texture = TextureManager.Instance.GetTexture(textureName);
            float xoff = (float)(Tao.LayerWidth - (Tao.LayerWidth - Texture.Width)) / Tao.LayerWidth;
            float yoff = (float)(Tao.LayerHeight - (Tao.LayerHeight - Texture.Height)) / Tao.LayerHeight;

            TextureOffsets[0, 0] = new Vec2(0, 0);
            TextureOffsets[0, 1] = new Vec2(xoff, 0);
            TextureOffsets[0, 2] = new Vec2(xoff, yoff);
            TextureOffsets[0, 3] = new Vec2(0, yoff);

            this.textureName = textureName;
            HasChanged = true;
        }
    }
}
