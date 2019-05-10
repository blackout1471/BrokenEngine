using System.Collections.Generic;

namespace BrokenEngine.Components
{
    class EntityManager
    {
        #region Singleton

        internal EntityManager Instance { get; set; }
        private EntityManager instance = null;
        private EntityManager() { }

        #endregion
        internal Entity[] Entities { get; }

        private List<Entity> entities;

        internal void AddEntity(Entity entity) { throw new System.NotImplementedException(); }
    }
}
