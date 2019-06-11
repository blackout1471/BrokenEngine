using BrokenEngine.Maths;
using BrokenEngine.Components;
using BrokenEngine.Graphics;
using System.IO;

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
        public static string[] GetMapFiles()
        {
            string[] files = Directory.GetFiles(MapFolder, "*.mpd");

            return files;
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


        #endregion

        public Map(string textureName)
        {
            
        }

        protected override void Start()
        {

        }

        protected override void Update()
        {

        }
    }
}
