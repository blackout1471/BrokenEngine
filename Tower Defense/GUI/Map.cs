using BrokenEngine.Components;
using BrokenEngine.Systems;
using BrokenEngine.Maths;
using BrokenEngine.Graphics;

namespace Tower_Defense.GUI
{
    public class Map : Entity
    {
        public Map(string texture, string groupTag)
        {
            Tag = groupTag;

            AddComponent(new Sprite(texture, new Vec2(800, 600), Color.White));

            SetPosition(new Vec2(400, 300));
        }

        protected override void Start()
        {
            
        }

        protected override void Update()
        {
            
        }
    }
}
