using System.Collections.Generic;
using BrokenEngine.Systems.Renders;
using BrokenEngine.Components;

namespace BrokenEngine.Systems
{
    public class SystemManager
    {
        #region Singleton pattern

        public static SystemManager Instance { get { if (instance == null) instance = new SystemManager(); return instance; } }
        private static SystemManager instance = null;
        private SystemManager() { }

        #endregion

        /// <summary>
        /// contains all the systems
        /// </summary>
        private List<BaseSystem> systems = new List<BaseSystem>();

        /// <summary>
        /// Get a system from its type
        /// </summary>
        /// <typeparam name="SysType"></typeparam>
        /// <returns></returns>
        public SysType GetSystem<SysType>() where SysType : BaseSystem
        {
            for (int i = 0; i < systems.Count; i++)
            {
                System.Type type = systems[i].GetType();

                if (type == typeof(SysType) || type.IsSubclassOf(typeof(SysType)))
                    return (SysType)systems[i];
            }

            return null;
        }

        /// <summary>
        /// Resets both the GPU Buffer and the Entities
        /// </summary>
        public void ResetGPUBuffer()
        {
            EntityManager.Instance.ResetEntities();
            GetSystem<Renderer2D>().ResetBuffer();
        }

        /// <summary>
        /// Register a system to the manager
        /// </summary>
        /// <param name="system"></param>
        public void RegisterSystem(BaseSystem system)
        {
            systems.Add(system);
        }

        /// <summary>
        /// The start loop method for all the systems
        /// </summary>
        public void Start()
        {
            for (int i = 0; i < systems.Count; i++)
            {
                systems[i].Start();
            }
        }

        /// <summary>
        /// This method updates all the systems
        /// </summary>
        public void Update()
        {
            for (int i = 0; i < systems.Count; i++)
            {
                systems[i].Update();
            }
        }

        /// <summary>
        /// this method makes all the systems draw if they have implemented it
        /// </summary>
        public void Draw()
        {
            for (int i = 0; i < systems.Count; i++)
            {
                systems[i].Draw();
            }
        }
    }
}
