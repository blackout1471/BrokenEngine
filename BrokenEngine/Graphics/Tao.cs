using OpenGL;

namespace BrokenEngine.Graphics
{
    class Tao
    {
        #region Properties

        /// <summary>
        /// The max texture width
        /// </summary>
        public static int LayerWidth { get { return layerWidth; } }

        /// <summary>
        /// The max texture height
        /// </summary>
        public static int LayerHeight { get { return layerHeight; } }

        public int Slot { get { return slot; } }

        #endregion

        #region Variables

        private static int layerWidth = 1024;
        private static int layerHeight = 1024;
        private static int layerDepth = 256;

        private int slot;
        private int curDepth;

        private uint id;

        #endregion

        #region Methods

        public Tao(int slot = 0)
        {
            this.slot = slot;
            this.curDepth = 0;

            int[] magFilter = new int[] { (int)TextureMagFilter.Linear };
            int[] minFilter = new int[] { (int)TextureMinFilter.Linear };
            int[] wrapFilter = new int[] { (int)TextureWrapMode.ClampToEdge };

            Gl.ActiveTexture(TextureUnit.Texture0 + slot);
            id = Gl.GenTexture();
            Gl.BindTexture(TextureTarget.Texture2dArray, id);
            Gl.TexStorage3D(TextureTarget.Texture2dArray, 1, InternalFormat.Rgba8, layerWidth, layerHeight, layerDepth);

            Gl.TexParameterI(TextureTarget.Texture2dArray, TextureParameterName.TextureMagFilter, magFilter);
            Gl.TexParameterI(TextureTarget.Texture2dArray, TextureParameterName.TextureMinFilter, minFilter);
            Gl.TexParameterI(TextureTarget.Texture2dArray, TextureParameterName.TextureWrapS, wrapFilter);
            Gl.TexParameterI(TextureTarget.Texture2dArray, TextureParameterName.TextureWrapT, wrapFilter);

            Gl.BindTexture(TextureTarget.Texture2dArray, 0);
        }

        /// <summary>
        /// Uploads a image to the 2d Texture array, and returns the id for the texture
        /// </summary>
        /// <param name="texture"></param>
        /// <returns></returns>
        public int Upload(Texture texture)
        {
            Bind();
            Gl.TexSubImage3D(TextureTarget.Texture2dArray, 0, 0, 0, curDepth, texture.Width, texture.Height, 1, PixelFormat.Bgra, PixelType.UnsignedByte, texture.ImageData);
            Unbind();

            int curId = curDepth;
            curDepth++;

            return curId;
        }

        /// <summary>
        /// bind the curent texture array
        /// </summary>
        public void Bind()
        {
            Gl.BindTexture(TextureTarget.Texture2dArray, id);
        }

        /// <summary>
        /// Unbind the current texture array
        /// </summary>
        public void Unbind()
        {
            Gl.BindTexture(TextureTarget.Texture2dArray, 0);
        }

        #endregion
    }
}
