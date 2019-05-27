using BrokenEngine;
using BrokenEngine.Graphics;

namespace Tower_Defense
{
    class Program : Core
    {
        static void Main(string[] args)
        {
            new Program().RunEngine();
        }

        protected override void OnStart()
        {
            SetWindowSize(false, 800, 600);
            SetWindowTitle("Tower Defense - Broken Engine");

            // Load Fonts
            TextureManager.Instance.LoadFont("GameFont", new Font("..//..//Assets/Fonts/GameFont.ttf"));
        }

        protected override void OnUpdate()
        {
            return;
        }
    }
}
