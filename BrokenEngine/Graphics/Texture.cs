using System;
using System.Drawing;
using System.Drawing.Imaging;
using BrokenEngine.Utils;


namespace BrokenEngine.Graphics
{
    class Texture
    {
        #region Properties

        internal int Id { get { return id; } set { id = value; } }
        public int Width { get { return width; } }
        public int Height { get { return height; } }
        internal IntPtr ImageData
        {
            get
            {
                BindBits();
                IntPtr dataPt = imageData.Scan0;
                UnbindBits();
                return dataPt;
            }
        }

        #endregion

        #region Variables

        private int id;
        private int width;
        private int height;
        private Bitmap image;
        private BitmapData imageData;
        private string path;

        #endregion

        #region Methods

        public Texture(string path)
        {
            this.path = path;

            LoadImage();
        }

        /// <summary>
        /// Loads a image from the path given to Texture object
        /// </summary>
        private void LoadImage()
        {
            image = FileUtils.ReadFileAsImage(this.path);
            width = image.Width;
            height = image.Height;
            image.RotateFlip(RotateFlipType.Rotate180FlipX); // Flip image for correct settings
        }

        /// <summary>
        /// Binds the bits that is in the bitmap
        /// </summary>
        private void BindBits()
        {
            imageData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        }

        /// <summary>
        /// Unbinds the bits in the bitmap
        /// </summary>
        private void UnbindBits()
        {
            image.UnlockBits(imageData);
        }

        #endregion

    }
}
