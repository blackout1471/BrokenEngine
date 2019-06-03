using BrokenEngine.Graphics;
using BrokenEngine.Components;
using BrokenEngine.Maths;
using System.Collections.Generic;
using Tower_Defense.Uitls;

namespace Tower_Defense.Prefabs
{
    public enum NodeType
    {
        Path,
        Area
    }

    public class Node : Entity
    {
        #region Statics
        private static List<Node> nodes = new List<Node>();

        public static Entity[] GetPathNodes()
        {
            List<Entity> pathNodes = new List<Entity>();

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Type == NodeType.Path)
                    pathNodes.Add(nodes[i]);
            }

            return pathNodes.ToArray();
        }

        public static Entity[] GetAreaNodes()
        {
            List<Entity> areaNodes = new List<Entity>();

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Type == NodeType.Area)
                    areaNodes.Add(nodes[i]);
            }

            return areaNodes.ToArray();
        }

        public static void ClearNodes()
        {
            nodes.Clear();
        }
        #endregion

        public NodeType Type { get => type; }

        private bool followMouse;
        private string nodeTexture;
        private NodeType type;
        private readonly Vec2 size = new Vec2(15, 15);

        private ClickComponent.ClickFunction OnDeleteFunc;

        public Node(Vec2 pos, NodeType type, ClickComponent.ClickFunction OnDeleteFunc, bool followMouse = false )
        {
            this.type = type;
            this.followMouse = followMouse;
            this.OnDeleteFunc = OnDeleteFunc;

            switch (type)
            {
                case NodeType.Path:
                    nodeTexture = "PathNodeTexture";
                    break;
                case NodeType.Area:
                    nodeTexture = "AreaNodeTexture";
                    break;
            }

            AddComponent(new Sprite(nodeTexture, size, Color.White));
            AddComponent(new HoverCollisionComponent(size, OnHoverEnter, OnHoverExit));
            AddComponent(new ClickComponent(ClickMethod.SingleClick, OnLeftClick));
            AddComponent(new ClickComponent(ClickMethod.SingleClick, OnDeleteFunc, BrokenEngine.Application.Input.MouseButtons.button2));

            nodes.Add(this);
        }

        private void OnHoverEnter()
        {
            SetScale(new Vec2(1.1f, 1.1f));
        }

        private void OnHoverExit()
        {
            SetScale(new Vec2(1.0f, 1.0f));
        }

        private void OnLeftClick()
        {
            followMouse = !followMouse;
        }

        protected override void Start()
        {
            
        }

        protected override void Update()
        {
            if (followMouse)
                SetPosition(BrokenEngine.Application.Input.MousePosition);
        }
    }
}
