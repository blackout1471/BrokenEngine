using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace BrokenEngine.Graphics
{
    class Texture
    {
        #region Properties

        internal int Id { get; set; }
        public int Width { get; }
        public int Height { get; }
        internal IntPtr ImageData { get; }

        #endregion

        #region Variables

        private int id;
        private int width;
        private int height;
        private Bitmap image;
        private BitmapData imageData;

        #endregion

        #region Methods

        public Texture(string path) { }

        private void LoadImage() { throw new System.NotImplementedException(); }
        private void BindBits() { throw new System.NotImplementedException(); }
        private void UnbindBits() { throw new System.NotImplementedException(); }

        #endregion

    }
}
