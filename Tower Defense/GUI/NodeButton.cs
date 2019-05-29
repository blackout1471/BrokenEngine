using BrokenEngine.Components;
using BrokenEngine.Systems;
using BrokenEngine.Maths;
using BrokenEngine.Graphics;

namespace Tower_Defense.GUI
{
    public class NodeButton : Entity
    {
        private Color hoverEnterColor = Color.White;
        private Color hoverExitColor = new Color(255, 255, 255, 50);
        private NodeType type;

        public NodeButton(string mapTextureName, Vec2 size, Vec2 pos, string groupTag, NodeType type)
        {

            AddComponent(new Sprite(mapTextureName, size, hoverExitColor));
            AddComponent(new HoverCollisionComponent(size, OnHoverEnter, OnHoverExit));
            AddComponent(new ClickComponent(ClickMethod.SingleClick, OnClick));

            this.type = type;
            Tag = groupTag;
            SetPosition(pos);
        }

        private void OnHoverEnter()
        {
            GetComponent<Sprite>().ChangeColor(hoverEnterColor);
        }

        private void OnHoverExit()
        {
            GetComponent<Sprite>().ChangeColor(hoverExitColor);
        }

        private void OnClick()
        {
            UIManager.Instance.HideAll();
            UIManager.Instance.ShowEditorMapUI();

            EditorManager.Instance.AddNode(type);
        }

        protected override void Start()
        {
            
        }

        protected override void Update()
        {
            
        }
    }
}
