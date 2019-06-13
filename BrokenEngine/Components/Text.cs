using BrokenEngine.Graphics;
using BrokenEngine.Maths;

namespace BrokenEngine.Components
{
    public class Text : Renderable
    {
        private float xPadding = 3;

        public Text(string text, string font, float textSize, Color color)
        {
            
            Vertices = new Vec2[4 * text.Length];
            Colors = new Color[4 * text.Length];
            TextureOffsets = new Vec2[text.Length, 4];
            Font currentFont = TextureManager.Instance.GetFont(font);

            Texture = currentFont.Texture;

            // Get start center
            float xStartCenter = -((text.Length * textSize)/2);

            for (int i = 0; i < text.Length; i++)
            {
                Font.Glyph curGlyph = currentFont.GetGlyph(text[i]);

                // Get glyph position in texture
                float xpos, ypos, xff, yff;
                if (curGlyph.xpos == 0)
                    xpos = 0;
                else
                    xpos = curGlyph.xpos / (float)Tao.LayerWidth;

                if (curGlyph.ypos == 0)
                    ypos = 1.0f;
                else
                    ypos = 1.0f - (curGlyph.ypos / (float)Tao.LayerHeight);

                xff = (float)curGlyph.xsize / (float)Tao.LayerWidth;
                yff = (float)curGlyph.ysize / ((float)Tao.LayerHeight + currentFont.FreeYSpace);

                Colors[i * 4 + 0] = color;
                Colors[i * 4 + 1] = color;
                Colors[i * 4 + 2] = color;
                Colors[i * 4 + 3] = color;

                Vertices[i * 4 + 0] = new Vec2(-textSize + (textSize * i) + xStartCenter, -textSize);
                Vertices[i * 4 + 1] = new Vec2(textSize + (textSize * i) + xStartCenter, -textSize);
                Vertices[i * 4 + 2] = new Vec2(textSize + (textSize * i) + xStartCenter, textSize);
                Vertices[i * 4 + 3] = new Vec2(-textSize + (textSize * i) + xStartCenter, textSize);

                TextureOffsets[i, 0] = new Vec2(xpos, ypos - yff);
                TextureOffsets[i, 1] = new Vec2(xpos + xff, ypos - yff);
                TextureOffsets[i, 2] = new Vec2(xpos + xff, ypos);
                TextureOffsets[i, 3] = new Vec2(xpos, ypos);
            }
        }

    }
}
