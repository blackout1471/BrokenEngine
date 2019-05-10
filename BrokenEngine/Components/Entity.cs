using BrokenEngine.Maths;
using System.Collections.Generic;

namespace BrokenEngine.Components
{
    public abstract class Entity
    {
        #region Variables

        private string name;
        private bool isEnabled;
        private List<BaseComponent> components;
        private List<float> rotations;
        private List<Vec2> positions;
        private List<Vec2> scales;

        #endregion

        protected Entity() { }

        protected void Translate(Vec2 translationsVector) { throw new System.NotImplementedException(); }
        protected void Scale(Vec2 scaleVector) { throw new System.NotImplementedException(); }
        protected void Rotate(float degrees) { throw new System.NotImplementedException(); }

        private Vec2 CalculateTranslation() { throw new System.NotImplementedException(); }
        private Vec2 CalculateScale() { throw new System.NotImplementedException(); }
        private Vec2 CalculateRotation() { throw new System.NotImplementedException();}
        private Matrix4f CalculateModelView() { throw new System.NotImplementedException(); }

        protected void AddComponent(BaseComponent component) { throw new System.NotImplementedException(); }
        public CompType GetComponent<CompType>(string compName = null) where CompType : BaseComponent { throw new System.NotImplementedException(); }
        public CompType[] GetComponents<CompType>(string compName = null) where CompType : BaseComponent { throw new System.NotImplementedException(); }

    }
}
