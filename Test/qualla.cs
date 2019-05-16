using BrokenEngine.Components;
using BrokenEngine.Application;

namespace Test
{
    class qualla : Entity
    {
        public qualla()
        {
            EntityName = "Qualla";

            AddComponent(new Quad(new BrokenEngine.Maths.Vec2(20f, 20f), BrokenEngine.Graphics.Color.Red));
            AddComponent(new BoxCollision2D(new BrokenEngine.Maths.Vec2(20, 20)));

            SetPosition(new BrokenEngine.Maths.Vec2(200, 200));
        }

        protected override void Start()
        {
        }

        protected override void Update()
        {
        }
    }
}
