using BrokenEngine.Components;
using BrokenEngine.Graphics;
using BrokenEngine.Maths;
using BrokenEngine.Utils;

namespace Test
{
    public class But : Button
    {
        public But() : base(new Vec2(200, 200), Color.Green)
        {
            SetPosition(new Vec2(500, 200));
        }

        protected override void Start()
        {

        }

        protected override void Update()
        {
        }

        protected override void OnHoverEnter()
        {
            SetScale(new Vec2(1.2f, 1.0f));
            Debug.Log("Hover Enter");
        }

        protected override void OnHoverExit()
        {
            SetScale(new Vec2(1f, 1f));
            Debug.Log("Hover Exit");
        }
    }
}
