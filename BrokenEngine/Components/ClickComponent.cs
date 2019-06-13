using BrokenEngine.Utils;
using BrokenEngine.Application;

namespace BrokenEngine.Components
{
    public enum ClickMethod {
        SingleClick,
        DoubleClick,
        TripleClick
    }

    public class ClickComponent : BaseComponent
    {
        #region properties
        public bool IsClicked { get => clicked; set => clicked = value; }
        internal float Timer { get => timer; set => timer = value; }
        public ClickFunction ClickFunc{ get => clickFunction; }
        public ClickMethod ClickingMethod { get => clickMethod; }
        public Input.MouseButtons MouseButton { get => mouseButton; } 
        #endregion

        public delegate void ClickFunction(Entity sender);

        private ClickFunction clickFunction;
        private ClickMethod clickMethod;
        private bool clicked;
        private float timer;
        private Input.MouseButtons mouseButton;

        public ClickComponent(ClickMethod method, ClickFunction function, Input.MouseButtons mouseButton = Input.MouseButtons.button1)
        {
            clickFunction = function;
            clickMethod = method;
            clicked = false;
            timer = 0;
            this.mouseButton = mouseButton;
        }

        protected internal override void RequireComponents()
        {
            if (Entity.GetComponent<HoverCollisionComponent>() == null)
            {
                Debug.Log("ClickComponent need HoverCollisionComponent", Debug.DebugLayer.Entity, Debug.DebugLevel.Warning);
                ComponentEnabled = false;
            }
        }


    }
}
