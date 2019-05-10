using System.Collections.Generic;

namespace BrokenEngine.Graphics
{
    class TextureManager
    {
        #region Singleton

        public TextureManager Instance { get; }
        private TextureManager instance = null;
        private TextureManager() { }

        #endregion

        #region Variables

        private Dictionary<string, Texture> textures;
        private Tao textureArray;

        #endregion

        #region Methods

        public void LoadTexture(string name, Texture texture) { throw new System.NotImplementedException(); }
        internal Texture GetTexture(string name) { throw new System.NotImplementedException(); }
        internal void BindTextureArrayToShader(string uniform, Shader shader) { throw new System.NotImplementedException(); }
        internal void BindTextureArray() { throw new System.NotImplementedException(); }
        internal void UnbindTextureArray() { throw new System.NotImplementedException(); }

        #endregion
    }
}
