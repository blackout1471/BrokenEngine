namespace BrokenEngine.Components
{
    public abstract class BaseComponent
    {
        public bool IsEnabled { get; set; }
        public string Name { get; protected set; }
        public Entity Entity {get; protected set;}

        private bool isEnabled;
        private string name;
        private Entity entity;
    }
}
