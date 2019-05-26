using BrokenEngine;
using BrokenEngine.Graphics;
using BrokenEngine.Utils;

namespace Test
{
    class Program : Core
    {

        protected override void OnStart()
        {
            SetWindowSize(false, 800, 600);

            TextureManager.Instance.LoadTexture("Duck", new Texture("..//..//Img/duck.png"));
            TextureManager.Instance.LoadFont("defaultFont", new Font("..//..//Img/Bebas.ttf"));

            qualla b = new qualla();
            quadi a = new quadi();
            But c = new But();

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
