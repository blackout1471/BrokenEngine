﻿using System.Collections.Generic;

namespace BrokenEngine.Components
{
    public class EntityManager
    {
        #region Singleton

        /// <summary>
        /// The instance of the EntityManager
        /// </summary>
        internal static EntityManager Instance { get { if (instance == null) instance = new EntityManager(); return instance; }}
        private static EntityManager instance = null;
        private EntityManager() { }

        #endregion

        /// <summary>
        /// Get all the entities
        /// </summary>
        internal Entity[] Entities { get { return entities.ToArray(); } }

        /// <summary>
        /// the list of entities
        /// </summary>
        private List<Entity> entities = new List<Entity>();

        /// <summary>
        /// Add a entity to the list
        /// </summary>
        /// <param name="entity"></param>
        internal void AddEntity(Entity entity) { entities.Add(entity); }

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
