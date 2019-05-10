using OpenGL;

namespace BrokenEngine.Graphics
{
    class Tao
    {
        #region Properties

        public static int LayerWidth { get; }
        public static int LayerHeight { get; }
        public static int LayerDepth { get; }

        public int CurDepth { get; }

        #endregion

        #region Variables
        private static int layerWidth;
        private static int layerHeight;
        private static int layerDepth;

        private int curDepth;

        private int id;
        private int slot;

        #endregion

        #region Methods

        public Tao(int slot=0) { }

        public void Upload(Texture texture) { throw new System.NotImplementedException(); }
        public void Bind() { throw new System.NotImplementedException(); }
        public void Unbind() { throw new System.NotImplementedException(); }

        #endregion
    }
}
