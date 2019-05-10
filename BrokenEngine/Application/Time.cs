namespace BrokenEngine.Application
{
    public static class Time
    {
        /// <summary>
        /// Get the delta time from each frame
        /// </summary>
        public static float DeltaTime { get; internal set; }

        /// <summary>
        /// Get the Frames per second
        /// </summary>
        public static int FPS { get; internal set; }
    }
}
