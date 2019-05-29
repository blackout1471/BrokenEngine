using BrokenEngine.Components;
using BrokenEngine.Maths;
using BrokenEngine.Graphics;
using Tower_Defense.GUI;
using BrokenEngine.Utils;

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
        Vec2 buttonSize = new Vec2(200, 70);
        Color bgColor = new Color(255, 200, 165);
        Color textColor = Color.Black;
        #endregion

        public UIManager()
        {
        }

        public void Initialise()
        {
            InitialiseSettings();
            HideAll();

            // Show Main Menu
            InitialiseMainMenu();
        }

        /// <summary>
        /// Initialise all the graphics
        /// </summary>
        public void InitialiseMainMenu()
        {
            MenuTitle title = new MenuTitle(new Vec2(420, 400), 24, "Main Menu", Color.Green, "MainMenu");
            MenuButton playButton = new MenuButton(new Vec2(400, 300), buttonSize, textColor, "Play", bgColor, "MainMenu", HideAll);
            MenuButton Settings = new MenuButton(new Vec2(400, 200), buttonSize, textColor, "Settings", bgColor, "MainMenu", ShowSettings);
            MenuButton Exit = new MenuButton(new Vec2(400, 100), buttonSize, textColor, "Exit", bgColor, "MainMenu", HideAll);
        }

        public void InitialiseSettings()
        {
            MenuTitle title = new MenuTitle(new Vec2(420, 400), 24, "Settings", Color.Green, "SettingsMenu");
            MenuButton resolution = new MenuButton(new Vec2(400, 300), buttonSize, textColor, "Resolution", bgColor, "SettingsMenu", HideAll);
            MenuButton Back = new MenuButton(new Vec2(400, 100), buttonSize, textColor, "Back", bgColor, "SettingsMenu", ShowMainMenu);
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
