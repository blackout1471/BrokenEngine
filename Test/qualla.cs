using BrokenEngine.Components;
using BrokenEngine.Application;
using BrokenEngine.Graphics;
using BrokenEngine.Maths;
using BrokenEngine.Graphics;

namespace Test
{
    class qualla : Entity
    {
        public qualla()
        {
            EntityName = "Qualla";

            //AddComponent(new Quad(new BrokenEngine.Maths.Vec2(20f, 20f), BrokenEngine.Graphics.Color.Red));
            //AddComponent(new Sprite("Ducki", new BrokenEngine.Maths.Vec2(20f, 20f), BrokenEngine.Graphics.Color.White));
            //AddComponent(new Quad(new BrokenEngine.Maths.Vec2(50, 50), Color.Blue, Color.Red, Color.Green, Color.White));
            //AddComponent(new Text("Hello World", "defaultFont", 24, Color.Red));
            AddComponent(new Button(new Vec2(100, 50), Color.Green, "defaultFont", "Play", Color.Black));
            AddComponent(new BoxCollision2D(new Vec2(20, 20)));


            SetPosition(new BrokenEngine.Maths.Vec2(200, 200));
        }

        protected override void Start()
        {
        }

        protected override void Update()
        {
            //Rotate(1);
        }
    }
}
