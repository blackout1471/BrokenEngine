using BrokenEngine.Application;

namespace BrokenEngine
{
    public abstract class Core
    {
        #region Variables

        private bool running;
        Window window;

        #endregion

        #region Private Methods

        private void Start() { throw new System.NotImplementedException(); }
        private void Update() { throw new System.NotImplementedException(); }

        #endregion

        #region Abstracted methods

        protected abstract void OnStart();
        protected abstract void OnUpdate();

        #endregion
    }
}
