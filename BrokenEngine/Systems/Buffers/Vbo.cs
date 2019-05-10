using OpenGL;
using System.Collections.Generic;

namespace BrokenEngine.Systems.Buffers
{
    class BufferLayout
    {
        public int countData;
        public VertexAttribType dataType;
        public bool dataNormalised;
        public int datasize;

        public BufferLayout(int countData, VertexAttribType dataType, bool normalised)
        {
        }
    }

    class Vbo
    {
        #region Properties

        public uint MaxEntities { get; }
        public int VertexSize { get; }

        #endregion

        #region Variables

        private int id;
        private BufferUsage usage;
        private int vertexSize;
        private uint maxEntities;
        private List<BufferLayout> bufferLayouts;

        #endregion

        public Vbo(BufferUsage usage, uint maxEntities) { }

        #region Public Methods

        public void PushLayout(BufferLayout layout) { throw new System.NotImplementedException(); }
        public void InitBuffer() { throw new System.NotImplementedException(); }
        public void Bind() { throw new System.NotImplementedException(); }
        public void Unbind() { throw new System.NotImplementedException(); }

        #endregion

    }
}
