using OpenGL;
using System.Text;

namespace BrokenEngine.Utils
{
    public static class ShaderUtils
    {
        /// <summary>
        /// Loads a shader from file and returns the programs id
        /// </summary>
        /// <param name="vertexPath"></param>
        /// <param name="fragmentPath"></param>
        /// <returns></returns>
        public static uint LoadShader(string vertexPath, string fragmentPath)
        {
            string[] vertexSource = FileUtils.ReadFileAsString(vertexPath);
            string[] fragmentSource = FileUtils.ReadFileAsString(fragmentPath);

            return CreateShader(vertexSource, fragmentSource);
        }

        /// <summary>
        /// Creates a shader from a string array and returns the shader program id
        /// </summary>
        /// <param name="vertexSource"></param>
        /// <param name="fragmentSource"></param>
        /// <returns></returns>
        public static uint LoadShader(string[] vertexSource, string[] fragmentSource)
        {
            return CreateShader(vertexSource, fragmentSource);
        }

        /// <summary>
        /// Creates the shader and returns the handle to it
        /// </summary>
        /// <param name="vertexSource"></param>
        /// <param name="fragmentSource"></param>
        /// <returns></returns>
        private static uint CreateShader(string[] vertexSource, string[] fragmentSource)
        {
            StringBuilder infolog = new StringBuilder(1024);
            int infoLogLength;

            // Create a shader id
            uint programid = Gl.CreateProgram();
            uint vertexId = Gl.CreateShader(ShaderType.VertexShader);
            uint fragmentId = Gl.CreateShader(ShaderType.FragmentShader);

            // Create shader from source
            Gl.ShaderSource(vertexId, vertexSource);
            Gl.ShaderSource(fragmentId, fragmentSource);

            int compileStatus = 0;

            // Compile the shaders
            Gl.CompileShader(vertexId);
            Gl.GetShader(vertexId, ShaderParameterName.CompileStatus, out compileStatus);

            if (compileStatus == 0)
            {
                Gl.GetShaderInfoLog(vertexId, 1024, out infoLogLength, infolog);
            }

            Gl.CompileShader(fragmentId);
            Gl.GetShader(fragmentId, ShaderParameterName.CompileStatus, out compileStatus);

            if (compileStatus == 0)
            {
                Gl.GetShaderInfoLog(fragmentId, 1024, out infoLogLength, infolog);
            }

            if (infolog.Length > 0)
                Debug.Log("Could not compile shaders " + infolog, Debug.DebugLayer.Shaders, Debug.DebugLevel.Warning);
                
            // Attach the shaders to the shader program
            Gl.AttachShader(programid, vertexId);
            Gl.AttachShader(programid, fragmentId);

            // Link the shaders
            Gl.LinkProgram(programid);

            // Validate the shader program
            Gl.ValidateProgram(programid);

            Debug.Log("Shaders Compiled: Id " + vertexId + ":" + fragmentId, Debug.DebugLayer.Shaders, Debug.DebugLevel.Information);

            return programid;
        }
    }
}
