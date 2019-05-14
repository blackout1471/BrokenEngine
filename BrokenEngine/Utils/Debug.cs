using System;
using System.Runtime.InteropServices;

namespace BrokenEngine.Utils
{
    public static class Debug
    {
        /// <summary>
        /// Frees the console from the main thread
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        private static extern bool FreeConsole();

        #region Properties

        /// <summary>
        /// Sets whether the the engine should do debugging
        /// or get if it is activated
        /// </summary>
        public static bool DoDebug { get { return debug; } set { debug = value; } }
        private static bool debug = true;

        #endregion

        #region Enums

        /// <summary>
        /// The debug layers that is currently available
        /// </summary>
        public enum DebugLayer
        {
            Application,
            Input,
            Entity,
            Shaders,
            Textures,
            Render,
            IO,
            Time,
            Game
        }

        /// <summary>
        /// The level of the current debug instance
        /// </summary>
        public enum DebugLevel
        {
            Information = 15,
            Warning = 14,
            Error = 12
        }

        #endregion

        /// <summary>
        /// The layers which is deactivated
        /// </summary>
        private static bool[] disabledDebugLayers = new bool[Enum.GetNames(typeof(DebugLayer)).Length];

        #region Methods

        /// <summary>
        /// Initialise the state of the console
        /// TODO: REMOVE CONSOLE
        /// </summary>
        public static void InitialiseDebug()
        {
            if (!debug)
            {
                FreeConsole();
            }
        }

        /// <summary>
        /// Log the current instance
        /// </summary>
        /// <param name="message"></param>
        /// <param name="layer"></param>
        public static void Log(string message, DebugLayer layer = DebugLayer.Game, DebugLevel level = DebugLevel.Information)
        {
            if (!debug)
                return;

            if (disabledDebugLayers[(int)layer])
                return;

            string print = string.Format("{0} {1} Time: {2}", layer, message, DateTime.Now.TimeOfDay);

            Console.ForegroundColor = (ConsoleColor)level;
            Console.WriteLine(print);
        }

        /// <summary>
        /// Sets whether the current layer should be disabled or enabled for debugging
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="activation"></param>
        public static void SetLayer(DebugLayer layer, bool activation)
        {
            disabledDebugLayers[(int)layer] = activation;
        }

        #endregion
    }
}
