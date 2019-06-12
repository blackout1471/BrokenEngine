using BrokenEngine.Components;
using BrokenEngine.Graphics;
using BrokenEngine.Maths;
using System;
using Tower_Defense.GUI;
using Tower_Defense.Prefabs;

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
            #region Main Menu GUI

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
            mainMenuEditor.AddClickEvent(ShowEditorMenu);
            mainMenuSettings.AddClickEvent(ShowSettingsMenu);
            mainMenuExit.AddClickEvent(Exit);

            #endregion

            #region Settings GUI

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

            #endregion

            #region Editor GUI
            Title editorTitle = new Title("Editor", Color.Green, new Vec2(410, 500));
            GUI.Button editorCreate = new GUI.Button(new Vec2(400, 440), buttonSize, buttonBgColor, "Create New Map", buttonTextColor);
            GUI.Button editorEdit = new GUI.Button(new Vec2(400, 380), buttonSize, buttonBgColor, "Edit Map", buttonTextColor);
            GUI.Button editorBack = new GUI.Button(new Vec2(400, 320), buttonSize, buttonBgColor, "Back", buttonTextColor);

            // Set Tag
            editorTitle.Tag = "EditorMenu";
            editorCreate.Tag = "EditorMenu";
            editorEdit.Tag = "EditorMenu";
            editorBack.Tag = "EditorMenu";

            // Add Delegates
            editorCreate.AddClickEvent(ShowCreateMapMenu);
            editorEdit.AddClickEvent(ShowEditMapMenu);
            editorBack.AddClickEvent(ShowMainMenu);

            #endregion

            #region Create Map GUI
            // Load all imgs
            string[] imgPaths = Map.GetMapImgs();

            for (int i = 0; i < imgPaths.Length; i++)
            {
                Texture curText = new Texture(imgPaths[i]);

                TextureManager.Instance.LoadTexture(curText.Path, curText);

                GUI.Button curButMap = new GUI.Button(new Vec2((buttonSize.X/2) * (i+1) + (10 * i), 320), new Vec2(buttonSize.X/2, buttonSize.Y), curText.Path);
                curButMap.AddClickEvent(LoadNewMapScene);

                curButMap.Tag = "CreateMapMenu";
            }

            GUI.Title createTitle = new GUI.Title("Create New Map", Color.Green, new Vec2(410, 500));
            GUI.Button createBack = new GUI.Button(new Vec2(400, 100), buttonSize/2, buttonBgColor, "Back", buttonTextColor);

            createBack.Tag = "CreateMapMenu";
            createTitle.Tag = "CreateMapMenu";

            createBack.AddClickEvent(ShowMainMenu);

            #endregion

            #region Edit Map GUI
            // Load existing data
            string[] mapFiles = Map.GetMapFiles(true);

            for (int i = 0; i < mapFiles.Length; i++)
            {
                string[] mapData = Map.GetOnlyMapData(mapFiles[i]);

                Texture curText = new Texture(mapData[0]);

                TextureManager.Instance.LoadTexture(curText.Path, curText);

                GUI.Button curButMap = new GUI.Button(new Vec2((buttonSize.X / 2) * (i + 1) + (10 * i), 320), new Vec2(buttonSize.X / 2, buttonSize.Y), curText.Path);
                curButMap.EventArg = mapData[1];
                curButMap.AddClickEvent(LoadEditMapScene);

                curButMap.Tag = "EditMapMenu";
            }

            GUI.Title editTitle = new GUI.Title("Edit A Map", Color.Green, new Vec2(410, 500));
            GUI.Button editBack = new GUI.Button(new Vec2(400, 100), buttonSize / 2, buttonBgColor, "Back", buttonTextColor);

            editBack.Tag = "EditMapMenu";
            editTitle.Tag = "EditMapMenu";

            editBack.AddClickEvent(ShowMainMenu);

            #endregion

            // Show Main Menu First
            ShowEntityGroup("MainMenu");

        }

        #region GUI Events

        private void ShowSettingsMenu(Entity sender)
        {
            ShowEntityGroup("SettingsMenu");
        }

        private void ShowMainMenu(Entity sender)
        {
            ShowEntityGroup("MainMenu");
        }

        private void ShowEditorMenu(Entity sender)
        {
            ShowEntityGroup("EditorMenu");
        }

        private void ShowCreateMapMenu(Entity sender)
        {
            ShowEntityGroup("CreateMapMenu");
        }

        private void ShowEditMapMenu(Entity sender)
        {
            ShowEntityGroup("EditMapMenu");
        }

        private void LoadNewMapScene(Entity sender)
        {
            SceneManager.LoadScene("NewMap", sender.GetComponent<Sprite>().TextureName);
        }

        /// <summary>
        /// Loads the edit map scene can only be used by GUI.Button
        /// </summary>
        /// <param name="sender"></param>
        private void LoadEditMapScene(Entity sender)
        {
            GUI.Button but = (GUI.Button)sender;

            SceneManager.LoadScene("EditMap", but.EventArg);
        }


        private void Exit(Entity sender)
        {
            Environment.Exit(-1);
        }

        #endregion


        protected internal override void OnLoad(object obj)
        {
            throw new NotImplementedException("Not Implemented");
        }
    }
}
