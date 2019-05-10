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

        private void Flush() { throw new System.NotImplementedException(); }


        internal void UpdateData() { throw new System.NotImplementedException(); }

        internal override void Draw()
        {
            throw new System.NotImplementedException();
        }

        internal override void Start()
        {
            throw new System.NotImplementedException();
        }

        internal override void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
