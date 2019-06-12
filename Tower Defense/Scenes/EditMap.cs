using BrokenEngine.Maths;
using BrokenEngine.Components;
using BrokenEngine.Graphics;
using Tower_Defense.Prefabs;
using BrokenEngine.Utils;
using System;

namespace Tower_Defense.Scenes
{
    public class EditMap : Scene
    {
        private Map curMap;

        public EditMap() : base("EditMap")
        {

        }

        protected internal override void OnLoad()
        {
            throw new NotImplementedException();
        }

        protected internal override void OnLoad(object obj)
        {
            curMap = new Map("ErrorTexture");

            curMap.Load(obj.ToString());
        }
    }
}
