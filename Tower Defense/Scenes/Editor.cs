using BrokenEngine.Components;
using BrokenEngine.Graphics;
using BrokenEngine.Maths;
using System.Collections.Generic;
using Tower_Defense.GUI;
using Tower_Defense.Prefabs;
using Tower_Defense.Uitls;

namespace Tower_Defense.Scenes
{
    public class Editor : Scene
    {
        public Editor() : base("Editor")
        {

        }

        protected internal override void OnLoad()
        {
            Map editorMap = new Map("Map" + Program.CurrentMap, new Vec2(400, 300), new Vec2(800, 600), Program.CurrentMap);
            GameButton path = new GameButton("Path", new Vec2(40, 30), new Vec2(60, 30), AddNewPathNode, "EditorGUI");
            GameButton area = new GameButton("Area", new Vec2(110, 30), new Vec2(60, 30), AddNewAreaNode, "EditorGUI");
            GameButton save = new GameButton("Save", new Vec2(660, 25), new Vec2(60, 30), editorMap.SaveData, "EditorGUI");
            GameButton back = new GameButton("Back", new Vec2(730, 25), new Vec2(60, 30), LoadMainMenu, "EditorGUI");

            MapData.LoadMapData("Map" + Program.CurrentMap);
        }

        private void AddNewPathNode()
        {
            Node node = new Node(new Vec2(0, 0), NodeType.Path, null, true);
        }

        private void AddNewAreaNode()
        {
            Node node = new Node(new Vec2(0, 0), NodeType.Area, null, true);
        }

        private void LoadMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
}
