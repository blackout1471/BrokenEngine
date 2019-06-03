using BrokenEngine.Components;
using BrokenEngine.Graphics;
using BrokenEngine.Maths;
using BrokenEngine.Systems;
using System;
using System.IO;
using Tower_Defense.GUI;

namespace Tower_Defense.Scenes
{
    public class MainMenu : Scene
    {

        public MainMenu() : base("MainMenu")
        {

        }


        protected internal override void OnLoad()
        {

            // Main Menu
            Title mainTitle = new Title("Main Menu", Color.Green, new Vec2(410, 500), "MainMenu");
            MenuButton mainPlay = new MenuButton("Play", new Vec2(400, 440), null, "MainMenu");
            MenuButton mainEditor = new MenuButton("Editor", new Vec2(400, 380), ShowEditorMenu, "MainMenu");
            MenuButton mainSettings = new MenuButton("Settings", new Vec2(400, 320), ShowSettingsMenu, "MainMenu");
            MenuButton mainExit = new MenuButton("Exit", new Vec2(400, 260), Exit, "MainMenu");

            // Editor menu
            Title editorTitle = new Title("Editor", Color.Green, new Vec2(410, 500), "EditorMenu");
            MenuButton back = new MenuButton("Back", new Vec2(110, 35), ShowMainMenu, "EditorMenu");
            for (int i = 0; i < Program.MapsCount; i++)
            {
                MapButton map = new MapButton("Map" + i, new Vec2((i+1) * 110, 400), "EditorMenu", i);
            }

            // Settings Menu
            Title settingsTitle = new Title("Settings", Color.Green, new Vec2(410, 500), "SettingsMenu");
            MenuButton settingsRes = new MenuButton("Resolution", new Vec2(400, 440), null, "SettingsMenu");
            MenuButton settingsBack = new MenuButton("Back", new Vec2(400, 380), ShowMainMenu, "SettingsMenu");

            ShowEntityGroup("MainMenu");
        }

        private void ShowMainMenu()
        {
            ShowEntityGroup("MainMenu");
        }

        private void ShowSettingsMenu()
        {
            ShowEntityGroup("SettingsMenu");
        }

        private void ShowEditorMenu()
        {
            ShowEntityGroup("EditorMenu");
        }


        private void Exit()
        {
            Environment.Exit(-1);
        }

        /// <summary>
        /// Hides all entities except for the given tag
        /// </summary>
        /// <param name="groupTag"></param>
        private void ShowEntityGroup(string groupTag)
        {
            Entity[] entities = EntityManager.Instance.GetEntities();

            for (int i = 0; i < entities.Length; i++)
            {
                entities[i].EntityEnabled = false;

                if (entities[i].Tag == groupTag)
                    entities[i].EntityEnabled = true;
            }
        }
    }
}
