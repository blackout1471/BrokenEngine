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
        /// Whether the renderable has some data that has changed
        /// </summary>
        internal bool HasChanged { get => hasChanged; set => hasChanged = value; }

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
        private bool hasChanged = false;
        private Vec2[] vertices = null;
        private Color[] colors = null;
        private uint bufferOffset = 0;
        private Texture texture = null;
        private Vec2[,] textureOffsets = null;


        #region Methods

        /// <summary>
        /// Changes the color of the renderable
        /// </summary>
        /// <param name="newColor">the new color</param>
        public void ChangeColor(Color newColor)
        {
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = newColor;
            }

            HasChanged = true;
        }

        #endregion
    }
}
