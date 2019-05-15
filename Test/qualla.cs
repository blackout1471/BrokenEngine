using BrokenEngine.Components;
using BrokenEngine.Application;

namespace Test
{
    class qualla : Entity
    {
        public qualla()
        {
        }

        public override void Start()
        {
            AddComponent(new Quad(new BrokenEngine.Maths.Vec2(20f, 20f), BrokenEngine.Graphics.Color.Red));

            SetPosition(new BrokenEngine.Maths.Vec2(100, 100));

        }

        public override void Update()
        {
        }
    }
}
