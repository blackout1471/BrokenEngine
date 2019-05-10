using System;

namespace BrokenEngine.Maths
{
    public class Matrix4f
    {
        #region Properties
        public float[] Matrix
        {
            get
            {
                return m4f;
            }
        }
        #endregion

        float[] m4f;

        /// <summary>
        /// Initialise the matrix
        /// </summary>
        public Matrix4f()
        {
            m4f = new float[4 * 4];

            for (int i = 0; i < m4f.Length; i++)
            {
                m4f[i] = 0.0f;
            }
        }

        /// <summary>
        /// Set matrix to some number
        /// </summary>
        /// <param name="n"></param>
        public Matrix4f(float n)
        {
            m4f = new float[4 * 4];

            for (int i = 0; i < m4f.Length; i++)
            {
                m4f[i] = n;
            }
        }

        /// <summary>
        /// Returns a identity matrix
        /// </summary>
        /// <returns></returns>
        public static Matrix4f Identity()
        {
            Matrix4f res = new Matrix4f();

            res.m4f[0 + 0 * 4] = 1.0f;
            res.m4f[1 + 1 * 4] = 1.0f;
            res.m4f[2 + 2 * 4] = 1.0f;
            res.m4f[3 + 3 * 4] = 1.0f;

            return res;
        }

        /// <summary>
        /// Returns a orthogonal projection matrix
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="top"></param>
        /// <param name="bottom"></param>
        /// <param name="far"></param>
        /// <param name="near"></param>
        /// <returns></returns>
        public static Matrix4f Orthogonal(float right, float left, float top, float bottom, float far, float near)
        {
            Matrix4f res = Identity();

            res.m4f[0 + 0 * 4] = 2.0f / (right - left);
            res.m4f[1 + 1 * 4] = 2.0f / (top - bottom);
            res.m4f[2 + 2 * 4] = -(2.0f / (far - near));

            res.m4f[0 + 3 * 4] = -((right + left) / (right - left));
            res.m4f[1 + 3 * 4] = -((top + bottom) / (top - bottom));
            res.m4f[2 + 3 * 4] = -((far + near) / (far - near));

            return res;
        }

        /// <summary>
        /// Matrix translation matrix formed from a vectoroffset
        /// </summary>
        /// <param name="VectorOffset"></param>
        /// <returns></returns>
        public static Matrix4f Translate(Vec2 VectorOffset)
        {
            Matrix4f res = Matrix4f.Identity();

            res.Matrix[0 + 3 * 4] = VectorOffset.X;
            res.Matrix[1 + 3 * 4] = VectorOffset.Y;
            res.Matrix[2 + 3 * 4] = 0f;

            return res;
        }

        /// <summary>
        /// Specify the rotation matrix for z in degrees
        /// </summary>
        /// <param name="angleDegrees"></param>
        /// <returns></returns>
        public static Matrix4f RotateZ(float angleDegrees)
        {
            Matrix4f res = Matrix4f.Identity();

            float rad = angleDegrees * ((float)Math.PI / 180);
            float cos = (float)Math.Cos(rad);
            float sin = (float)Math.Sin(rad);

            res.Matrix[0 + 0 * 4] = cos;
            res.Matrix[0 + 1 * 4] = -sin;
            res.Matrix[1 + 0 * 4] = sin;
            res.Matrix[1 + 1 * 4] = cos;

            return res;
        }

        /// <summary>
        /// Specify the scale matrix
        /// </summary>
        /// <param name="vectorScale"></param>
        /// <returns></returns>
        public static Matrix4f Scale(Vec2 vectorScale)
        {
            Matrix4f res = Matrix4f.Identity();

            res.Matrix[0 + 0 * 4] = vectorScale.X;
            res.Matrix[1 + 1 * 4] = vectorScale.Y;
            res.Matrix[2 + 2 * 4] = 1.0f;

            return res;
        }

        /// <summary>
        /// Return matrix
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Matrix4f operator* (Matrix4f first, Matrix4f second)
        {
            Matrix4f res = new Matrix4f();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        res.Matrix[j + i * 4] += first.Matrix[k + i * 4] * second.Matrix[j + k * 4];
                    }
                }
            }

            return res;
        }

        /// <summary>
        /// Add two matrix together
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Matrix4f operator+ (Matrix4f first, Matrix4f second)
        {
            Matrix4f res = new Matrix4f();

            for (int i = 0; i < 4 * 4; i++)
            {
                res.Matrix[i] = first.Matrix[i] + second.Matrix[i];
            }

            return res;
        }

        /// <summary>
        /// Get the matrix as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string res = "";

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    res += Matrix[j + i * 4] + " ";
                }
                res += "\n";
            }

            return res;
        }
        }
}
