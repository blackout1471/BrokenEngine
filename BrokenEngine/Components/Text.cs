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
            float xStartCenter = (text.Length * textSize) + (text.Length * xPadding);
            float yStartCenter = 0f;

            for (int i = 0; i < text.Length; i++)
            {
                Font.Glyph curGlyph = currentFont.GetGlyph(text[i]);

                Colors[i * 4 + 0] = color;
                Colors[i * 4 + 1] = color;
                Colors[i * 4 + 2] = color;
                Colors[i * 4 + 3] = color;

                Vertices[i * 4 + 0] = new Vec2(-textSize, -textSize);
                Vertices[i * 4 + 1] = new Vec2(textSize, -textSize);
                Vertices[i * 4 + 2] = new Vec2(textSize, textSize);
                Vertices[i * 4 + 3] = new Vec2(-textSize, textSize);

                TextureOffsets[i, 0] = new Vec2(curGlyph.xpos, curGlyph.ypos);
                TextureOffsets[i, 1] = new Vec2(curGlyph.xpos + curGlyph.xsize, curGlyph.ypos);
                TextureOffsets[i, 2] = new Vec2(curGlyph.xpos + curGlyph.xsize, curGlyph.ypos + curGlyph.ysize);
                TextureOffsets[i, 3] = new Vec2(curGlyph.xpos, curGlyph.ypos + curGlyph.ysize);
            }
        }

    }
}
