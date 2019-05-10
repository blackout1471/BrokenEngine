using Glfw3;

namespace BrokenEngine.Application
{
    internal class Window
    {
        #region Variables

        private Glfw.Window window;
        private int width;
        private int height;
        private string title;

        private Glfw.KeyFunc keyboardDel;
        private Glfw.MouseButtonFunc mouseButtonDel;
        private Glfw.CursorPosFunc cursorPos;

        #endregion

        public Window() { }

        #region Private Methods
        private void KeyboardCallBack(Glfw.Window window, Glfw.KeyCode key, int scancode, Glfw.InputState state, Glfw.KeyMods mods) { }

        private void MouseButtonCallBack(Glfw.Window window, Glfw.MouseButton button, Glfw.InputState state, Glfw.KeyMods mods) { }

        private void CursorPosCallBack(Glfw.Window window, double x, double y) { throw new System.NotImplementedException(); }
        #endregion

        #region Internal methods
        internal void Init() { }

        internal void SetSize(int width, int height) { throw new System.NotImplementedException(); }

        internal void SetTitle(string title) { throw new System.NotImplementedException(); }

        internal bool ShouldWindowClose() { throw new System.NotImplementedException(); }

        internal void Destroy() { throw new System.NotImplementedException(); }
        #endregion
    }
}
