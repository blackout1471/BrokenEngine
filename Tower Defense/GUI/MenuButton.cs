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
        private ClickFunction clickFunction;

        public delegate void ClickFunction();


        public MenuButton(Vec2 pos, Vec2 size, Color textColor, string text, Color quadColor, string groupTag, ClickFunction function)
        {
            Tag = groupTag;

            this.pos = pos;
            this.size = size;
            this.text = text;
            this.textColor = textColor;
            this.quadColor = quadColor;

            // Create Button
            AddComponent(new Button(size, quadColor, "GameFont", text, textColor));
            AddComponent(new HoverCollisionComponent(size, OnEnterHover, OnExitHover));

            this.clickFunction = function;

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
            if (!EntityEnabled)
                return;

            if (BrokenEngine.Application.Input.GetMouseButtonDown(BrokenEngine.Application.Input.MouseButtons.button1))
            {
                if (GetComponent<HoverCollisionComponent>().IsHovering)
                {
                    clickFunction();
                }
            }
        }
    }
}
