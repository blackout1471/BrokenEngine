using BrokenEngine.Components;
using BrokenEngine.Application;
using BrokenEngine.Maths;

namespace Test
{
    class quadi : Entity
    {
        public quadi()
        {
            EntityName = "Quadi";
            AddComponent(new Sprite("Duck", new Vec2(100, 100), BrokenEngine.Graphics.Color.White));
            AddComponent(new BoxCollision2D("Qualla", new Vec2(100, 100), Collision));
            
            SetPosition(new Vec2(50, 50));
        }

        protected override void Start()
        {
           

        }

        private void Collision()
        {
            
        }

        protected override void Update()
        {
            if (Input.GetKeyDown(Input.Keys.Key_W))
                Translate(Vec2.Up);
            else if (Input.GetKeyDown(Input.Keys.Key_D))
                Translate(Vec2.Right);
            else if (Input.GetKeyDown(Input.Keys.Key_A))
                Translate(Vec2.Left);
            else if (Input.GetKeyDown(Input.Keys.Key_S))
                Translate(Vec2.Down);
        }
    }
}
