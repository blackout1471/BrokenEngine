using System.Collections.Generic;
using BrokenEngine.Utils;

namespace BrokenEngine.Components
{
    public class EntityManager
    {

        #region Singleton

        /// <summary>
        /// The instance of the EntityManager
        /// </summary>
        public static EntityManager Instance { get
            {
                if (instance == null)
                    instance = new EntityManager();
                return instance;
            }
        }

        private static EntityManager instance = null;
        private EntityManager() { }

        #endregion


        /// <summary>
        /// the list of entities
        /// </summary>
        private List<Entity> entities = new List<Entity>();

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
                if ( entityComponent != null)
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
    }
}
