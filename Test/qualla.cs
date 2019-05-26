using BrokenEngine.Components;
using BrokenEngine.Application;
using BrokenEngine.Graphics;

namespace Test
{
    class qualla : Entity
    {
        public qualla()
        {
            EntityName = "Qualla";

            //AddComponent(new Quad(new BrokenEngine.Maths.Vec2(20f, 20f), BrokenEngine.Graphics.Color.Red));
            //AddComponent(new Quad(new BrokenEngine.Maths.Vec2(50, 50), Color.Blue, Color.Red, Color.Green, Color.White));
            AddComponent(new Text("Play", "defaultFont", 12, Color.Red));
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
