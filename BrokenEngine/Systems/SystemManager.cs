using System.Collections.Generic;

namespace BrokenEngine.Systems
{
    public class SystemManager
    {
        #region Singleton pattern

        internal SystemManager Instance { get; set; }
        private SystemManager instance = null;
        private SystemManager() { }

        #endregion

        private List<BaseSystem> systems;

        public SysType GetSystem<SysType>() where SysType : BaseSystem { throw new System.NotImplementedException(); }
        public void RegisterSystem(BaseSystem system) { throw new System.NotImplementedException(); }

        public void Start() { throw new System.NotImplementedException(); }
        public void Update() { throw new System.NotImplementedException(); }
        public void Draw() { throw new System.NotImplementedException(); }
    }
}
