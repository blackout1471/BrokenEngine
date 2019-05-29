using BrokenEngine.Components;
using BrokenEngine.Maths;
using BrokenEngine.Graphics;

namespace Tower_Defense.GUI
{
    public class MenuTitle : Entity
    {
        private float timer = 0;
        private bool scaleUp = true;

        public MenuTitle(Vec2 pos, float textSize, string text, Color textColor, string groupTag)
        {
            AddComponent(new Text(text, "GameFont", textSize, textColor));

            Tag = groupTag;

            SetPosition(pos);
        }

        protected override void Start()
        {
        }

        protected override void Update()
        {
            float delta = BrokenEngine.Application.Time.DeltaTime;

            timer += delta;

            if (timer >= 2)
            {
                scaleUp = !scaleUp;
                timer = 0;
            }

            if (scaleUp)
                Scale(new Vec2(0.1f, 0.1f) * delta);
            else
                Scale(new Vec2(-0.1f, -0.1f) * delta);
        }
    }
}
