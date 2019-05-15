using BrokenEngine;

namespace Test
{
    class Program : Core
    {
        quadi a = new quadi();
        qualla b = new qualla();

        protected override void OnStart()
        {

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
