using BrokenEngine;
using BrokenEngine.Graphics;
using BrokenEngine.Utils;
using Tower_Defense.Scenes;

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

            // Load default Texture
            Texture errorTexture = new Texture("..//..//Assets/Img/ErrorTexture.png");
            TextureManager.Instance.LoadTexture("ErrorTexture", errorTexture);

            // Load editor textures
            Texture nodeButtonText = new Texture("..//..//Assets/Img/NodeButtonImg.png");
            Texture areaButtonText = new Texture("..//..//Assets/Img/AreaButtonImg.png");
            TextureManager.Instance.LoadTexture("NodeButtonTexture", nodeButtonText);
            TextureManager.Instance.LoadTexture("AreaButtonTexture", areaButtonText);

            // Load Nodes Textures
            Texture nodeImg = new Texture("..//..//Assets/Img/PathNodeImg.png");
            Texture areaImg = new Texture("..//..//Assets/Img/AreaNodeImg.png");
            TextureManager.Instance.LoadTexture("PathNodeTexture", nodeImg);
            TextureManager.Instance.LoadTexture("AreaNodeTexture", areaImg);

            // Add The scenes
            SceneManager.AddScene(new MainMenu());

            SceneManager.LoadScene("MainMenu");

        }

        protected override void OnUpdate()
        {
        }

    }
}
