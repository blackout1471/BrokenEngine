namespace BrokenEngine.Systems
{
    public abstract class BaseSystem
    {
        internal abstract void Start();
        internal abstract void Update();
        internal virtual void Draw() { return; }
    }
}
