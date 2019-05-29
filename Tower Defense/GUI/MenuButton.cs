using BrokenEngine.Components;
using BrokenEngine.Systems;
using BrokenEngine.Maths;
using BrokenEngine.Graphics;

namespace Tower_Defense.GUI
{
    class MenuButton : Entity
    {
        private Vec2 pos;
        private Vec2 size;
        private string text;
        private Color textColor;
        private Color quadColor;
        private ClickComponent.ClickFunction clickFunction = null;


        public MenuButton(Vec2 pos, Vec2 size, Color textColor, string text, Color quadColor, string groupTag, ClickComponent.ClickFunction function)
        {
            Tag = groupTag;

            this.pos = pos;
            this.size = size;
            this.text = text;
            this.textColor = textColor;
            this.quadColor = quadColor;
            this.clickFunction = function;

            // Create Button
            AddComponent(new Button(size, quadColor, "GameFont", text, textColor));
            AddComponent(new HoverCollisionComponent(size, OnEnterHover, OnExitHover));
            AddComponent(new ClickComponent(ClickMethod.SingleClick, clickFunction));

            SetPosition(pos);
        }

        protected override void Start()
        {
        }

        private void OnEnterHover()
        {
            SetScale(new Vec2(1.1f, 1.1f));
        }

        private void OnExitHover()
        {
            SetScale(new Vec2(1.0f, 1.0f));
        }

        protected override void Update()
        {
        }
    }
}
