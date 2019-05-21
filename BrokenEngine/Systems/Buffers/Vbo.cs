using OpenGL;
using System;
using System.Collections.Generic;

namespace BrokenEngine.Systems.Buffers
{
    /// <summary>
    /// The buffer Layout is for the VBO buffer to know how the gpu should look at all its data
    /// </summary>
    class BufferLayout
    {
        public int countData; // how many is there
        public VertexAttribType dataType; // Which datatype should the layout use
        public bool dataNormalised; // is the data normalised
        public int datasize; // The size of the datatype in bytes
        public int shaderLocation;

        public BufferLayout(int countData, VertexAttribType dataType, bool normalised, int shaderLocation=-1)
        {
            this.countData = countData;
            this.dataType = dataType;
            this.dataNormalised = normalised;
            this.shaderLocation = shaderLocation;

            //TODO: Add more
            switch (dataType)
            {
                case VertexAttribType.Float:
                    datasize = 4;
                    break;
                case VertexAttribType.Int:
                    datasize = 4;
                    break;
            }
        }
    }

    class Vbo
    {
        #region Properties

        public uint MaxEntities { get { return maxEntities; } }
        public int VertexSize { get { return vertexSize; } }

        #endregion

        #region Variables

        private uint id;
        private BufferUsage usage;
        private int vertexSize = 0;
        private uint maxEntities = 10000;

        private List<BufferLayout> bufferLayouts = new List<BufferLayout>(); // All the Bufferlayouts in the specified VBO

        #endregion

        /// <summary>
        /// Initialise the Vbo
        /// </summary>
        /// <param name="usage"></param>
        /// <param name="maxEntities"></param>
        public Vbo(BufferUsage usage, uint maxEntities)
        {
            this.usage = usage;
            id = Gl.GenBuffer();
            this.maxEntities = maxEntities;
        }

        #region Public Methods

        /// <summary>
        /// Adds a layout to the vbo buffer
        /// </summary>
        /// <param name="layout"></param>
        public void PushLayout(BufferLayout layout)
        {
            bufferLayouts.Add(layout);
        }

        /// <summary>
        /// Initialises the buffers with its current buffer layout
        /// </summary>
        public void InitBuffer()
        {
            foreach (BufferLayout lay in bufferLayouts)
                vertexSize += lay.countData * lay.datasize;

            Gl.BufferData(BufferTarget.ArrayBuffer, (uint)(maxEntities * 6 * vertexSize), null, usage);

            uint pointerData = 0;
            for (int i = 0; i < bufferLayouts.Count; i++)
            {
                int shaderlocation = i;

                if (bufferLayouts[i].shaderLocation != -1)
                    shaderlocation = bufferLayouts[i].shaderLocation;

                Gl.VertexAttribPointer((uint)shaderlocation, bufferLayouts[i].countData, bufferLayouts[i].dataType, bufferLayouts[i].dataNormalised, vertexSize, (IntPtr)pointerData);
                pointerData += (uint)(bufferLayouts[i].countData * bufferLayouts[i].datasize);
                Gl.EnableVertexAttribArray((uint)shaderlocation);
            }
        }

        /// <summary>
        /// Binds the buffer
        /// </summary>
        public void Bind()
        {
            Gl.BindBuffer(BufferTarget.ArrayBuffer, id);
        }

        /// <summary>
        /// Unbinds the buffer
        /// </summary>
        public void Unbind()
        {
            Gl.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        #endregion

    }
}
