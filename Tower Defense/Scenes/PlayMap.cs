using BrokenEngine.Maths;
using BrokenEngine.Components;
using BrokenEngine.Graphics;
using Tower_Defense.Prefabs;

namespace Tower_Defense.Scenes
{
    public class PlayMap : Scene
    {
        private Map curMap;

        public PlayMap() : base("PlayMap")
        {

        }

        protected internal override void OnLoad()
        {
            
        }

        protected internal override void OnLoad(object obj)
        {
            curMap = new Map("ErrorTexture");
            curMap.Load(obj.ToString());
            curMap.SetNodesVisibility(true);

            curMap.StartRound();
        }
    }
}
