using OpenGL;
using BrokenEngine.Application;
using BrokenEngine.Utils;
using BrokenEngine.Systems;
using System;

namespace BrokenEngine
{
    public abstract class Core
    {
        #region Variables

        private bool running = true;
        private Window window;

        #endregion

        #region Private Methods
        
        /// <summary>
        /// Starts all the engine related stuff
        /// </summary>
        private void Start()
        {
            Gl.Initialize();

            window = new Window();
            window.Init();
            Gl.Viewport(0, 0, window.Width, window.Height);


            // Start all the Systems
            SystemManager.Instance.Start();
        }

        /// <summary>
        /// Updates all the engine related stuff
        /// </summary>
        private void Update()
        {
            SystemManager.Instance.Update();
        }

        /// <summary>
        /// Draws all the engine related stuff
        /// </summary>
        private void Draw()
        {
            SystemManager.Instance.Draw();
        }

        #endregion

        #region Abstracted methods
        
        /// <summary>
        /// The onstart methods call on start of the program
        /// </summary>
        protected abstract void OnStart();

        /// <summary>
        /// The OnUpdate method call every frame
        /// </summary>
        protected abstract void OnUpdate();

        /// <summary>
        /// Method which will be called before start
        /// </summary>
        protected virtual void Initialise() { return; }

        #endregion

        /// <summary>
        /// Runs the engine
        /// </summary>
        public void RunEngine()
        {
            Initialise();

            Start();
            OnStart();
            Debug.InitialiseDebug();

            // The variables for the delta time
            DateTime t1, t2;
            t1 = t2 = DateTime.Now;

            while (running)
            {
                // Calculate the delta time
                t2 = DateTime.Now;
                float elapsedDelta = (float)(t2 - t1).TotalSeconds;
                t1 = t2;

                // Set delta and fos
                Time.DeltaTime = elapsedDelta;
                Time.FPS = (int)(1.0f / elapsedDelta);

                // Clear color and depth buffer | Set the clear color for each frame
                Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                Gl.ClearColor(0f, 0f, 0.7f, 1.0f);

                OnUpdate();
                Update();

                // Render here
                Draw();

                running = !window.ShouldWindowClose();


                if (Debug.DoDebug)
                {
                    ErrorCode glError = Gl.GetError();
                    if (glError != ErrorCode.NoError)
                        Debug.Log("Opengl Error: " + glError, Debug.DebugLayer.Render, Debug.DebugLevel.Error);
                }
            }

            window.Destroy();
        }
    }
}
