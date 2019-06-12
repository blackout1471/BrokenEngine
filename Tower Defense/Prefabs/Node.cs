using BrokenEngine.Maths;
using BrokenEngine.Components;
using BrokenEngine.Graphics;

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
        public bool FollowMouse { get => followMouse; set => followMouse = value; }

        private NodeType type;
        private int group;
        private bool followMouse;
        private ClickComponent.ClickFunction leftClickDel = null;
        private ClickComponent.ClickFunction rightClickDel = null;

        private readonly Vec2 size = new Vec2(15, 15);

        public Node(Vec2 pos, NodeType type)
        {
            string texture = "ErrorTexture";
            this.type = type;
            this.group = 0;

            // Choose texture for type
            switch(type)
            {
                case NodeType.Path:
                    texture = "PathNodeTexture";
                    break;
                case NodeType.Area:
                    texture = "AreaNodeTexture";
                    break;
            }

            // Add components
            AddComponent(new Sprite(texture, size, Color.White));
            AddComponent(new HoverCollisionComponent(size, HoverEnterEvent, HoverExitEvent));
            AddComponent(new ClickComponent(ClickMethod.SingleClick, ClickLeftEvent));
            AddComponent(new ClickComponent(ClickMethod.SingleClick, ClickRightEvent, BrokenEngine.Application.Input.MouseButtons.button2));

            SetPosition(pos);

            leftClickDel = ClickFollowEvent;
        }

        protected override void Start()
        {
            
        }

        protected override void Update()
        {
            if (followMouse)
                SetPosition(BrokenEngine.Application.Input.MousePosition);
        }

        private void HoverEnterEvent()
        {
            SetScale(new Vec2(1.1f, 1.1f));
        }

        private void HoverExitEvent()
        {
            SetScale(new Vec2(1.0f, 1.0f));
        }

        private void ClickLeftEvent(Entity sender)
        {
            leftClickDel?.Invoke(sender);
        }

        private void ClickRightEvent(Entity sender)
        {
            rightClickDel?.Invoke(sender);
        }

        private void ClickFollowEvent(Entity sender)
        {
            followMouse = !followMouse;
        }

        public void AddLeftClickEvent(ClickComponent.ClickFunction func)
        {
            leftClickDel += func;
        }

        public void AddRightClickEvent(ClickComponent.ClickFunction func)
        {
            rightClickDel += func;
        }

        public override string ToString()
        {
            return Postion.X + "," + Postion.Y + "," + Group;
        }
    }
}
