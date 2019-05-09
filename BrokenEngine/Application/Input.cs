using BrokenEngine.Maths;

namespace BrokenEngine.Application
{

    public static class Input
    {
        public enum InputAction { }
        public enum Keys { }
        public enum MouseButtons { }

        public static Vec2 MousePosition { get; internal set; }

        private static InputAction[] keys;
        private static MouseButtons[] mouseButtons;
        private static Vec2 mousePosition;

        public static InputAction GetKey(Keys key) { return null; }

        internal static void SetKey(int keycode, InputAction action) { }
    }
}
