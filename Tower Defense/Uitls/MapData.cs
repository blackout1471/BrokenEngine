using BrokenEngine.Components;
using BrokenEngine.Utils;
using System.Collections.Generic;
using System.IO;

namespace Tower_Defense.Uitls
{
    public static class MapData
    {
        private static string mapsDataFolder = "..//..//Maps/";

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
    }
}
