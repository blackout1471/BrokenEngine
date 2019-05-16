using BrokenEngine.Graphics;
using BrokenEngine.Components;
using BrokenEngine.Maths;

namespace Test
{
    public class Particle : Entity
    {
        public Particle()
        {
            AddComponent(new ParticleGenerator(new Vec2(20, 20), Color.Green, 1000));

            SetPosition(new Vec2(300, 300));
        }

        protected override void Start()
        {
            
        }

        protected override void Update()
        {
            
        }
    }
}
