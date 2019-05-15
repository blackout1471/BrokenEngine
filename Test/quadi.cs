﻿using BrokenEngine.Components;
using BrokenEngine.Application;

namespace Test
{
    class quadi : Entity
    {
        public quadi()
        {
        }

        public override void Start()
        {
            AddComponent(new Quad(new BrokenEngine.Maths.Vec2(20f, 20f), BrokenEngine.Graphics.Color.Red));

            SetPosition(new BrokenEngine.Maths.Vec2(50, 50));

        }

        public override void Update()
        {
        }
    }
}
