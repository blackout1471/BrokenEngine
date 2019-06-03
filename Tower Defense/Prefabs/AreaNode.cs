using BrokenEngine.Components;
using BrokenEngine.Application;
using BrokenEngine.Graphics;
using BrokenEngine.Maths;

namespace Tower_Defense.Prefabs
{
    public class AreaNode : Entity
    {
        private bool followMouse;

        public AreaNode(Vec2 pos, bool followMouse = true)
        {
            AddComponent(new Sprite("AreaNodeTexture", new Vec2(15, 15), Color.White));
            AddComponent(new HoverCollisionComponent(new Vec2(15, 15), OnHoverEnter, OnHoverExit));
            AddComponent(new ClickComponent(ClickMethod.SingleClick, OnClickRight, Input.MouseButtons.button2));
            AddComponent(new ClickComponent(ClickMethod.SingleClick, OnClickLeft));

            Tag = "EditorMapUI";

            this.followMouse = followMouse;

            if (!followMouse)
            {
                SetPosition(pos);
            }
        }

        private void OnHoverEnter()
        {
            if (!followMouse)
                SetScale(new Vec2(1.1f, 1.1f));
        }

        private void OnHoverExit()
        {
            if (!followMouse)
                SetScale(new Vec2(1.0f, 1.0f));
        }

        private void OnClickLeft()
        {
            if (followMouse)
            {
                followMouse = false;
                EditorManager.Instance.AddNode(NodeType.AreaNode);
            }
            else
            {
                followMouse = true;
            }
        }

        private void OnClickRight()
        {
            if (followMouse)
            {
                EditorManager.Instance.RemoveNode(NodeType.AreaNode, this);
                UIManager.Instance.ShowEditorUI();
                EntityEnabled = false;
            }
        }

        protected override void Start()
        {

        }

        protected override void Update()
        {
            if (followMouse)
                SetPosition(Input.MousePosition);
        }
    }
}
