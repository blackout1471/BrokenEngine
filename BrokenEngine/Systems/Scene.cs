using BrokenEngine.Components;
using BrokenEngine.Utils;
using BrokenEngine.Systems.Renders;
using System.Collections.Generic;
using BrokenEngine.Systems.Physics;

namespace BrokenEngine.Systems
{
    public abstract class Scene
    {

        #region Scene

        public string SceneName { get => sceneName; }
        private string sceneName;

        public Scene(string sceneName)
        {
            entities = new List<Entity>();
            this.sceneName = sceneName;
        }

        /// <summary>
        /// Load the scene
        /// </summary>
        internal void Load()
        {
            entities = new List<Entity>();

            RegisterSystem(new Renderer2D());
            RegisterSystem(new Renderer2D());
            RegisterSystem(new ParticleRenderer());
            RegisterSystem(new BoxCollisionSystem());
            RegisterSystem(new HoverCollisionSystem());
            RegisterSystem(new ClickHandlerSystem());

            OnLoad();
        }

        /// <summary>
        /// The initialise state
        /// should load all necessary stuff here
        /// </summary>
        protected internal abstract void OnLoad();

        #endregion

        #region Systems
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

        #endregion

        #region Entities
        /// <summary>
        /// the list of entities
        /// </summary>
        private List<Entity> entities;

        /// <summary>
        /// Add a entity to the list
        /// </summary>
        /// <param name="entity"></param>
        internal void AddEntity(Entity entity)
        {
            entities.Add(entity);
        }

        /// <summary>
        /// Get all the entities
        /// </summary>
        /// <returns></returns>
        public Entity[] GetEntities()
        {
            return entities.ToArray();
        }

        /// <summary>
        /// Gets a entity by its name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal Entity GetEntity(string name)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].EntityName == name)
                    return entities[i];
            }

            return null;
        }

        /// <summary>
        /// Get all entities with a specific component
        /// </summary>
        /// <typeparam name="CompType"></typeparam>
        /// <returns></returns>
        internal CompType[] GetEntitiesComponent<CompType>() where CompType : BaseComponent
        {
            List<CompType> resEntities = new List<CompType>();

            for (int i = 0; i < entities.Count; i++)
            {
                CompType entityComponent = entities[i].GetComponent<CompType>();
                if (entityComponent != null)
                    resEntities.Add(entityComponent);
            }

            return resEntities.ToArray();
        }

        /// <summary>
        /// Add all Entities with multiple components
        /// </summary>
        /// <typeparam name="CompType"></typeparam>
        /// <returns></returns>
        internal CompType[] GetEntitiesComponents<CompType>() where CompType : BaseComponent
        {
            List<CompType> resEntities = new List<CompType>();

            for (int i = 0; i < entities.Count; i++)
            {
                CompType[] entityComponent = entities[i].GetComponents<CompType>();
                if (entityComponent.Length != 0)
                {
                    for (int j = 0; j < entityComponent.Length; j++)
                    {
                        resEntities.Add(entityComponent[j]);
                    }
                }
            }

            return resEntities.ToArray();
        }

        /// <summary>
        /// Get all the entities with a tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public Entity[] GetEntitiesWithTags(string tag)
        {
            if (tag == "" || tag == null)
            {
                Debug.Log("Cannot have tag with nothing or null", Debug.DebugLayer.Entity, Debug.DebugLevel.Warning);
                return null;
            }

            List<Entity> ent = new List<Entity>();

            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Tag == tag)
                    ent.Add(entities[i]);
            }

            return ent.ToArray();
        }

        /// <summary>
        /// Calls all the entities start method
        /// </summary>
        internal void StartEntities()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Start();
            }
        }

        /// <summary>
        /// Calls all the entities update method
        /// </summary>
        internal void UpdateEntities()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Update();
            }
        }

        #endregion
    }
}
