using OpenGL;
using System.Collections.Generic;
using BrokenEngine.Maths;
using BrokenEngine.Utils;

namespace BrokenEngine.Graphics
{
    class Shader
    {
        private static Dictionary<string, int> locationCache = new Dictionary<string, int>();

        private uint id;
        private bool enabled;

        public Shader(string vertexPath, string fragmentPath)
        {
            id = ShaderUtils.LoadShader(vertexPath, fragmentPath);
        }

        /// <summary>
        /// Get the uniform id from the shader
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private int GetUniform(string name)
        {
            if (locationCache.ContainsKey(name))
                return locationCache[name];

            int res = Gl.GetUniformLocation(id, name);
            if (res == -1)
                Debug.Log("Couldn't find uniform " + name, Debug.DebugLayer.Shaders, Debug.DebugLevel.Warning);
            else
                locationCache.Add(name, res);

            return res;
        }

        /// <summary>
        /// Sets a Matrix 4 x 4 uniform for the shader
        /// </summary>
        /// <param name="uniname"></param>
        /// <param name="matrix"></param>
        public void SetUniformM4(string uniname, Matrix4f matrix)
        {
            Enable();
            Gl.UniformMatrix4(GetUniform(uniname), false, matrix.Matrix);
            Disable();
        }

        /// <summary>
        /// Sets a integer value for a shader uniform
        /// </summary>
        /// <param name="uniname"></param>
        /// <param name="value"></param>
        public void SetUniformI1(string uniname, int value)
        {
            Enable();
            Gl.Uniform1(GetUniform(uniname), value);
            Disable();
        }

        /// <summary>
        /// Enable the shader
        /// </summary>
        public void Enable()
        {
            if (!enabled)
            {
                Gl.UseProgram(id);
                enabled = true;
            }
        }

        /// <summary>
        /// Disable the shader
        /// </summary>
        public void Disable()
        {
            if (enabled)
            {
                Gl.UseProgram(id);
                enabled = false;
            }
        }
    }
}
