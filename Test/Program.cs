using BrokenEngine;
using BrokenEngine.Graphics;

namespace Test
{
    class Program : Core
    {

        protected override void OnStart()
        {
            SetWindowSize(false, 800, 600);

            TextureManager.Instance.LoadTexture("Duck", new Texture("..//..//Img/duck.png"));

            qualla b = new qualla();
            quadi a = new quadi();
        }

        protected override void OnUpdate()
        {

        }

        static void Main(string[] args)
        {
            new Program().RunEngine();
        }
    }
}
