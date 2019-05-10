using OpenGL;

namespace BrokenEngine.Systems.Buffers
{
    class Ibo
    {
        #region Variables

        private uint id;
        private int[] indicies;

        #endregion

        /// <summary>
        /// Create the ibo buffer and all the indicies
        /// </summary>
        /// <param name="count"></param>
        public Ibo(int count)
        {
            id = Gl.GenBuffer();
            indicies = new int[count];

            int offset = 0;

            for (int i = 0; i < indicies.Length; i += 6)
            {
                indicies[0 + i] = offset + 0;
                indicies[1 + i] = offset + 1;
                indicies[2 + i] = offset + 2;

                indicies[3 + i] = offset + 2;
                indicies[4 + i] = offset + 3;
                indicies[5 + i] = offset + 0;

                offset += 4;
            }
        }

        /// <summary>
        /// Sets the ibo buffer data
        /// </summary>
        public void SetBufferData()
        {
            Bind();
            Gl.BufferData(BufferTarget.ElementArrayBuffer, (uint)(sizeof(int) * indicies.Length), indicies, BufferUsage.StaticDraw);
            Unbind();
        }

        /// <summary>
        /// Binds the buffer as an element buffer
        /// </summary>
        public void Bind()
        {
            Gl.BindBuffer(BufferTarget.ElementArrayBuffer, id);
        }

        /// <summary>
        /// Unbinds the element buffer
        /// </summary>
        public void Unbind()
        {
            Gl.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }


    }
}
