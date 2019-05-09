using Glfw3;

namespace BrokenEngine.Application
{
    internal class Window
    {
        private Glfw.Window window;
        private int width;
        private int height;
        private string title;

        private Glfw.KeyFunc keyboardDel;
        private Glfw.MouseButtonFunc mouseButtonDel;
        private Glfw.CursorPosFunc cursorPos;

        public Window() { }

        #region Private Methods
        private void KeyboardCallBack(Glfw.Window window, Glfw.KeyCode key, int scancode, Glfw.InputState state, Glfw.KeyMods mods) { }

        private void MouseButtonCallBack(Glfw.Window window, Glfw.MouseButton button, Glfw.InputState state, Glfw.KeyMods mods) { }

        private void CursorPosCallBack(Glfw.Window window, double x, double y) { }
        #endregion

        #region Internal methods
        internal void Init() { }

        internal void SetSize(int width, int height) { }

        internal void SetTitle(string title) { }

        internal bool ShouldWindowClose() { return true; }

        internal void Destroy() { }
        #endregion
    }
}
