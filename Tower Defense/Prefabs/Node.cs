using System;
using BrokenEngine.Components;
using BrokenEngine.Application;
using BrokenEngine.Graphics;
using BrokenEngine.Maths;
using Tower_Defense.GUI;

namespace Tower_Defense.Prefabs
{
    public enum NodeType
    {
        Path,
        Area
    }

    public class Node : Entity
    {
        public NodeType Type { get => type; }
        public int Group { get => group; set => group = value; }

        private HoverCollisionComponent.CollisionFunc OnHoverEnterDel   = null;
        private HoverCollisionComponent.CollisionFunc OnHoverExitDel    = null;
        private ClickComponent.ClickFunction OnLeftClickDel             = null;
        private ClickComponent.ClickFunction OnRightClickDel            = null;

        private NodeType type;
        private int group;
        private bool follow;

        public Node(Vec2 pos, Vec2 size, NodeType type, bool follow = true)
        {
            this.type   = type;
            this.follow = follow;

            // Set position
            SetPosition(pos);

            // Add the required components
            AddComponent(new Sprite(GetTexture(), size, Color.White));
            AddComponent(new HoverCollisionComponent(size, OnHoverEnter, OnHoverExit));
            AddComponent(new ClickComponent(ClickMethod.SingleClick, OnLeftClick));
            AddComponent(new ClickComponent(ClickMethod.SingleClick, OnRightClick, Input.MouseButtons.button2));
        }

        /// <summary>
        /// Adds a click event to the button
        /// </summary>
        /// <param name="clickEvent"></param>
        public void AddLeftClickEvent(ClickComponent.ClickFunction clickEvent)
        {
            OnLeftClickDel += clickEvent;
        }

        /// <summary>
        /// Adds a click event to the button
        /// </summary>
        /// <param name="clickEvent"></param>
        public void AddRightClickEvent(ClickComponent.ClickFunction clickEvent)
        {
            OnRightClickDel += clickEvent;
        }

        /// <summary>
        /// Adds a hover event for the button
        /// </summary>
        /// <param name="EnterFunc"></param>
        /// <param name="ExitFunc"></param>
        public void AddHoverEvent(HoverCollisionComponent.CollisionFunc EnterFunc, HoverCollisionComponent.CollisionFunc ExitFunc)
        {
            OnHoverEnterDel += EnterFunc;
            OnHoverExitDel += ExitFunc;
        }

        /// <summary>
        /// The hover event
        /// </summary>
        private void OnHoverEnter()
        {
            SetScale(new Vec2(1.1f, 1.1f));
            OnHoverEnterDel?.Invoke();
        }

        /// <summary>
        /// The hover exit
        /// </summary>
        private void OnHoverExit()
        {
            SetScale(new Vec2(1.0f, 1.0f));
            OnHoverExitDel?.Invoke();
        }

        /// <summary>
        /// The left click event
        /// </summary>
        private void OnLeftClick(Entity sender)
        {
            follow = !follow;
            OnLeftClickDel?.Invoke(sender);
        }

        /// <summary>
        /// The right click event
        /// </summary>
        private void OnRightClick(Entity sender)
        {
            OnRightClickDel?.Invoke(sender);
        }

        protected override void Start()
        {

        }

        protected override void Update()
        {
            if (follow)
                SetPosition(Input.MousePosition);
        }

        /// <summary>
        /// Returns the correct texture
        /// </summary>
        /// <returns></returns>
        private string GetTexture()
        {
            string textureName = "";

            switch(type)
            {
                case NodeType.Path:
                    textureName = "PathNodeTexture";
                    break;
                case NodeType.Area:
                    textureName = "AreaNodeTexture";
                    break;
            }

            return textureName;
        }
    }
}
