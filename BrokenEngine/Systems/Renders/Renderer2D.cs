using OpenGL;
using BrokenEngine.Systems.Buffers;
using BrokenEngine.Graphics;

namespace BrokenEngine.Systems.Renders
{
    class Renderer2D : BaseSystem
    {
        private Vao vao;
        private Vbo vbo;
        private Ibo ibo;
        private Shader shader;

        public Renderer2D()
        {
            vao = new Vao();
            vbo = new Vbo(BufferUsage.DynamicDraw, 100000);
            ibo = new Ibo(100000 * 6);

            // Set layouts for vbo
            vbo.PushLayout(new BufferLayout(2, VertexAttribType.Float, false)); // x, y
            vbo.PushLayout(new BufferLayout(4, VertexAttribType.Float, false)); // r, g, b, a
            vbo.PushLayout(new BufferLayout(2, VertexAttribType.Float, false)); // tx, ty
            vbo.PushLayout(new BufferLayout(1, VertexAttribType.Float, false)); // texture id

            // Set shaders and stuff

        }

        /// <summary>
        /// The start methods for the renderer
        /// </summary>
        internal override void Start()
        {
            vao.Bind();
            vbo.Bind();

            vbo.InitBuffer();

            ibo.Bind();
            ibo.SetBufferData();
            ibo.Unbind();

            vbo.Unbind();
            vao.Unbind();
        }

        private void Flush() { throw new System.NotImplementedException(); }

        internal void UpdateData() { throw new System.NotImplementedException(); }

        internal override void Draw()
        {
            throw new System.NotImplementedException();
        }

        internal override void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
