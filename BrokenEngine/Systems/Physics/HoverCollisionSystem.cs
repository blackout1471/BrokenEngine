using BrokenEngine.Components;
using BrokenEngine.Maths;
using BrokenEngine.Utils;

namespace BrokenEngine.Systems.Physics
{
    class HoverCollisionSystem : BaseSystem
    {
        private HoverCollisionComponent[] collisionsComponents;

        internal override void Start()
        {
        }

        internal override void Update()
        {
            Vec2 mousePos = Application.Input.MousePosition;

            // Get all components
            collisionsComponents = EntityManager.Instance.GetEntitiesComponents<HoverCollisionComponent>();

            if (collisionsComponents.Length == 0)
                return;

            for (int i = 0; i < collisionsComponents.Length; i++)
            {
                HoverCollisionComponent curComp = collisionsComponents[i];

                if (!curComp.Entity.EntityEnabled)
                    continue;

                if (!curComp.ComponentEnabled)
                    continue;

                if (curComp.CollisionFunctionEnter == null)
                    continue;

                if (curComp.CollisionFunctionExit == null)
                    continue;

                // The bounding box for each entity
                Vec2[] entityMasterBounding = new Vec2[4];

                Matrix4f curEntityModelView = curComp.Entity.ModelView;

                // Current entitys bounding box
                entityMasterBounding[0] = new Vec2(-curComp.Size.X, -curComp.Size.Y) * curEntityModelView;
                entityMasterBounding[1] = new Vec2(curComp.Size.X, -curComp.Size.Y) * curEntityModelView;
                entityMasterBounding[2] = new Vec2(curComp.Size.X, curComp.Size.Y) * curEntityModelView;
                entityMasterBounding[3] = new Vec2(-curComp.Size.X, curComp.Size.Y) * curEntityModelView;

                // Check if mouse point is inside
                if (mousePos.X > entityMasterBounding[0].X)
                {
                    if (mousePos.X < entityMasterBounding[1].X)
                    {
                        if (mousePos.Y > entityMasterBounding[0].Y)
                        {
                            if (mousePos.Y < entityMasterBounding[2].Y)
                            {
                                if (!curComp.IsHovering)
                                {
                                    curComp.CollisionFunctionEnter();
                                    curComp.IsHovering = true;
                                }
                                continue;
                            }
                        }
                    }
                }

                // Mouse has exited the entity
                if (curComp.IsHovering)
                {
                    curComp.CollisionFunctionExit();
                    curComp.IsHovering = false;
                }
            }
        }
    }
}
