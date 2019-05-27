using BrokenEngine.Maths;
using BrokenEngine.Graphics;

namespace BrokenEngine.Components
{
    public class Button : Renderable
    {
        public Button(Vec2 size, Color quadColor, string font, string text, Color textColor)
        {
            int totalVertices = 4 + (text.Length * 4);
            size = size / 2;

            Vertices = new Vec2[totalVertices];
            Colors = new Color[totalVertices];
            TextureOffsets = new Vec2[text.Length + 4, 4];
            Font currentFont = TextureManager.Instance.GetFont(font);
            Texture = currentFont.Texture;

            // Make Quad
            Vertices[0] = new Vec2(-size.X, -size.Y);
            Vertices[1] = new Vec2(size.X, -size.Y);
            Vertices[2] = new Vec2(size.X, size.Y);
            Vertices[3] = new Vec2(-size.X, size.Y);

            Colors[0] = quadColor;
            Colors[1] = quadColor;
            Colors[2] = quadColor;
            Colors[3] = quadColor;

            TextureOffsets[0, 0] = new Vec2(-1, -1);
            TextureOffsets[0, 1] = new Vec2(-1, -1);
            TextureOffsets[0, 2] = new Vec2(-1, -1);
            TextureOffsets[0, 3] = new Vec2(-1, -1);

            // Generate text
            // Get start center
            float xStartCenter = -size.X;
            float textSize = (size.X * 2) / (text.Length + 1);

            for (int i = 1; i < text.Length + 1; i++)
            {
                Font.Glyph curGlyph = currentFont.GetGlyph(text[i-1]);

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

                Colors[i * 4 + 0] = textColor;
                Colors[i * 4 + 1] = textColor;
                Colors[i * 4 + 2] = textColor;
                Colors[i * 4 + 3] = textColor;

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
