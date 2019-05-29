﻿using BrokenEngine.Components;
using BrokenEngine.Maths;
using BrokenEngine.Graphics;

namespace Tower_Defense.GUI
{
    public class MapButton : Entity
    {
        private ClickComponent.ClickFunction clickfunc;

        public MapButton(string mapTextureName, Vec2 size, Vec2 pos, string groupTag, ClickComponent.ClickFunction clickFunc)
        {
            this.clickfunc = clickFunc;

            AddComponent(new Sprite(mapTextureName, size, Color.White));
            AddComponent(new HoverCollisionComponent(size, OnHoverEnter, OnHoverExit));
            AddComponent(new ClickComponent(ClickMethod.SingleClick, this.clickfunc));

            Tag = groupTag;
            SetPosition(pos);
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
