using BrokenEngine.Maths;
using BrokenEngine.Utils;
using Glfw3;

namespace BrokenEngine.Application
{
    internal class Window
    {
        #region Properties

        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public string Title { get { return title; } }

        #endregion

        #region Variables

        private Glfw.Window window = Glfw.Window.None;
        private Glfw.Monitor monitor = Glfw.Monitor.None;

        private int width       = 800;
        private int height      = 600;
        private string title    = "Broken Engine";
        private bool fullScreen = false;

        private Glfw.KeyFunc keyboardDel = null;
        private Glfw.MouseButtonFunc mouseButtonDel = null;
        private Glfw.CursorPosFunc cursorPosDel = null;

        #endregion

        public Window() { }

        #region Private Methods

        /// <summary>
        /// The callback method for the keyboard, will set the key from a keycode and a state
        /// </summary>
        /// <param name="window"></param>
        /// <param name="key"></param>
        /// <param name="scancode"></param>
        /// <param name="state"></param>
        /// <param name="mods"></param>
        private void KeyboardCallBack(Glfw.Window window, Glfw.KeyCode key, int scancode, Glfw.InputState state, Glfw.KeyMods mods)
        {
            int keyCode = (int)key;

            switch (state)
            {
                case Glfw.InputState.Repeat:
                    Input.SetKey(keyCode, Input.InputAction.Repeated);
                    break;

                case Glfw.InputState.Press:
                    Input.SetKey(keyCode, Input.InputAction.Pressed);
                    break;
                case Glfw.InputState.Release:
                    Input.SetKey(keyCode, Input.InputAction.Released);
                    break;
            }

            Debug.Log("Input Keyboard " + key, Debug.DebugLayer.Application);
        }

        /// <summary>
        /// The mouse button callback, will set the mouse button from a button and its state
        /// </summary>
        /// <param name="window"></param>
        /// <param name="button"></param>
        /// <param name="state"></param>
        /// <param name="mods"></param>
        private void MouseButtonCallBack(Glfw.Window window, Glfw.MouseButton button, Glfw.InputState state, Glfw.KeyMods mods)
        {
            switch (state)
            {
                case Glfw.InputState.Press:
                    Input.SetMouseButton((int)button, Input.InputAction.Pressed);
                    break;
                case Glfw.InputState.Release:
                    Input.SetMouseButton((int)button, Input.InputAction.Released);
                    break;
                case Glfw.InputState.Repeat:
                    Input.SetMouseButton((int)button, Input.InputAction.Repeated);
                    break;
            }

            Debug.Log("Input Mouse button " + button, Debug.DebugLayer.Application);
        }

        /// <summary>
        /// The cursor position callback, will set the cursor position in the MousePosition variable
        /// </summary>
        /// <param name="window"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void CursorPosCallBack(Glfw.Window window, double x, double y)
        {
            Input.MousePosition = new Vec2((float)x, height - (float)y);
        }

        #endregion

        #region Internal methods

        /// <summary>
        /// Initialises the Glfw library and creates a window
        /// </summary>
        internal void Init()
        {
            // Get the specified Glfw.dll's directory
            Glfw.ConfigureNativesDirectory("..//..//Vendor/");

            // Init library
            if (!Glfw.Init())
                Debug.Log("Could not initialise Glfw", Debug.DebugLayer.Application, Debug.DebugLevel.Error);

            // Get monitor settings
            monitor = Glfw.GetPrimaryMonitor();

            // Create window
            window = Glfw.CreateWindow(width, height, title, Glfw.Monitor.None, Glfw.Window.None);
            if (!window)
                Debug.Log("Could not create window", Debug.DebugLayer.Application, Debug.DebugLevel.Error);

            // Make the current window the context
            Glfw.MakeContextCurrent(window);

            // Let glfw swap the buffers as fast as possible - 0 for fast 1 - for v sync
            Glfw.SwapInterval(0);

            // Set callbacks
            keyboardDel     = KeyboardCallBack;
            mouseButtonDel  = MouseButtonCallBack;
            cursorPosDel    = CursorPosCallBack;

            Glfw.SetKeyCallback(window, keyboardDel);
            Glfw.SetMouseButtonCallback(window, mouseButtonDel);
            Glfw.SetCursorPosCallback(window, cursorPosDel);


            Debug.Log("Window Created", Debug.DebugLayer.Application);
        }

        /// <summary>
        /// Sets the size of the window
        /// </summary>
        /// <param name="width">the width in pixels</param>
        /// <param name="height">the height in pixels</param>
        internal void SetSize(bool fullscreen, int width = 0, int height = 0)
        {
            // Get monitor settings
            Glfw.VideoMode mode = Glfw.GetVideoMode(monitor);

            if (fullscreen)
            {
                Glfw.SetWindowMonitor(window, monitor, 0, 0, mode.Width, mode.Height, mode.RefreshRate);
            }
            else
            {
                Glfw.SetWindowMonitor(window, Glfw.Monitor.None, 0, 0, width, height, Glfw.DontCare);
            }

            // Check and see if window should be specific size
            if (width == 0 || height == 0)
            {
                this.width = mode.Width;
                this.height = mode.Height;
            }
            else
            {
                this.width = width;
                this.height = height;
            }

            this.fullScreen = fullscreen;

            // Sets the window size
            Glfw.SetWindowSize(window, this.width, this.height);

            Debug.Log("Window Size: " + width + " " + height, Debug.DebugLayer.Application);
        }

        /// <summary>
        /// Sets the title of the window
        /// </summary>
        /// <param name="title"></param>
        internal void SetTitle(string title)
        {
            this.title = title;

            // Set the title
            Glfw.SetWindowTitle(window, this.title);

            Debug.Log("Window Title " + title, Debug.DebugLayer.Application);
        }

        /// <summary>
        /// Check whether the window should be closed or not
        /// </summary>
        /// <returns>true if window should be closed and false if not</returns>
        internal bool ShouldWindowClose()
        {
            if (!Glfw.WindowShouldClose(window))
            {
                // Swaps the buffers
                Glfw.SwapBuffers(window);

                // Polls the events
                Glfw.PollEvents();

                return false;
            }

            return true;
        }

        /// <summary>
        /// Destroys the window
        /// </summary>
        internal void Destroy()
        {
            // Destroys the window
            Glfw.DestroyWindow(window);

            Debug.Log("Window Destroyed", Debug.DebugLayer.Application);
        }
        #endregion
    }
}
