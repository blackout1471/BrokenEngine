using BrokenEngine.Maths;
using BrokenEngine.Graphics;

namespace BrokenEngine.Components
{
    public abstract class Renderable : BaseComponent
    {
        #region Properties

        /// <summary>
        /// whether the component has been submitted
        /// </summary>
        internal bool IsSubmitted { get { return isSubmitted; } set { isSubmitted = value; } }

        /// <summary>
        /// The vertices for the component
        /// </summary>
        internal Vec2[] Vertices { get { return vertices; } set { vertices = value; } }

        /// <summary>
        /// The colors of the component
        /// </summary>
        internal Color[] Colors { get { return colors; } set { colors = value; } }

        /// <summary>
        /// The bufferoffset in the vbo buffer for the component
        /// </summary>
        internal uint BufferOffset { get { return bufferOffset; } set { bufferOffset = value; } }

        /// <summary>
        /// the texture which the component hold
        /// </summary>
        internal Texture Texture { get { return texture; } set { texture = value; } }

        /// <summary>
        /// The texture offsets for the components texture
        /// </summary>
        internal Vec2[,] TextureOffsets { get { return textureOffsets; } set { textureOffsets = value; } }

        #endregion

        private bool isSubmitted = false;
        private Vec2[] vertices;
        private Color[] colors;
        private uint bufferOffset;
        private Texture texture;
        private Vec2[,] textureOffsets;


    }
}
