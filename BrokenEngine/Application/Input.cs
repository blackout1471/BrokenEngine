using BrokenEngine.Maths;

namespace BrokenEngine.Application
{

    public static class Input
    {
        #region Enums

        public enum InputAction
        {
            Released,
            Pressed,
            Repeated
        };

        public enum Keys
        {
            Key_UNKNOWN = -1,

            Key_SPACE = 32,

            Key_APOSTROPHE = 39,

            Key_COMMA = 44,

            Key_MINUS = 45,

            Key_PERIOD = 46,

            Key_SLASH = 47,

            Key_0 = 48,

            Key_1 = 49,

            Key_2 = 50,

            Key_3 = 51,

            Key_4 = 52,

            Key_5 = 53,

            Key_6 = 54,

            Key_7 = 55,

            Key_8 = 56,

            Key_9 = 57,

            Key_A = 65,

            Key_B = 66,

            Key_C = 67,

            Key_D = 68,

            Key_E = 69,

            Key_F = 70,

            Key_G = 71,

            Key_H = 72,

            Key_I = 73,

            Key_J = 74,

            Key_K = 75,

            Key_L = 76,

            Key_M = 77,

            Key_N = 78,

            Key_O = 79,

            Key_P = 80,

            Key_Q = 81,

            Key_R = 82,

            Key_S = 83,

            Key_T = 84,

            Key_U = 85,

            Key_V = 86,

            Key_W = 87,

            Key_X = 88,

            Key_Y = 89,

            Key_Z = 90,

            Key_ENTER = 257,

            Key_INSERT = 260,

            Key_DELETE = 261,

            Key_RIGHT = 262,

            Key_LEFT = 263,

            Key_DOWN = 264,

            Key_UP = 265,
        }

        public enum MouseButtons
        {
            button1 = 0,
            button2 = 1,
            button3 = 2,
            button4 = 3,
            button5 = 4,
            button6 = 5,
            button7 = 6,
            button8 = 7
        }

        #endregion

        #region Properties

        public static Vec2 MousePosition { get { return mousePosition; } internal set { mousePosition = value; } }

        #endregion

        #region Variables

        private static InputAction[] keys = new InputAction[256];
        private static InputAction[] mouseButtons = new InputAction[8];
        private static Vec2 mousePosition = new Vec2(0, 0);

        #endregion

        #region Methods

        /// <summary>
        /// Gets the key and its current state
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static InputAction GetKey(Keys key)
        {
            return keys[(int)key];
        }

        /// <summary>
        /// Get whether the key is down or not
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetKeyDown(Keys key)
        {
            if (keys[(int)key] == InputAction.Pressed || keys[(int)key] == InputAction.Repeated)
                return true;

            return false;
        }

        /// <summary>
        /// Get the mouse button and its state
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public static InputAction GetMouseButton(MouseButtons button)
        {
            return mouseButtons[(int)button];
        }

        /// <summary>
        /// Get whether a mouse button is down or not
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public static bool GetMouseButtonDown(MouseButtons button)
        {
            if (mouseButtons[(int)button] == InputAction.Pressed || mouseButtons[(int)button] == InputAction.Repeated)
                return true;

            return false;
        }

        /// <summary>
        /// Sets the key and its state
        /// </summary>
        /// <param name="keycode"></param>
        /// <param name="action"></param>
        internal static void SetKey(int keycode, InputAction action)
        {
            keys[keycode] = action;
        }

        /// <summary>
        /// Sets the mouse button and its state
        /// </summary>
        /// <param name="button"></param>
        /// <param name="action"></param>
        internal static void SetMouseButton(int button, InputAction action)
        {
            mouseButtons[button] = action;
        }

        #endregion
    }
}
