using BrokenEngine.Components;
using BrokenEngine.Graphics;
using BrokenEngine.Maths;
using System.Collections.Generic;
using Tower_Defense.Uitls;

namespace Tower_Defense.Prefabs
{
    public class Map : Entity
    {
        private HoverCollisionComponent.CollisionFunc OnHoverEnterDel = null;
        private HoverCollisionComponent.CollisionFunc OnHoverExitDel  = null;
        private ClickComponent.ClickFunction OnLeftClickDel           = null;

        public Map(string textureName, Vec2 pos)
        {
            // Add Components
            AddComponent(new Sprite(textureName, new Vec2(800, 600), Color.White));
            AddComponent(new HoverCollisionComponent(new Vec2(800, 600), OnHoverEnter, OnHoverExit));
            AddComponent(new ClickComponent(ClickMethod.SingleClick, OnLeftClick));

            SetPosition(pos);
            SetScale(new Vec2(0.1f, 0.1f));

            OnHoverEnterDel     = HoverEnterScale;
            OnHoverExitDel      = HoverExitScale;
            OnLeftClickDel      = LoadEditorMap;
        }

        /// <summary>
        /// Adds a click event to the map
        /// </summary>
        /// <param name="func"></param>
        public void AddClickEvent(ClickComponent.ClickFunction func)
        {
            OnLeftClickDel = func + OnLeftClickDel;
        }

        /// <summary>
        /// Loads the map
        /// </summary>
        public void LoadEditorMap(Entity sender)
        {
            SetPosition(new Vec2(400, 300));
            SetScale(new Vec2(1.0f, 1.0f));

            OnHoverEnterDel = null;
            OnHoverExitDel  = null;
            OnLeftClickDel  = null;

            Tag = "Map";

            EntityEnabled = true;
        }

        #region Events

        private void OnHoverEnter()
        {
            OnHoverEnterDel?.Invoke();
        }

        private void OnHoverExit()
        {
            OnHoverExitDel?.Invoke();
        }

        private void OnLeftClick(Entity sender)
        {
            OnLeftClickDel?.Invoke(sender);
        }


        private void HoverEnterScale()
        {
            SetScale(new Vec2(0.12f, 0.12f));
        }

        private void HoverExitScale()
        {
            SetScale(new Vec2(0.1f, 0.1f));
        }

        #endregion

        protected override void Start()
        {
            
        }

        protected override void Update()
        {
            
        }

        /// <summary>
        /// Save a map
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="totalPathGroups"></param>
        /// <param name="totalAreaGroups"></param>
        public static void SaveData(List<Node> nodes, int totalPathGroups, int totalAreaGroups, string curMapName)
        {
            // Sort after type
            List<Node> tmppaths = new List<Node>();
            List<Node> tmpareas = new List<Node>();

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Type == NodeType.Path)
                    tmppaths.Add(nodes[i]);

                if (nodes[i].Type == NodeType.Area)
                    tmpareas.Add(nodes[i]);
            }

            // Sort after groups
            string[] pathData = new string[totalPathGroups];
            string[] areaData = new string[totalAreaGroups];

            for (int i = 0; i < tmppaths.Count; i++)
            {
                Node curNode = tmppaths[i];

                pathData[curNode.Group - 1] += curNode.Postion.X + "," + curNode.Postion.Y + "|";
            }

            for (int i = 0; i < tmpareas.Count; i++)
            {
                Node curNode = tmpareas[i];

                areaData[curNode.Group - 1] += curNode.Postion.X + "," + curNode.Postion.Y + "|";
            }


            // create file data
            string finalData = "Map{\n" + curMapName + "\n}\n";

            finalData += "Path{\n";

            for (int i = 0; i < pathData.Length; i++)
            {
                finalData += pathData[i] + "\n";
            }
            finalData += "}\nArea{\n";

            for (int i = 0; i < areaData.Length; i++)
            {
                finalData += areaData[i] + "\n";
            }
            finalData += "}";

            string[] tmpname = curMapName.Split('/');
            tmpname = tmpname[tmpname.Length - 1].Split('\\');
            tmpname = tmpname[tmpname.Length - 1].Split('.');
            

            FileReader.WriteToFile("..//..//Maps/" + tmpname[0] + ".mpd", finalData);
        }
    }
}
