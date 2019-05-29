using BrokenEngine.Components;
using BrokenEngine.Maths;
using BrokenEngine.Utils;
using System;

namespace BrokenEngine.Systems.Physics
{
    class BoxCollisionSystem : BaseSystem
    {
        private BoxCollision2D[] collisionsComponents;

        internal override void Start()
        {
            
        }

        internal override void Update()
        {
            // Get all components
            collisionsComponents = EntityManager.Instance.GetEntitiesComponent<BoxCollision2D>();

            if (collisionsComponents.Length == 0)
                return;

            for (int i = 0; i < collisionsComponents.Length; i++)
            {
                BoxCollision2D curComp = collisionsComponents[i];

                if (!curComp.ComponentEnabled)
                    continue;

                if (curComp.CollisionFunction == null)
                    continue;

                BoxCollision2D otherComp;

                otherComp = EntityManager.Instance.GetEntity(curComp.OtherEntityName).GetComponent<BoxCollision2D>();
                if (otherComp == null)
                {
                    Debug.Log(curComp.Entity.EntityName + " others entity missing boxcollision component", Debug.DebugLayer.Physics, Debug.DebugLevel.Error);
                    continue;
                }

                // The bounding box for each entity
                Vec2[] entityMasterBounding = new Vec2[4];
                Vec2[] entitySlaveBounding = new Vec2[4];

                Matrix4f curEntityModelView = curComp.Entity.ModelView;

                // Current entitys bounding box
                entityMasterBounding[0] = new Vec2(-curComp.Size.X, -curComp.Size.Y) * curEntityModelView;
                entityMasterBounding[1] = new Vec2(curComp.Size.X, -curComp.Size.Y) * curEntityModelView;
                entityMasterBounding[2] = new Vec2(curComp.Size.X, curComp.Size.Y) * curEntityModelView;
                entityMasterBounding[3] = new Vec2(-curComp.Size.X, curComp.Size.Y) * curEntityModelView;

                
                Matrix4f otherEntityModelView = otherComp.Entity.ModelView;

                // The other entities bounding box
                entitySlaveBounding[0] = new Vec2(-otherComp.Size.X, -otherComp.Size.Y) * otherEntityModelView;
                entitySlaveBounding[1] = new Vec2(otherComp.Size.X, -otherComp.Size.Y) * otherEntityModelView;
                entitySlaveBounding[2] = new Vec2(otherComp.Size.X, otherComp.Size.Y) * otherEntityModelView;
                entitySlaveBounding[3] = new Vec2(-otherComp.Size.X, otherComp.Size.Y) * otherEntityModelView;

                // Check collision partly
                if (entityMasterBounding[0].X < entitySlaveBounding[1].X)
                    if (entityMasterBounding[1].X > entitySlaveBounding[0].X)
                        if (entityMasterBounding[0].Y < entitySlaveBounding[2].Y)
                            if (entityMasterBounding[2].Y > entitySlaveBounding[0].Y)
                                curComp.CollisionFunction();
                            else
                                continue;
                        else
                            continue;
                    else
                        continue;

            }
        }

    }
}
