using BrokenEngine.Components;
using BrokenEngine.Maths;
using BrokenEngine.Graphics;

namespace Tower_Defense.GUI
{
    class GameButton : Entity
    {

        private ClickComponent.ClickFunction clickMethod;

        public GameButton(string text, Vec2 pos, Vec2 size, ClickComponent.ClickFunction clickFunc, string groupTag)
        {

            clickMethod = clickFunc;
            Tag = groupTag;
            SetPosition(pos);

            AddComponent(new Button(size, new Color(255, 205, 185), "GameFont", text, Color.Black));
            AddComponent(new HoverCollisionComponent(size, OnHoverEnter, OnHoverExit));
            AddComponent(new ClickComponent(ClickMethod.SingleClick, clickMethod));
        }

        protected override void Start()
        {

        }

        protected override void Update()
        {

        }

        private void OnHoverEnter()
        {
            SetScale(new Vec2(1.1f, 1.1f));
        }

        private void OnHoverExit()
        {
            SetScale(new Vec2(1.0f, 1.0f));
        }
    }
}
