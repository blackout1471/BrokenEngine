using BrokenEngine.Components;
using BrokenEngine.Utils;
using System.Collections.Generic;
using System.IO;
using Tower_Defense.Prefabs;

namespace Tower_Defense.Uitls
{
    public static class MapData
    {
        private static string mapsDataFolder = "..//..//Maps/";

        public struct MapDataStruct
        {
            public string MapTexture { get => mapTexture; }
            public Node[] PathNodes { get => pathNodes; }
            public Node[] AreaNodes { get => areaNodes; }

            private string mapTexture;
            private Node[] pathNodes;
            private Node[] areaNodes;

            public MapDataStruct(string mapTexture, Node[] pathNodes, Node[] areaNodes)
            {
                this.mapTexture = mapTexture;
                this.pathNodes = pathNodes;
                this.areaNodes = areaNodes;
            }
        }

        public static void SaveMapData(string mapPath, Entity[] pathNodes, Entity[] areaNodes)
        {
            string data = "";

            data += mapPath + "#";

            for (int i = 0; i < pathNodes.Length; i++)
            {
                data += pathNodes[i].Postion.X + "," + pathNodes[i].Postion.Y + "|";
            }

            data += "%";

            for (int i = 0; i < areaNodes.Length; i++)
            {
                data += areaNodes[i].Postion.X + "," + areaNodes[i].Postion.Y + "|";
            }

            string[] tmpSeps = mapPath.Split('/');
            tmpSeps = tmpSeps[tmpSeps.Length - 1].Split('.');

            string name = tmpSeps[0];

            File.WriteAllText(mapsDataFolder + name + ".mpd", data);
        }

        public static MapDataStruct LoadMapData(string fileName)
        {
            string data = File.ReadAllText(mapsDataFolder + fileName + ".mpd");

            string[] tmpdata = data.Split('#');
            string mapTexture = tmpdata[0];

            tmpdata = tmpdata[1].Split('%');

            string pathNodeLines = tmpdata[0];
            string areaNodeLines = tmpdata[1];

            Debug.Log(pathNodeLines + " " + areaNodeLines);

            return new MapDataStruct(mapTexture, null, null);
        }
    }
}
