using BrokenEngine.Components;
using BrokenEngine.Maths;
using BrokenEngine.Graphics;
using Tower_Defense.GUI;
using BrokenEngine.Utils;
using System.IO;

namespace Tower_Defense
{
    public class UIManager
    {
        #region Singleton
        public static UIManager Instance
        {
            get
            {
                return instance;
            }
        }

        private static readonly UIManager instance = new UIManager();
        #endregion

        #region UI Variables
        // Normal buttons
        private Vec2 buttonSize = new Vec2(200, 70);
        private Color bgColor = new Color(255, 200, 165);
        private Color textColor = Color.Black;

        private Vec2 startpos = new Vec2(400, 500);
        private Vec2 yPadding = new Vec2(0, 10f);


        // Map buttons
        private string mapFolderDest = "..//..//Assets/Img/Maps/";
        private int mapCount;

        private Vec2 mapButtonSize = new Vec2(100, 100);
        private Vec2 mapButtonPadding = new Vec2(10f, 10f);
        #endregion

        public UIManager()
        {
        }

        public void Initialise()
        {
            LoadMapImg();

            InitialiseSettings();
            InitialiseEditorMenu();

            HideAll();

            // Show Main Menu
            InitialiseMainMenu();
        }

        /// <summary>
        /// Load all the map img's
        /// </summary>
        private void LoadMapImg()
        {
            string[] mapFiles = Directory.GetFiles(mapFolderDest);
            mapCount = mapFiles.Length;

            for (int i = 0; i < mapFiles.Length; i++)
            {
                Texture curMap = new Texture(mapFiles[i]);
                TextureManager.Instance.LoadTexture("Map" + i, curMap);
            }
        }

        /// <summary>
        /// Initialise all the graphics
        /// </summary>
        public void InitialiseMainMenu()
        {
            MenuTitle title = new MenuTitle(startpos + new Vec2(20, 0), 24, "Main Menu", Color.Green, "MainMenu");
            MenuButton playButton = new MenuButton(startpos - (new Vec2(0, buttonSize.Y) * 1) - (yPadding * 1), buttonSize, textColor, "Play", bgColor, "MainMenu", HideAll);
            MenuButton editorButton = new MenuButton(startpos - (new Vec2(0, buttonSize.Y) * 2) - (yPadding * 2), buttonSize, textColor, "Editor", bgColor, "MainMenu", ShowEditorMenu);
            MenuButton Settings = new MenuButton(startpos - (new Vec2(0, buttonSize.Y) * 3) - (yPadding * 3), buttonSize, textColor, "Settings", bgColor, "MainMenu", ShowSettings);
            MenuButton Exit = new MenuButton(startpos - (new Vec2(0, buttonSize.Y) * 4) - (yPadding * 4), buttonSize, textColor, "Exit", bgColor, "MainMenu", HideAll);
        }

        public void InitialiseEditorMenu()
        {
            MenuTitle title = new MenuTitle(startpos + new Vec2(20, 0), 24, "Editor Menu", Color.Green, "EditorMenu");

            for (int i = 0; i < mapCount; i++)
            {
                MapButton curButton = new MapButton("Map" + i, mapButtonSize, mapButtonSize * (i + 1), "EditorMenu", null);
            }
        }

        public void InitialiseSettings()
        {
            MenuTitle title = new MenuTitle(startpos + new Vec2(20, 0), 24, "Settings", Color.Green, "SettingsMenu");
            MenuButton resolution = new MenuButton(startpos - (new Vec2(0, buttonSize.Y) * 1) - (yPadding * 1), buttonSize, textColor, "Resolution", bgColor, "SettingsMenu", HideAll);
            MenuButton Back = new MenuButton(startpos - (new Vec2(0, buttonSize.Y) * 2) - (yPadding * 2), buttonSize, textColor, "Back", bgColor, "SettingsMenu", ShowMainMenu);
        }

        /// <summary>
        /// Shows the main menu
        /// </summary>
        public void ShowMainMenu()
        {
            Debug.Log("showing main");
            HideAll();
            ShowMenu("MainMenu");
        }

        public void ShowEditorMenu()
        {
            Debug.Log("showing EditorMenu");
            HideAll();
            ShowMenu("EditorMenu");
        }

        /// <summary>
        /// Show the settings menu
        /// </summary>
        public void ShowSettings()
        {
            Debug.Log("Showing settings");
            HideAll();
            ShowMenu("SettingsMenu");
        }

        #region Global menu methods
        /// <summary>
        /// Hides the main menu
        /// </summary>
        public void HideAll()
        {
            Entity[] menus = EntityManager.Instance.GetEntities();

            for (int i = 0; i < menus.Length; i++)
            {
                menus[i].EntityEnabled = false;
            }
        }

        /// <summary>
        /// Shows a group of entities
        /// </summary>
        /// <param name="tag"></param>
        public void ShowMenu(string tag)
        {
            Entity[] menus = EntityManager.Instance.GetEntitiesWithTags(tag);

            for (int i = 0; i < menus.Length; i++)
            {
                menus[i].EntityEnabled = true;
            }
        }

        #endregion

    }
}
