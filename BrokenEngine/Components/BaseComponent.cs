namespace BrokenEngine.Components
{
    public abstract class BaseComponent
    {
        #region Properties

        /// <summary>
        /// whether the component is enabled or not
        /// </summary>
        public bool ComponentEnabled { get { return isEnabled; } set { isEnabled = value; } }

        /// <summary>
        /// The name of the component
        /// </summary>
        public string Name { get { return name; } protected set { name = value; } }

        /// <summary>
        /// The entity the component is attached to
        /// </summary>
        public Entity Entity { get { return entity; } internal set { entity = value; } }

        #endregion

        private bool isEnabled = true;
        private string name = "component";
        private Entity entity = null;

        /// <summary>
        /// Override this method if you want to check if some components is required
        /// </summary>
        protected internal virtual void RequireComponents()
        {

        }
    }
}
