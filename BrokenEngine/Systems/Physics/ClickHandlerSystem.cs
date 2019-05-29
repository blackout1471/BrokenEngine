using BrokenEngine.Components;
using BrokenEngine.Maths;
using BrokenEngine.Utils;

namespace BrokenEngine.Systems.Physics
{
    public class ClickHandlerSystem : BaseSystem
    {
        private ClickComponent[] clickComponents;
        private static float multiClickTime = 0.1f;

        internal override void Start()
        {
            
        }

        internal override void Update()
        {
            clickComponents = EntityManager.Instance.GetEntitiesComponents<ClickComponent>();
            if (clickComponents.Length == 0)
                return;

            for (int i = 0; i < clickComponents.Length; i++)
            {
                if (!clickComponents[i].Entity.EntityEnabled)
                    continue;

                if (!clickComponents[i].ComponentEnabled)
                    continue;

                ClickComponent curComp = clickComponents[i];

                // Check if the entity has been clicked
                if (!curComp.IsClicked)
                {
                    if (curComp.Entity.GetComponent<HoverCollisionComponent>().IsHovering)
                    {
                        if (Application.Input.GetMouseButton(curComp.MouseButton) == Application.Input.InputAction.Pressed)
                        {
                            curComp.IsClicked = true;
                            Debug.Log(curComp.Entity.EntityName + " has been clicked with " + curComp.MouseButton, Debug.DebugLayer.Entity, Debug.DebugLevel.Information);
                        }
                    }
                }
                else
                {
                    curComp.Timer += Application.Time.DeltaTime;

                    if (curComp.ClickingMethod == ClickMethod.SingleClick)
                    {
                        if (curComp.Timer <= multiClickTime)
                        {
                            if (Application.Input.GetMouseButton(Application.Input.MouseButtons.button1) == Application.Input.InputAction.Released)
                            {
                                if (curComp.ClickFunc == null)
                                {
                                    Debug.Log("ClickHandlers method was null", Debug.DebugLayer.Entity, Debug.DebugLevel.Error);
                                    curComp.IsClicked = false;
                                    curComp.Timer = 0;
                                    continue;
                                }

                                curComp.ClickFunc();
                                curComp.IsClicked = false;
                                curComp.Timer = 0;
                            }
                        }
                        else
                        {
                            curComp.IsClicked = false;
                            curComp.Timer = 0;
                        }
                    }
                }
            }
        }
    }
}
