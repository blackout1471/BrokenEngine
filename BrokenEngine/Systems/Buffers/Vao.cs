using OpenGL;

namespace BrokenEngine.Systems.Buffers
{
    class Vao
    {
        private uint id;

        /// <summary>
        /// Initialises the vertex array object
        /// </summary>
        public Vao()
        {
            id = Gl.GenVertexArray();
        }

        /// <summary>
        /// Binds the vertex array object
        /// </summary>
        public void Bind()
        {
            Gl.BindVertexArray(id);
        }

        /// <summary>
        /// Unbinds the vertex array object
        /// </summary>
        public void Unbind()
        {
            Gl.BindVertexArray(0);
        }
    }
}
