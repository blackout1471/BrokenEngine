using BrokenEngine.Utils;

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
        public float Timer { get => timer; set => timer = value; }
        public ClickFunction ClickFunc{ get => clickFunction; }
        public ClickMethod ClickingMethod { get => clickMethod; }
        #endregion

        public delegate void ClickFunction();

        private ClickFunction clickFunction;
        private ClickMethod clickMethod;
        private bool clicked;
        private float timer;

        public ClickComponent(ClickMethod method, ClickFunction function)
        {
            clickFunction = function;
            clickMethod = method;
            clicked = false;
            timer = 0;
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
