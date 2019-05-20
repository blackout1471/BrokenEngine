using OpenGL;
using BrokenEngine.Application;
using BrokenEngine.Utils;
using BrokenEngine.Systems;
using BrokenEngine.Components;
using BrokenEngine.Systems.Renders;
using BrokenEngine.Systems.Physics;
using BrokenEngine.Graphics;
using BrokenEngine.Maths;
using System;

namespace BrokenEngine
{
    public abstract class Core
    {
        #region Window Methods
        /// <summary>
        /// Set the window size
        /// </summary>
        /// <param name="fullScreen">Set if window should be fullscreen</param>
        /// <param name="width">if 0 set to primary monitor width</param>
        /// <param name="height">if 0 set to primary monitor height</param>
        public void SetWindowSize(bool fullScreen, int width = 0, int height = 0)
        {
            window.SetSize(fullScreen, width, height);
            Gl.Viewport(0, 0, window.Width, window.Height);
            Shader.SetUniformsM4("pr_matrix", Matrix4f.Orthogonal(window.Width, 0, window.Height, 0, -1.0f, 1.0f));
        }

        /// <summary>
        /// Sets the window title
        /// </summary>
        /// <param name="title"></param>
        public void SetWindowTitle(string title)
        {
            window.SetTitle(title);
        }

        #endregion

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

            // Load all the default shaders
            Shader.LoadDefaultShaders();

            // Register the systems
            SystemManager.Instance.RegisterSystem(new Renderer2D());
            SystemManager.Instance.RegisterSystem(new BoxCollisionSystem());
            SystemManager.Instance.RegisterSystem(new ParticleRenderer());

            // Start all the Systems
            EntityManager.Instance.StartEntities();
            SystemManager.Instance.Start();
        }

        /// <summary>
        /// Updates all the engine related stuff
        /// </summary>
        private void Update()
        {
            EntityManager.Instance.UpdateEntities();
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
