using OpenGL;
using System.Collections.Generic;
using BrokenEngine.Maths;
using BrokenEngine.Utils;

namespace BrokenEngine.Graphics
{
    class Shader
    {
        #region DefaultShaders

        #region Properties
        /// <summary>
        /// Get the basicshader
        /// </summary>
        public static Shader BasicShader { get { return basicShader; } }

        #endregion

        #region Source
        private static string[] basicVertexShaderSource = {"#version 330\n",
                "layout(location = 0) in vec2 pos;\n",
                "layout(location = 1) in vec4 colors;\n",
                "layout(location = 2) in vec2 texturepos;\n",
                "layout(location = 3) in float textureId;\n",

                "uniform mat4 pr_matrix;\n",
                "uniform mat4 modelView = mat4(1.0);\n",

                "out vec4 outColors;\n",
                "out vec2 outTexturePos;\n",
                "out float outTextureId;\n",

                "void main()\n",
                "{\n",
                    "gl_Position = pr_matrix * modelView * vec4(pos.xy, 0.0, 1.0);\n",
                    "//gl_Position = vec4(pos.xy, 1.0, 1.0);\n",

                    "outColors = colors;\n",
                    "outTexturePos = texturepos;\n",
                    "outTextureId = textureId;\n",
                "}\n" };

        private static string[] basicFragmentShaderSource = { "#version 330\n",
                "in vec4 outColors;\n",
                "in vec2 outTexturePos;\n",
                "in float outTextureId;\n",

                "uniform sampler2DArray textureArray;\n",

                "void main()\n",
                "{\n",
                    " vec4 finalColor = outColors;\n",

                    "if (outTextureId != 1024)\n",
                    "{\n",
                        "finalColor *= texture(textureArray, vec3(outTexturePos.xy, outTextureId));\n",
                    "}\n",

                    "gl_FragColor = finalColor;\n",
                "}\n" };

        #endregion

        private static Shader basicShader;

        /// <summary>
        /// Load the default shaders
        /// </summary>
        public static void LoadDefaultShaders()
        {
            basicShader = new Shader(basicVertexShaderSource, basicFragmentShaderSource);
        }

        #endregion


        private static Dictionary<string, int> locationCache = new Dictionary<string, int>();

        private uint id;
        private bool enabled;

        public Shader(string vertexPath, string fragmentPath)
        {
            id = ShaderUtils.LoadShader(vertexPath, fragmentPath);
        }

        public Shader(string[] vertexSource, string[] fragmentSource)
        {
            id = ShaderUtils.LoadShader(vertexSource, fragmentSource);
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
        /// Sets a float Matrix 4 x 4 uniform for the shader
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
