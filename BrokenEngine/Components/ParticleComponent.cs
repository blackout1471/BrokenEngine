using BrokenEngine.Graphics;
using BrokenEngine.Maths;


namespace BrokenEngine.Components
{
    class ParticleComponent : InstancedRenderable
    {
        #region Properties
        internal bool CycledOnce    { get => cycledOnce; }
        public Vec2 Size            { get => size; }
        public Vec2 Direction       { get => direction; }
        public float Spread         { get => spread; }
        public float Speed          { get => speed; }
        public float TimeOfLife     { get => timeOfLife; }
        public Color Start          { get => start; }
        public Color End            { get => end; }
        public int Amount           { get => amount; }
        #endregion

        private bool cycledOnce;
        private Vec2 size;
        private Vec2 direction;
        private float spread;
        private float speed;
        private float timeOfLife;
        private Color start;
        private Color end;
        private int amount;

        public ParticleComponent(Vec2 size, Vec2 direction, float spread, float speed, float timeOfLife, int amount, Color start, Color end)
        {
            this.cycledOnce = false;
            this.size       = size;
            this.direction  = direction;
            this.spread     = spread;
            this.speed      = speed;
            this.timeOfLife = timeOfLife;
            this.start      = start;
            this.end        = end;
            this.amount     = amount;
        }
    }
}
