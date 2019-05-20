using BrokenEngine.Utils;
using BrokenEngine.Systems.Buffers;
using BrokenEngine.Graphics;
using OpenGL;
using System;

namespace BrokenEngine.Systems.Renders
{
    class ParticleRenderer : BaseSystem
    {
        private Vao vao;
        private Vbo meshVbo;
        private Vbo posVbo;

        #region TEST
        private static float[] meshData =
        {
            100, 100,
            150, 100,
            100, 150,
            150, 150
        };

        private static float[] partPos;

        #endregion

        public ParticleRenderer()
        {
            vao = new Vao();
            meshVbo = new Vbo(BufferUsage.DynamicDraw, 100);
            posVbo = new Vbo(BufferUsage.DynamicDraw, 100000);

            meshVbo.PushLayout(new BufferLayout(2, VertexAttribType.Float, false, 0));

            posVbo.PushLayout(new BufferLayout(3, VertexAttribType.Float, false, 1));
        }

        internal override void Start()
        {
            partPos = new float[99];
            // TEST Generate data
            for (int i = 0; i < 99; i+=3)
            {
                partPos[i + 0] = 0;
                partPos[i + 1] = 0;
                partPos[i + 2] = 0;
            }

            vao.Bind();
            meshVbo.Bind();
            meshVbo.InitBuffer();
            Gl.VertexAttribDivisor(0, 0);
            Gl.BufferSubData(BufferTarget.ArrayBuffer, IntPtr.Zero, (uint)(meshData.Length * sizeof(float)), meshData);
            
            meshVbo.Unbind();
            vao.Unbind();
        }

        internal override void Update()
        {
            
        }

        internal override void Draw()
        {
            Shader.batchShader.Enable();

            vao.Bind();
            Gl.DrawArraysInstanced(PrimitiveType.TriangleStrip, 0, 4, 99);
            vao.Unbind();

            Shader.batchShader.Disable();
        }
    }
}
