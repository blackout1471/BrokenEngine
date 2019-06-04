using BrokenEngine.Components;
using BrokenEngine.Graphics;
using BrokenEngine.Maths;

namespace Tower_Defense.GUI
{
    public class Title : Entity
    {
        public Title(string text, Color color, Vec2 pos)
        {
            AddComponent(new Text(text, "GameFont", 22, color));
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
