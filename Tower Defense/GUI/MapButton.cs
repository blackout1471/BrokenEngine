using BrokenEngine.Components;
using BrokenEngine.Maths;
using BrokenEngine.Graphics;

namespace Tower_Defense.GUI
{
    public class MapButton : Entity
    {
        private Vec2 size = new Vec2(100, 100);
        private int mapCount;

        public MapButton(string textureName, Vec2 pos, string groupTag, int mapCount)
        {
            this.mapCount = mapCount;

            AddComponent(new Sprite(textureName, size, Color.White));
            AddComponent(new HoverCollisionComponent(size, OnHoverEnter, OnHoverExit));
            AddComponent(new ClickComponent(ClickMethod.SingleClick, OnClick));


            Tag = groupTag;
            SetPosition(pos);
        }

        private void OnHoverEnter()
        {
            SetScale(new Vec2(1.1f, 1.1f));
        }

        private void OnHoverExit()
        {
            SetScale(new Vec2(1.0f, 1.0f));
        }

        private void OnClick()
        {
            Program.CurrentMap = mapCount;
            SceneManager.LoadScene("Editor");
        }

        protected override void Start()
        {
            
        }

        protected override void Update()
        {
            
        }
    }
}
