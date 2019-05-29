using BrokenEngine;
using BrokenEngine.Graphics;
using BrokenEngine.Utils;
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
            
            // Disable debugging layer
            Debug.SetLayer(Debug.DebugLayer.Input, true);

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
