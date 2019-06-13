using System.Collections.Generic;
using BrokenEngine.Utils;

namespace BrokenEngine.Graphics
{
    public class TextureManager
    {
        #region Singleton

        public static TextureManager Instance { get { if (instance == null) instance = new TextureManager(); return instance; } }
        private static TextureManager instance = null;
        private TextureManager() { }

        #endregion

        #region Variables

        private Dictionary<string, Texture> textures = new Dictionary<string, Texture>();
        private Dictionary<string, Font> fonts = new Dictionary<string, Font>();

        private Tao textureArray = new Tao(0);

        #endregion

        #region Methods

        /// <summary>
        /// Loads a texture into the texture array
        /// </summary>
        /// <param name="name"></param>
        /// <param name="texture"></param>
        public void LoadTexture(string name, Texture texture)
        {
            if (textures.ContainsKey(name))
            {
                Debug.Log("Can't add texture with the same name", Debug.DebugLayer.Textures, Debug.DebugLevel.Warning);
                return;
            }

            texture.Id = textureArray.Upload(texture);
            textures.Add(name, texture);

            Debug.Log("Texture has been added with name: " + name, Debug.DebugLayer.Textures, Debug.DebugLevel.Information);
        }

        /// <summary>
        /// Load fonts
        /// </summary>
        /// <param name="name"></param>
        /// <param name="font"></param>
        public void LoadFont(string name, Font font)
        {
            if (fonts.ContainsKey(name))
            {
                Debug.Log("Can't add font with the same name", Debug.DebugLayer.Textures, Debug.DebugLevel.Warning);
                return;
            }

            font.Texture.Id = textureArray.Upload(font.Texture);
            fonts.Add(name, font);

            Debug.Log("Font has been added with name: " + name, Debug.DebugLayer.Textures, Debug.DebugLevel.Information);
        }

        /// <summary>
        /// Get a texture from a name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal Texture GetTexture(string name)
        {
            if (textures.ContainsKey(name))
            {
                return textures[name];
            }

            Debug.Log("Could'nt find texture with name: " + name, Debug.DebugLayer.Textures, Debug.DebugLevel.Warning);

            return null;
        }

        /// <summary>
        /// Get a font from a name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal Font GetFont(string name)
        {
            if (fonts.ContainsKey(name))
                return fonts[name];

            Debug.Log("Could'nt find font with name: " + name, Debug.DebugLayer.Textures, Debug.DebugLevel.Warning);

            return null;
        }

        /// <summary>
        /// Binds the texture array to a shader
        /// </summary>
        /// <param name="uniform"></param>
        /// <param name="shader"></param>
        internal void BindTextureArrayToShader(string uniform, Shader shader)
        {
            shader.SetUniformI1(uniform, textureArray.Slot);
        }

        /// <summary>
        /// Binds the texture array as the current one
        /// </summary>
        internal void BindTextureArray()
        {
            textureArray.Bind();
        }

        /// <summary>
        /// Unbinds the texture array
        /// </summary>
        internal void UnbindTextureArray()
        {
            textureArray.Unbind();
        }

        #endregion
    }
}
