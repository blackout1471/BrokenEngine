using BrokenEngine.Components;
using BrokenEngine.Graphics;
using BrokenEngine.Maths;
using System;
using Tower_Defense.GUI;

namespace Tower_Defense.Scenes
{
    public class MainMenu : Scene
    {
        Color buttonBgColor     = new Color(255, 205, 185);
        Color buttonTextColor   = Color.Black;
        Vec2 buttonSize         = new Vec2(200, 50);

        public MainMenu() : base("MainMenu")
        {
        }

        protected internal override void OnLoad()
        {
            // Main Menu GUI
            Title mainMenuTitle     = new Title("Main Menu", Color.Green, new Vec2(410, 500));
            GUI.Button mainMenuPlay     = new GUI.Button(new Vec2(400, 440), buttonSize, buttonBgColor, "Play", buttonTextColor);
            GUI.Button mainMenuEditor   = new GUI.Button(new Vec2(400, 380), buttonSize, buttonBgColor, "Editor", buttonTextColor);
            GUI.Button mainMenuSettings = new GUI.Button(new Vec2(400, 320), buttonSize, buttonBgColor, "Settings", buttonTextColor);
            GUI.Button mainMenuExit     = new GUI.Button(new Vec2(400, 260), buttonSize, buttonBgColor, "Exit", buttonTextColor);

            // Set tag
            mainMenuTitle.Tag       = "MainMenu";
            mainMenuTitle.Tag       = "MainMenu";
            mainMenuPlay.Tag        = "MainMenu";
            mainMenuEditor.Tag      = "MainMenu";
            mainMenuSettings.Tag    = "MainMenu";
            mainMenuExit.Tag        = "MainMenu";


            // Add Delegates
            mainMenuEditor.AddClickEvent(LoadEditor);
            mainMenuSettings.AddClickEvent(ShowSettingsMenu);
            mainMenuExit.AddClickEvent(Exit);

            // Settings Menu GUI
            Title settingsTitle = new Title("Main Menu", Color.Green, new Vec2(410, 500));
            GUI.Button settingsRes = new GUI.Button(new Vec2(400, 440), buttonSize, buttonBgColor, "Resolution", buttonTextColor);
            GUI.Button settingsBack = new GUI.Button(new Vec2(400, 380), buttonSize, buttonBgColor, "Back", buttonTextColor);

            // Set Tag
            settingsTitle.Tag   = "SettingsMenu";
            settingsRes.Tag     = "SettingsMenu";
            settingsBack.Tag    = "SettingsMenu";

            // Add Delegates
            settingsBack.AddClickEvent(ShowMainMenu);

            // Show Main Menu First
            ShowEntityGroup("MainMenu");

        }

        private void LoadEditor(Entity sender)
        {
            SceneManager.LoadScene("Editor");
        }

        private void ShowSettingsMenu(Entity sender)
        {
            ShowEntityGroup("SettingsMenu");
        }

        private void ShowMainMenu(Entity sender)
        {
            ShowEntityGroup("MainMenu");
        }


        private void Exit(Entity sender)
        {
            Environment.Exit(-1);
        }
    }
}
