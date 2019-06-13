using BrokenEngine.Utils;
using BrokenEngine.Systems.Buffers;
using BrokenEngine.Graphics;
using BrokenEngine.Components;
using OpenGL;
using System;

namespace BrokenEngine.Systems.Renders
{
    class ParticleRenderer : BaseSystem
    {
        private Vao vao;
        private Vbo meshVbo;
        private Vbo posVbo;
        private Vbo colVbo;
        private ParticleComponent[] particleComponents;
        private uint lastEntityOffset;

        public ParticleRenderer()
        {
            
        }

        internal override void Start()
        {

        }

        internal override void Update()
        {

        }

        internal override void Draw()
        {
        }
    }
}
