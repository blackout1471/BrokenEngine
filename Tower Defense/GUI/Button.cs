using BrokenEngine.Components;
using BrokenEngine.Graphics;
using BrokenEngine.Maths;

namespace Tower_Defense.GUI
{
    public class Button : Entity
    {
        private HoverCollisionComponent.CollisionFunc OnHoverEnterDel   = null;
        private HoverCollisionComponent.CollisionFunc OnHoverExitDel    = null;
        private ClickComponent.ClickFunction OnLeftClickDel             = null;

        /// <summary>
        /// Adds a button with a quad and a text
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="size"></param>
        /// <param name="quadColor"></param>
        /// <param name="text"></param>
        /// <param name="textColor"></param>
        public Button(Vec2 pos, Vec2 size, Color quadColor, string text, Color textColor)
        {
            // Set position
            SetPosition(pos);

            // Add the required components
            AddComponent(new BrokenEngine.Components.Button(size, quadColor, "GameFont", text, textColor));
            AddComponent(new HoverCollisionComponent(size, OnHoverEnter, OnHoverExit));
            AddComponent(new ClickComponent(ClickMethod.SingleClick, OnLeftClick));
        }

        /// <summary>
        /// Adds a button with a sprite component
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="size"></param>
        /// <param name="textureName"></param>
        public Button(Vec2 pos, Vec2 size, string textureName)
        {
            // Set position
            SetPosition(pos);

            // Add the required components
            AddComponent(new Sprite(textureName, size, Color.White));
            AddComponent(new HoverCollisionComponent(size, OnHoverEnter, OnHoverExit));
            AddComponent(new ClickComponent(ClickMethod.SingleClick, OnLeftClick));
        }


        /// <summary>
        /// Adds a click event to the button
        /// </summary>
        /// <param name="clickEvent"></param>
        public void AddClickEvent(ClickComponent.ClickFunction clickEvent)
        {
            OnLeftClickDel += clickEvent;
        }

        /// <summary>
        /// Adds a hover event for the button
        /// </summary>
        /// <param name="EnterFunc"></param>
        /// <param name="ExitFunc"></param>
        public void AddHoverEvent(HoverCollisionComponent.CollisionFunc EnterFunc, HoverCollisionComponent.CollisionFunc ExitFunc)
        {
            OnHoverEnterDel += EnterFunc;
            OnHoverExitDel  += ExitFunc;
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
            OnLeftClickDel?.Invoke(sender);
        }

        protected override void Start()
        {
            
        }

        protected override void Update()
        {
            
        }
    }
}
