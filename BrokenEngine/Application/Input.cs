using BrokenEngine.Maths;

namespace BrokenEngine.Application
{

    public static class Input
    {
        #region Enums
        public enum InputAction { }
        public enum Keys { }
        public enum MouseButtons { }
        #endregion

        #region Properties

        public static Vec2 MousePosition { get; internal set; }

        #endregion

        #region Variables
        private static InputAction[] keys;
        private static MouseButtons[] mouseButtons;
        private static Vec2 mousePosition;
        #endregion

        #region Methods

        public static InputAction GetKey(Keys key) { throw new System.NotImplementedException(); }
        public static bool GetKeyDown(Keys key) { throw new System.NotImplementedException(); }
        public static InputAction GetMouseButton(MouseButtons button) { throw new System.NotImplementedException(); }
        public static bool GetMouseButtonDown(MouseButtons button) { throw new System.NotImplementedException(); }

        internal static void SetKey(int keycode, InputAction action) { throw new System.NotImplementedException(); }
        internal static void SetMouseButton(int button, InputAction action) { throw new System.NotImplementedException(); }

        #endregion
    }
}
