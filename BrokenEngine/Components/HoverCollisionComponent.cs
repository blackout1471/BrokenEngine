using BrokenEngine.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokenEngine.Components
{
    public class HoverCollisionComponent : BaseComponent
    {
        #region Properties
        internal CollisionFunc CollisionFunctionEnter { get => collisionFuncEnter; }
        internal CollisionFunc CollisionFunctionExit { get => collisionFuncExit; }
        internal Vec2 Size { get => size; }
        public bool IsHovering { get => isHovering; internal set => isHovering = value; }
        #endregion

        /// <summary>
        /// The delegate for when colliding with object
        /// </summary>
        public delegate void CollisionFunc();

        private CollisionFunc collisionFuncEnter = null;
        private CollisionFunc collisionFuncExit = null;
        private Vec2 size = null;
        private bool isHovering = false;

        public HoverCollisionComponent(Vec2 size, CollisionFunc functionEnter, CollisionFunc functionExit)
        {
            this.size = size / 2;

            collisionFuncEnter = functionEnter;
            collisionFuncExit = functionExit;
        }
    }
}
