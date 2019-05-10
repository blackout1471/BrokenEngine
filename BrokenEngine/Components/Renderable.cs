using BrokenEngine.Maths;
using BrokenEngine.Graphics;

namespace BrokenEngine.Components
{
    public abstract class Renderable : BaseComponent
    {
        #region Properties

        internal bool IsSubmitted { get; set; }
        internal Vec2 Vertices { get; set; }
        internal Color Colors { get; set; }
        internal uint BufferOffset { get; set; }
        internal Texture Texture { get; set; }
        internal Vec2[,] TextureOffsets { get; set; }

        #endregion

        private bool isSubmitted;
        private Vec2 vertices;
        private Color[] colors;
        private uint bufferOffset;
        private Texture texture;
        private Vec2[,] textureOffsets;


    }
}
