using BrokenEngine.Components;

namespace Test
{
    class quadi : Entity
    {
        public quadi()
        {
        }

        public override void Start()
        {
            AddComponent(new Quad(new BrokenEngine.Maths.Vec2(0.4f, 0.4f), BrokenEngine.Graphics.Color.Red));

        }

        public override void Update()
        {
            
        }
    }
}
