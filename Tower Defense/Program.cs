using BrokenEngine;
using BrokenEngine.Graphics;
using BrokenEngine.Utils;
using System;
using System.IO;
using Tower_Defense.Scenes;

namespace Tower_Defense
{
    class Program : Core
    {
        public static string MapsFolder { get => "..//..//Assets/Img/Maps"; }
        public static int MapsCount { get => mapsCount; }
        private static int mapsCount = 0;
        public static int CurrentMap { get => currentMap; set => currentMap = value; }
        private static int currentMap = 0;

        static void Main(string[] args)
        {
            new Program().RunEngine();
        }

        private void LoadMapsImgs()
        {
            string[] mapFiles = Directory.GetFiles(Program.MapsFolder);
            mapsCount = mapFiles.Length;

            for (int i = 0; i < mapFiles.Length; i++)
            {
                Texture curMap = new Texture(mapFiles[i]);
                TextureManager.Instance.LoadTexture("Map" + i, curMap);
            }
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

            // Load Maps
            LoadMapsImgs();

            // Add The scenes
            SceneManager.AddScene(new MainMenu());
            SceneManager.AddScene(new Editor());

            SceneManager.LoadScene("MainMenu");

        }

        protected override void OnUpdate()
        {
        }

    }
}
