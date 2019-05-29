using BrokenEngine.Graphics;
using BrokenEngine.Components;
using BrokenEngine.Utils;
using BrokenEngine.Application;
using BrokenEngine.Maths;

using Tower_Defense.GUI;
using System.Collections.Generic;
using Tower_Defense.Prefabs;
using Tower_Defense.Uitls;

namespace Tower_Defense
{
    public enum NodeType
    {
        None,
        PathNode,
        AreaNode
    };

    public class EditorManager
    {
        #region Properties
        public static EditorManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new EditorManager();

                return instance;
            }
        }
        private static EditorManager instance = null;

        #endregion

        private Map curMap;
        private List<Entity> pathNodes;
        private List<Entity> areaNodes;

        public EditorManager()
        {
            
        }

        public void Initialise()
        {
            Texture nodeTexture = new Texture("..//..//Assets/Img/PathNodeImg.png");
            Texture areaTexture = new Texture("..//..//Assets/Img/AreaNodeImg.png");

            TextureManager.Instance.LoadTexture("PathNodeTexture", nodeTexture);
            TextureManager.Instance.LoadTexture("AreaNodeTexture", areaTexture);

            curMap = new Map("ErrorTexture", "EditorMapUI");

            pathNodes = new List<Entity>();
            areaNodes = new List<Entity>();
        }

        public void LoadMap(string textureName)
        {
            curMap.GetComponent<Sprite>().ChangeSprite(textureName);

            for (int i = 0; i < pathNodes.Count; i++)
            {
                pathNodes[i].Tag += "Old";
            }

            for (int j = 0; j < areaNodes.Count; j++)
            {
                areaNodes[j].Tag += "Old";
            }

            pathNodes.Clear();
            areaNodes.Clear();
        }

        public void SaveMap()
        {
            MapData.SaveMapData("..//..//Assets/Img/Maps/TestMap.png", pathNodes.ToArray(), areaNodes.ToArray());
            UIManager.Instance.ShowMainMenu();
        }

        public void AddNode(NodeType type)
        {
            switch(type)
            {
                case NodeType.PathNode:
                    pathNodes.Add(new PathNode(new Vec2(0, 0)));
                    break;
                case NodeType.AreaNode:
                    areaNodes.Add(new AreaNode(new Vec2(0, 0)));
                    break;
            }
        }

        public void RemoveNode(NodeType type, Entity entity)
        {
            switch (type)
            {
                case NodeType.PathNode:
                    pathNodes.Remove(entity);
                    break;
                case NodeType.AreaNode:
                    areaNodes.Remove(entity);
                    break;
            }
        }


    }
}
