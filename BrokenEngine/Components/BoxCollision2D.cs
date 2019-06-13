using BrokenEngine.Maths;

namespace BrokenEngine.Components
{
    public class BoxCollision2D : BaseComponent
    {
        #region Properties
        internal Entity CollisionEntity { get => collisionEntity; } 
        internal CollisionFunc CollisionFunction { get => collisionFunc; }
        internal Vec2 Size { get => size; }
        #endregion

        /// <summary>
        /// The delegate for when colliding with object
        /// </summary>
        public delegate void CollisionFunc(Entity sender, Entity colObject);

        private CollisionFunc collisionFunc = null;
        private Entity collisionEntity;
        private Vec2 size = null;

        /// <summary>
        /// A collision component
        /// </summary>
        /// <param name="entityName">The object to check collision with</param>
        /// <param name="size">the size of the bounding box</param>
        /// <param name="function">The function to call if collision is made</param>
        public BoxCollision2D(string entityName, Vec2 size, CollisionFunc function)
        {
            this.size = size / 2;

            collisionEntity = EntityManager.Instance.GetEntity(entityName);
            collisionFunc = function;
        }

        public BoxCollision2D(Entity colEntity, Vec2 size, CollisionFunc func)
        {
            this.size = size / 2;
            collisionEntity = colEntity;
            collisionFunc = func;
        }

        /// <summary>
        /// Create the box collision without functionality
        /// </summary>
        /// <param name="size"></param>
        public BoxCollision2D(Vec2 size)
        {
            this.size = size / 2;
        }

        public void ChangeCollisionEntity(Entity entity)
        {
            collisionEntity = entity;
        }

    }
}
