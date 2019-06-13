using BrokenEngine.Maths;
using BrokenEngine.Components;
using BrokenEngine.Graphics;
using BrokenEngine.Application;
using BrokenEngine.Utils;

namespace Tower_Defense.Prefabs
{
    public class Enemy : Entity
    {
        private Node[] paths;
        private int curPath;
        private readonly float speed = 50;
        private readonly Vec2 size = new Vec2(50, 50);
        private float timer = 0;


        public Enemy(Node[] path)
        {
            paths = path;
            curPath = 0;

            AddComponent(new Sprite("ErrorTexture", size, Color.White));
            AddComponent(new BoxCollision2D(paths[curPath], size/10, NodeCollision));

            SetPosition(paths[0].Postion);

            Debug.Log(paths[curPath].Postion + " : " + paths[curPath + 1].Postion);
        }

        protected override void Start()
        {
            
        }

        protected override void Update()
        {
            if (curPath == 0)
                return;

            Vec2 newPos = (paths[curPath].Postion - paths[curPath - 1].Postion) * Time.DeltaTime;
            Translate(newPos);
        }

        private void NodeCollision(Entity sender, Entity colObj)
        {
            if (curPath >= paths.Length-1)
                return;

            curPath++;
            GetComponent<BoxCollision2D>().ChangeCollisionEntity(paths[curPath]);

            Debug.Log("Hit Node");
        }
    }
}
