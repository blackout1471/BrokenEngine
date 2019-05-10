using OpenGL;
using System.Collections.Generic;
using BrokenEngine.Maths;

namespace BrokenEngine.Graphics
{
    class Shader
    {
        private static Dictionary<string, int> locationCache;
        private int id;
        private bool enabled;

        public Shader(string vertexPath, string fragmentPath) { }

        private int GetUniform(string name) { throw new System.NotImplementedException(); }

        public void SetUniformM4(string uniname, Matrix4f matrix) { throw new System.NotImplementedException(); }
        public void SetUniformI1(string uniname, int value) { throw new System.NotImplementedException(); }

        public void Enable() { throw new System.NotImplementedException(); }
        public void Disable() { throw new System.NotImplementedException(); }
    }
}
