using System;
using BrokenEngine.Maths;
using BrokenEngine.Components;
using BrokenEngine.Graphics;
using Tower_Defense.Prefabs;
using BrokenEngine.Utils;

namespace Tower_Defense.Scenes
{
    public class NewMap : Scene
    {
        private Vec2 buttonSize = new Vec2(75, 30);
        private Color buttonTextCol = Color.Black;
        private Color buttonBgCol = new Color(255, 205, 180);

        private Map curMap;

        public NewMap() : base("NewMap")
        {

        }

        protected internal override void OnLoad()
        {
            throw new NotImplementedException();
        }

        protected internal override void OnLoad(object obj)
        {

            #region Map
            curMap = new Map(obj.ToString());

            #endregion

            #region HUD

            GUI.Button addPathGroup = new GUI.Button(new Vec2(50, 25), buttonSize, buttonBgCol, "Add Path", buttonTextCol);
            GUI.Button addAreaGroup = new GUI.Button(new Vec2(150, 25), buttonSize, buttonBgCol, "Add Area", buttonTextCol);

            GUI.Button back = new GUI.Button(new Vec2(650, 25), buttonSize, buttonBgCol, "Back", buttonTextCol);
            GUI.Button save = new GUI.Button(new Vec2(750, 25), buttonSize, buttonBgCol, "Save", buttonTextCol);

            // SET Del
            addPathGroup.AddClickEvent(AddPathNode);
            addAreaGroup.AddClickEvent(AddAreaNode);
            back.AddClickEvent(LoadMainMenu);
            save.AddClickEvent(SaveMap);


            // Set Tags
            addAreaGroup.Tag = "EditorHud";
            addPathGroup.Tag = "EditorHud";
            back.Tag = "EditorHud";
            save.Tag = "EditorHud";



            #endregion
        }

        private void SaveMap(Entity sender)
        {
            curMap.Save();
        }

        private void LoadMainMenu(Entity sender)
        {
            SceneManager.LoadScene("MainMenu");
        }

        private void AddPathNode(Entity sender)
        {
            Node curNode = curMap.AddPathNode(new Vec2(400, 300));
            curNode.FollowMouse = true;

            // Check if groups should increase
            Type objType = sender.GetType();
            if (objType == typeof(GUI.Button))
            {
                curMap.CurPathGroup++;
                curNode.Group = curMap.CurPathGroup;
                Debug.Log("Increased the group");
            }

            if (objType == typeof(Node))
            {
                Node tmpNodeObj = (Node)sender;
                curNode.Group = tmpNodeObj.Group;
            }


            curNode.AddLeftClickEvent(AddPathNode);
            curNode.AddRightClickEvent(RemoveNode);
        }

        private void AddAreaNode(Entity sender)
        {
            Node curNode = curMap.AddAreaNode(new Vec2(400, 300));
            curNode.FollowMouse = true;

            // Check if groups should increase
            Type objType = sender.GetType();
            if (objType == typeof(GUI.Button))
            {
                curMap.CurAreaGroup++;
                curNode.Group = curMap.CurAreaGroup;
            }

            if (objType == typeof(Node))
            {
                Node tmpNodeObj = (Node)sender;
                curNode.Group = tmpNodeObj.Group;
            }

            curNode.AddLeftClickEvent(AddAreaNode);
            curNode.AddRightClickEvent(RemoveNode);
        }

        private void RemoveNode(Entity sender)
        {
            curMap.RemoveNode((Node)sender);
        }
    }
}
