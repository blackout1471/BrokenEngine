using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokenEngine.Graphics
{
    public class Color
    {
        #region Properties
        public float R { get { return r; } }
        public float G { get { return g; } }
        public float B { get { return b; } }
        public float A { get { return a; } }

        public float CR { get { return ConvertFromFloat(r); } }
        public float CG { get { return ConvertFromFloat(g); } }
        public float CB { get { return ConvertFromFloat(b); } }
        public float CA { get { return ConvertFromFloat(a); } }

        public static Color Black { get { return new Color(0, 0, 0); } }
        public static Color White { get { return new Color(255, 255, 255); } }
        public static Color Red { get { return new Color(255, 0, 0); } }
        public static Color Green { get { return new Color(0, 255, 0); } }
        public static Color Blue { get { return new Color(0, 0, 255); } }
        public static Color None { get { return new Color(0, 0, 0, 0); } }

        #endregion

        private float r, g, b, a;

        /// <summary>
        /// Initialise colors
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public Color(float r, float g, float b, float a)
        {
            this.r = ConvertToFloat(r);
            this.g = ConvertToFloat(g);
            this.b = ConvertToFloat(b);
            this.a = ConvertToFloat(a);
        }

        /// <summary>
        /// Initialise colors but set alpha to 1.0f
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        public Color(float r, float g, float b)
        {
            this.r = ConvertToFloat(r);
            this.g = ConvertToFloat(g);
            this.b = ConvertToFloat(b);
            this.a = 1.0f;
        }

        /// <summary>
        /// Convert a color float to a normalised float value
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private float ConvertToFloat(float color)
        {
            return color / 255;
        }

        /// <summary>
        /// Convert a normalised color value to a color value
        /// </summary>
        /// <param name="fColor"></param>
        /// <returns></returns>
        private float ConvertFromFloat(float fColor)
        {
            return fColor * 255;
        }

        /// <summary>
        /// Returns the color in a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "R:" + CR + "G:" + CG + "B:" + CB + "A:" + CA;
        }
    }
}
