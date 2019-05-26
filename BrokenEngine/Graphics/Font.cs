using System;
using System.Drawing;
using System.Drawing.Text;
using BrokenEngine.Utils;

namespace BrokenEngine.Graphics
{
    public class Font
    {
        #region Properties

        internal Texture Texture { get => texture; set => texture = value; }

        public int FreeYSpace
        {
            get
            {
                return freeYSpace;
            }
        }
        #endregion


        /// <summary>
        /// the struct used to store each glyphs data in the texture
        /// </summary>
        public struct Glyph
        {
            public char character;
            public int xpos, ypos;
            public int xsize, ysize;

            public Glyph(char character, int xpos, int ypos, int xsize, int ysize)
            {
                this.character = character;
                this.xpos = xpos;
                this.ypos = ypos;
                this.xsize = xsize;
                this.ysize = ysize;
            }

        }

        /// <summary>
        /// The characters to render.
        /// </summary>
        private static string[] characters = new string[]
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "x", "y", "z", "w",
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z", "W",
            "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "-"
        };

        private static PrivateFontCollection fontCollection = new PrivateFontCollection();

        private string path;
        private int id;
        int freeYSpace = 0; // how much space is left when the font texture has been drawn

        private Bitmap fontBitmap;
        private Glyph[] glyphs;
        private Texture texture;


        public Font(string path)
        {

            LoadFont(path);
            CreateBitmap();
            texture = new Texture(fontBitmap);
        }

        /// <summary>
        /// Loads the font from file
        /// </summary>
        /// <param name="path"></param>
        private void LoadFont(string path)
        {
            this.path = path;

            try
            {
                fontCollection.AddFontFile(this.path);
            }
            catch (Exception e)
            {
                throw e;
            }

            id = fontCollection.Families.Length - 1;
        }

        /// <summary>
        /// Creates the bitmap that coresponds to the font
        /// </summary>
        private void CreateBitmap()
        {
            Bitmap tmpBit = new Bitmap(Tao.LayerWidth, Tao.LayerHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            glyphs = new Glyph[characters.Length];

            using (System.Drawing.Graphics graph = System.Drawing.Graphics.FromImage(tmpBit))
            {
                using (System.Drawing.Font f = new System.Drawing.Font(fontCollection.Families[id], 90, FontStyle.Regular))
                {
                    float xoffset = 0;
                    float yoffset = 0;
                    for (int i = 0; i < characters.Length; i++)
                    {
                        SizeF size = graph.MeasureString(characters[i], f);
                        if (xoffset + size.Width >= 1024)
                        {
                            yoffset += size.Height;
                            xoffset = 0;
                        }
                        // Draw to bitmap
                        graph.DrawString(characters[i], f, Brushes.White, new Point((int)xoffset, (int)yoffset));

                        // Set glyph information
                        glyphs[i] = new Glyph(characters[i][0], (int)xoffset, (int)yoffset, (int)size.Width, (int)size.Height);

                        xoffset += size.Width;
                    }

                    freeYSpace = Tao.LayerWidth - (int)(yoffset + glyphs[glyphs.Length - 1].ysize);
                }
            }

            if (Debug.DoDebug)
                tmpBit.Save("..//..//test.png"); // Used to check the font texture - enable to debug

            fontBitmap = tmpBit;
        }

        /// <summary>
        /// Get the glyph data coresponding to the character
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public Glyph GetGlyph(char character)
        {
            for (int i = 0; i < glyphs.Length; i++)
            {
                if (glyphs[i].character == character)
                    return glyphs[i];
            }

            throw new Exception("Could not retrieve the character " + character);
        }
    }
}