using BrokenEngine.Maths;
using BrokenEngine.Components;
using BrokenEngine.Graphics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using BrokenEngine.Utils;
using Tower_Defense.Uitls;
using System.Text.RegularExpressions;

namespace Tower_Defense.Prefabs
{
    public class Map : Entity
    {
        #region Statics
        private static string MapFolder = "..//..//Maps/";

        /// <summary>
        /// Get all the map files in the folder
        /// </summary>
        /// <returns></returns>
        public static string[] GetMapFiles(bool getOnlyNames = false)
        {
            string[] files = Directory.GetFiles(MapFolder, "*.mpd");

            if (getOnlyNames)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    files[i] = files[i].Split('/').Last().Split('\\').Last().Split('.').First();
                }
            }

            return files;
        }

        /// <summary>
        /// Get only the map data from the file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string[] GetOnlyMapData(string mapName)
        {
            MatchCollection tmpData = GetMapData(mapName);

            foreach(Match match in tmpData)
            {
                if (match.Groups[1].Value == "Map")
                {
                    return match.Groups[2].Value.Split(',');
                }
            }

            return null;
        }

        /// <summary>
        /// Get all the map imgs in the map folder
        /// </summary>
        /// <returns></returns>
        public static string[] GetMapImgs()
        {
            string[] files = Directory.GetFiles(MapFolder, "*.png");

            return files;
        }

        /// <summary>
        /// Reads the file and finds the split pattern for the map
        /// </summary>
        /// <param name="mapName"></param>
        /// <returns></returns>
        private static MatchCollection GetMapData(string mapName)
        {
            // Create regex
            Regex rx = new Regex("(.*?){(.*?)}", RegexOptions.Multiline);

            string tmpData = FileReader.ReadFile(MapFolder + mapName + ".mpd");

            MatchCollection mc = rx.Matches(tmpData);

            return mc;
        }


        #endregion

        public int CurPathGroup { get => curPathGroup; set => curPathGroup = value; }
        public int CurAreaGroup { get => curAreaGroup; set => curAreaGroup = value; }

        private List<Node> nodes;
        private List<Enemy> enemies;
        private int curPathGroup, curAreaGroup;
        private string texturePath;
        private string mapName;
        private float roundTimer;

        /// <summary>
        /// Load a map from a texture
        /// </summary>
        /// <param name="textureName"></param>
        public Map(string textureName)
        {
            nodes = new List<Node>();
            enemies = new List<Enemy>();
            CurAreaGroup = 0;
            CurPathGroup = 0;
            roundTimer = 0;

            AddComponent(new Sprite(textureName, new Vec2(800, 600), Color.White));
            SetPosition(new Vec2(400, 300));

            texturePath = GetComponent<Sprite>().TexturePath;
            mapName = texturePath.Split('/').Last().Split('.').First();
        }

        /// <summary>
        /// Saves the map to a file with the name of the map
        /// </summary>
        public void Save()
        {
            // Collect data

            string mapData = "Map{" + ToString() + "}";
            string pathData = "Path{";
            string areaData = "Area{";

            for (int i = 0; i < nodes.Count; i++)
            {
                Node n = nodes[i];

                if (n.Type == NodeType.Path)
                    pathData += n.ToString() + "|";

                if (n.Type == NodeType.Area)
                    areaData += n.ToString() + "|";
            }

            pathData = pathData.Remove(pathData.Length - 1, 1);
            areaData = areaData.Remove(areaData.Length - 1, 1);

            pathData += "}";
            areaData += "}";

            string data = mapData + "\n" + pathData + "\n" + areaData;

            FileReader.WriteToFile(MapFolder + mapName + ".mpd", data);

            Debug.Log("Saved map data to " + MapFolder + mapName + ".mpd");
        }

        public void StartRound()
        {
            roundTimer = 0;

            enemies.Add(new Enemy(GetPathNodes()));
        }

        public void Load(string mapName)
        {
            // Get data
            MatchCollection mc = Map.GetMapData(mapName);

            foreach(Match match in mc)
            {
                // Get map data
                if (match.Groups[1].Value == "Map")
                {
                    string[] map = match.Groups[2].Value.Split(',');

                    texturePath = map[0];
                    this.mapName = map[1];
                }

                // Get nodes
                if (match.Groups[1].Value == "Path" || match.Groups[1].Value == "Area")
                {
                    NodeType curType = NodeType.Path;

                    if (match.Groups[1].Value == "Area")
                        curType = NodeType.Area;

                    string[] snodes = match.Groups[2].Value.Split('|');

                    // Create nodes
                    for (int i = 0; i < snodes.Length; i++)
                    {
                        string[] values = snodes[i].Split(',');

                        Vec2 pos = new Vec2(float.Parse(values[0]), float.Parse(values[1]));
                        int group = int.Parse(values[2]);

                        Node curNode = new Node(pos, curType);
                        curNode.Group = group;

                        nodes.Add(curNode);

                        // Set groups
                        if (curType == NodeType.Path)
                            curPathGroup = group;
                        else if (curType == NodeType.Area)
                            curAreaGroup = group;
                    }
                }

                // Change the texture
                Texture mapText = new Texture(texturePath);
                TextureManager.Instance.LoadTexture(texturePath, mapText);

                GetComponent<Sprite>().ChangeSprite(texturePath);
            }
        }

        private Node[] GetPathNodes()
        {
            List<Node> paths = new List<Node>();

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Type == NodeType.Path)
                    paths.Add(nodes[i]);
            }

            return paths.ToArray();
        }

        #region Nodes
        public Node AddPathNode(Vec2 pos)
        {
            Node newNode = new Node(pos, NodeType.Path);

            nodes.Add(newNode);

            return newNode;
        }

        public Node AddAreaNode(Vec2 pos)
        {
            Node newNode = new Node(pos, NodeType.Area);

            nodes.Add(newNode);

            return newNode;
        }

        public void RemoveNode(Node node)
        {
            nodes.Remove(node);
            node.EntityEnabled = false;
        }

        private void ClearNodes()
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].EntityEnabled = false;
            }

            nodes.Clear();
        }

        public void SetNodesVisibility(bool visible)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].EntityEnabled = visible;
            }
        }

        #endregion

        protected override void Start()
        {

        }

        protected override void Update()
        {

        }

        public override string ToString()
        {
            return texturePath + "," + mapName;
        }
    }
}
