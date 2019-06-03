using BrokenEngine.Graphics;
using BrokenEngine.Components;
using BrokenEngine.Maths;
using System.Collections.Generic;
using Tower_Defense.Uitls;

namespace Tower_Defense.Prefabs
{
    public class Map : Entity
    {
        private int mapCount;

        public Map(string texture, Vec2 pos, Vec2 size, int mapCount)
        {
            AddComponent(new Sprite(texture, size, Color.White));

            SetPosition(pos);

            Node.ClearNodes();

            this.mapCount = mapCount;

            LoadData();
        }

        /// <summary>
        /// Saves the data to the file
        /// </summary>
        public void SaveData()
        {
            MapData.SaveMapData("Map" + mapCount, Node.GetPathNodes(), Node.GetAreaNodes());
        }

        public void LoadData()
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
