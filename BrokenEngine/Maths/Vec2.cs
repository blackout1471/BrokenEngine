namespace BrokenEngine.Maths
{
    public class Vec2
    {
        #region Properties
        public static Vec2 Up
        {
            get
            {
                return new Vec2(0, 1);
            }
        }

        public static Vec2 Down
        {
            get
            {
                return new Vec2(0, -1);
            }
        }

        public static Vec2 Left
        {
            get
            {
                return new Vec2(-1, 0);
            }
        }

        public static Vec2 Right
        {
            get
            {
                return new Vec2(1, 0);
            }
        }


        public float X
        {
            get
            {
                return x;
            }
        }

        public float Y
        {
            get
            {
                return y;
            }
        }
        #endregion

        private float x, y;

        public Vec2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Multiply a vector2 with a matrix and get the result in a vector2
        /// </summary>
        /// <param name="vec"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Vec2 operator* (Vec2 vec, Matrix4f matrix)
        {
            Vec2 res = new Vec2(
                    matrix.Matrix[0 + 0 * 4] * vec.x + matrix.Matrix[0 + 1 * 4] * vec.y + matrix.Matrix[0 + 2 * 4] * 1.0f + matrix.Matrix[0 + 3 * 4],
                    matrix.Matrix[1 + 0 * 4] * vec.x + matrix.Matrix[1 + 1 * 4] * vec.y + matrix.Matrix[1 + 2 * 4] * 1.0f + matrix.Matrix[1 + 3 * 4]
                );

            return res;
        }

        /// <summary>
        /// Add two vectors together
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static Vec2 operator+ (Vec2 vec1, Vec2 vec2)
        {
            return new Vec2(vec1.x + vec2.x, vec1.y + vec2.y);
        }

        /// <summary>
        /// Multiply 2 vectors
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static Vec2 operator* (Vec2 vec1, Vec2 vec2)
        {
            return new Vec2(vec1.x * vec2.x, vec1.y * vec2.y);
        }

        /// <summary>
        /// Divide 2 vectors
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static Vec2 operator/ (Vec2 vec1, Vec2 vec2)
        {
            return new Vec2(vec1.x / vec2.x, vec1.y / vec2.y);
        }

        /// <summary>
        /// subtract 2 vectors
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static Vec2 operator- (Vec2 vec1, Vec2 vec2)
        {
            return new Vec2(vec1.x - vec2.x, vec1.y - vec2.y);
        }

        /// <summary>
        /// Divide vectors with a int
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="divison"></param>
        /// <returns></returns>
        public static Vec2 operator/ (Vec2 vec1, int divison)
        {
            float xRes, yRes;

            if (vec1.x == 0)
                xRes = 0;
            else
                xRes = vec1.x / divison;

            if (vec1.y == 0)
                yRes = 0;
            else
                yRes = vec1.y / divison;

            return new Vec2(xRes, yRes);
        }

        /// <summary>
        /// Multiply a vector2 with a multiplier value
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        public static Vec2 operator* (Vec2 vec1, int multiplier)
        {
            return new Vec2(vec1.x * multiplier, vec1.y * multiplier);
        }

        /// <summary>
        /// Multiply with a float multiplier
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        public static Vec2 operator* (Vec2 vec1, float multiplier)
        {
            return new Vec2(vec1.x * multiplier, vec1.y * multiplier);
        }

        /// <summary>
        /// Returns the vector as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "X:" + x + "Y:" + y;
        }
    }
}
