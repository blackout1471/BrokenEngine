using BrokenEngine.Components;
using BrokenEngine.Graphics;
using BrokenEngine.Maths;

namespace Tower_Defense.GUI
{
    public class Title : Entity
    {
        public Title(string text, Color color, Vec2 pos, string groupTag)
        {
            AddComponent(new Text(text, "GameFont", 22, color));

            Tag = groupTag;
            SetPosition(pos);
        }

        protected override void Start()
        {
            
        }

        protected override void Update()
        {
            
        }
    }
}
