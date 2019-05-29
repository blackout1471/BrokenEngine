using BrokenEngine;
using BrokenEngine.Graphics;
using Tower_Defense.GUI;

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
            TextureManager.Instance.LoadFont("GameFont", new Font("..//..//Assets/Fonts/Bebas.ttf"));

            // Load UI
            UIManager.Instance.Initialise();
        }

        protected override void OnUpdate()
        {
            return;
        }
    }
}
