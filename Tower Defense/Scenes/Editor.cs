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
        private Color buttonBgColor     = new Color(255, 205, 185);
        private Color buttonTextColor   = Color.Black;
        private Vec2 buttonSize         = new Vec2(100, 50);
        private int curPathGroup;
        private int curAreaGroup;
        private List<Node> nodes;
        private string curMap;

        public Editor() : base("Editor")
        {

        }

        protected internal override void OnLoad()
        {
            curPathGroup    = 0;
            curAreaGroup    = 0;
            nodes           = new List<Node>();
            curMap          = "";

            // Map Loader GUI
            Title mapLoaderTitle    = new Title("Select Map To Edit", Color.Green, new Vec2(410, 500));
            GUI.Button backButton   = new GUI.Button(new Vec2(400, 35), buttonSize, buttonBgColor, "Back", buttonTextColor);

            // Load Maps as buttons that has been registered
            for (int i = 0; i < Program.MapsCount; i++)
            {
                Map createNew = new Map("Map" + i, new Vec2(100 * (i + 1), 200));
                createNew.Tag = "MapLoader";
                createNew.AddClickEvent(ShowEditorGUI);
                createNew.AddClickEvent(SelectedMapEvent);
            }

            // Set group
            mapLoaderTitle.Tag  = "MapLoader";
            backButton.Tag      = "MapLoader";

            // Set Delegates
            backButton.AddClickEvent(LoadMainMenu);

            // Editor GUI
            GUI.Button backBut = new GUI.Button(new Vec2(740, 35), buttonSize * 0.7f, buttonBgColor, "Back", buttonTextColor);
            GUI.Button saveBut = new GUI.Button(new Vec2(630, 35), buttonSize * 0.7f, buttonBgColor, "Save", buttonTextColor);
            GUI.Button pathBut = new GUI.Button(new Vec2(60, 35), buttonSize * 0.7f, "NodeButtonTexture");
            GUI.Button areaBut = new GUI.Button(new Vec2(170, 35), buttonSize * 0.7f, "AreaButtonTexture");

            // Set group
            backBut.Tag = "EditorGUI";
            saveBut.Tag = "EditorGUI";
            pathBut.Tag = "EditorGUI";
            areaBut.Tag = "EditorGUI";

            // Set Delegates
            saveBut.AddClickEvent(SaveNodeData);
            backBut.AddClickEvent(LoadMainMenu);
            pathBut.AddClickEvent(HideEditorGUI);
            pathBut.AddClickEvent(AddNodePathButton);
            areaBut.AddClickEvent(HideEditorGUI);
            areaBut.AddClickEvent(AddNodeAreaButton);

            ShowEntityGroup("MapLoader");

        }

        private void SaveNodeData(Entity sender)
        {
            Map.SaveData(nodes, curPathGroup, curAreaGroup, curMap);
        }

        #region Node Methods

        private void AddNodePathButton(Entity sender)
        {
            Node pathNode = new Node(new Vec2(0, 0), new Vec2(15, 15), NodeType.Path);
            pathNode.AddRightClickEvent(ShowEditorGUI);
            pathNode.AddRightClickEvent(RemoveNode);
            pathNode.AddLeftClickEvent(AddNodePath);

            curPathGroup += 1;
            pathNode.Group = curPathGroup;

            nodes.Add(pathNode);
        }

        private void AddNodePath(Entity sender)
        {
            Node pathNode = new Node(new Vec2(0, 0), new Vec2(15, 15), NodeType.Path);
            pathNode.AddRightClickEvent(ShowEditorGUI);
            pathNode.AddLeftClickEvent(AddNodePath);
            pathNode.AddRightClickEvent(RemoveNode);

            pathNode.Group = curPathGroup;

            nodes.Add(pathNode);
        }

        private void AddNodeAreaButton(Entity sender)
        {
            Node areaNode = new Node(new Vec2(0, 0), new Vec2(15, 15), NodeType.Area);
            areaNode.AddRightClickEvent(ShowEditorGUI);
            areaNode.AddLeftClickEvent(AddNodeArea);
            areaNode.AddRightClickEvent(RemoveNode);

            curAreaGroup += 1;
            areaNode.Group = curAreaGroup;

            nodes.Add(areaNode);
        }

        private void AddNodeArea(Entity sender)
        {
            Node areaNode = new Node(new Vec2(0, 0), new Vec2(15, 15), NodeType.Area);
            areaNode.AddRightClickEvent(ShowEditorGUI);
            areaNode.AddLeftClickEvent(AddNodeArea);
            areaNode.AddRightClickEvent(RemoveNode);

            areaNode.Group = curAreaGroup;

            nodes.Add(areaNode);
        }

        private void RemoveNode(Entity sender)
        {
            sender.EntityEnabled = false;
            nodes.Remove((Node)sender);
        }

        #endregion

        private void SelectedMapEvent(Entity sender)
        {
            curMap = sender.GetComponent<Sprite>().TexturePath;
        }

        private void ShowEditorGUI(Entity sender)
        {
            SetEntityGroup("EditorGUI", true);
        }

        private void HideEditorGUI(Entity sender)
        {
            SetEntityGroup("EditorGUI", false);
        }

        private void LoadMainMenu(Entity sender)
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
}
