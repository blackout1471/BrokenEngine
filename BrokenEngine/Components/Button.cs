using BrokenEngine.Graphics;
using BrokenEngine.Maths;

namespace BrokenEngine.Components
{
    public abstract class Button : Entity
    {

        protected Button(Vec2 size, Color color)
        {
            AddComponent(new Quad(size, color));
            AddComponent(new HoverCollisionComponent(size, OnHoverEnter, OnHoverExit));
        }


        protected virtual void OnHoverEnter()
        {
            return;
        }

        protected virtual void OnHoverExit()
        {
            return;
        }
    }
}
