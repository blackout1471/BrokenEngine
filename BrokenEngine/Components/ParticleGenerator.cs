using BrokenEngine.Graphics;
using BrokenEngine.Maths;

namespace BrokenEngine.Components
{
    public class ParticleGenerator : BatchRenderable
    {
        public int ParticleCount { get => particleCount; }

        private Vec2 size;
        private int particleCount;
        private Vec2[] offsets;

        /// <summary>
        /// Initialise the particle generator without textures
        /// </summary>
        /// <param name="size"></param>
        /// <param name="colorStart"></param>
        /// <param name="colorEnd"></param>
        /// <param name="particleCount"></param>
        /// <param name="lifeTime"></param>
        public ParticleGenerator(Vec2 size, Color colorStart, int particleCount)
        {
            // Set settings
            SetDefaultSettings(size, colorStart, particleCount);

            // Generate offsets
            offsets = new Vec2[this.particleCount];

            for (int i = 0; i < this.particleCount; i++)
            {
                offsets[i] = new Vec2(0, i);
            }
        }

        /// <summary>
        /// Sets the required settings for the particle generator
        /// </summary>
        /// <param name="size"></param>
        /// <param name="colorStart"></param>
        /// <param name="colorEnd"></param>
        /// <param name="particleCount"></param>
        /// <param name="lifeTime"></param>
        private void SetDefaultSettings(Vec2 size, Color colorStart, int particleCount)
        {
            Colors = new Color[4];
            Vertices = new Vec2[4];

            this.size = size / 2;
            this.particleCount = particleCount;

            // Set start colors
            for (int i = 0; i < Colors.Length; i++)
            {
                Colors[i] = colorStart;
            }

            Vertices[0] = new Vec2(0 - this.size.X, 0 - this.size.Y);
            Vertices[1] = new Vec2(0 + this.size.X, 0 - this.size.Y);
            Vertices[2] = new Vec2(0 + this.size.X, 0 + this.size.Y);
            Vertices[3] = new Vec2(0 - this.size.X, 0 + this.size.Y);
        }
    }
}
