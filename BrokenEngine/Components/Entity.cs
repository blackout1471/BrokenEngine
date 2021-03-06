﻿using BrokenEngine.Maths;
using BrokenEngine.Utils;
using System.Collections.Generic;

namespace BrokenEngine.Components
{
    public abstract class Entity
    {
        #region Properties

        /// <summary>
        /// The name of the entity
        /// </summary>
        public string EntityName { internal get { return name; } set { name = value; } }

        /// <summary>
        /// Get or set the tag which can be grouped
        /// </summary>
        public string Tag { get { return tag; } set { tag = value; } }

        /// <summary>
        /// Get the position of the entity can only be read
        /// </summary>
        public Vec2 Postion { get => CalculateTranslation(); }

        /// <summary>
        /// Whether the entity is enabled or not
        /// </summary>
        public bool EntityEnabled { get { return isEnabled; } set { isEnabled = value; } }

        /// <summary>
        /// Get the model view matrix for the entity
        /// </summary>
        internal Matrix4f ModelView { get { return CalculateModelView(); } }

        internal string Name { get => name; set => name = value; }

        #endregion

        #region Variables

        private string name = "Entity";
        private string tag = "Entity";
        private bool isEnabled = true;
        internal List<BaseComponent> components = new List<BaseComponent>();
        private List<float> rotations = new List<float>();
        private List<Vec2> positions = new List<Vec2>();
        private List<Vec2> scales = new List<Vec2>();

        #endregion

        protected Entity()
        {
            EntityManager.Instance.AddEntity(this);
            SetPosition(new Vec2(0, 0));
            SetRotation(0);
            SetScale(new Vec2(1f, 1f));
        }

        /// <summary>
        /// The method which will be called at the start of the program
        /// </summary>
        protected internal abstract void Start();

        /// <summary>
        /// The method which will be called everyframe
        /// </summary>
        protected internal abstract void Update();

        #region Transform methods

        /// <summary>
        /// Translate the entity in a direction
        /// </summary>
        /// <param name="translationsVector"></param>
        protected void Translate(Vec2 translationsVector)
        {
            positions.Add(translationsVector);
        }

        /// <summary>
        /// Scale the entity in a vector 
        /// </summary>
        /// <param name="scaleVector"></param>
        protected void Scale(Vec2 scaleVector)
        {
            scales.Add(scaleVector);
        }

        /// <summary>
        /// Rotate the entity from a degree
        /// </summary>
        /// <param name="degrees"></param>
        protected void Rotate(float degrees)
        {
            rotations.Add(degrees);
        }

        /// <summary>
        /// Sets the position for an entity
        /// </summary>
        /// <param name="position"></param>
        protected void SetPosition(Vec2 position)
        {
            positions.Clear();
            positions.Add(position);
        }

        /// <summary>
        /// Sets the scale for the entity
        /// </summary>
        /// <param name="position"></param>
        protected void SetScale(Vec2 Scale)
        {
            scales.Clear();
            scales.Add(Scale);
        }

        /// <summary>
        /// Sets the rotations for the entity
        /// </summary>
        /// <param name="degree"></param>
        protected void SetRotation(float degree)
        {
            rotations.Clear();
            rotations.Add(degree);
        }


        /// <summary>
        /// Calculates the total translation that has to be made
        /// </summary>
        /// <returns></returns>
        private Vec2 CalculateTranslation()
        {
            Vec2 trans = new Vec2(0, 0);

            for (int i = 0; i < positions.Count; i++)
            {
                trans += positions[i];
            }

            return trans;
        }

        /// <summary>
        /// Calculates the total scale for the entity
        /// </summary>
        /// <returns></returns>
        private Vec2 CalculateScale()
        {
            Vec2 scale = new Vec2(0, 0);

            for (int i = 0; i < scales.Count; i++)
            {
                scale += scales[i];
            }

            return scale;
        }

        /// <summary>
        /// Calculates the total rotation for the entity
        /// </summary>
        /// <returns></returns>
        private float CalculateRotation()
        {
            float degrees = 0;

            for (int i = 0; i < rotations.Count; i++)
            {
                degrees += rotations[i];
            }

            return degrees;
        }

        /// <summary>
        /// Calculates the model view for the entity
        /// </summary>
        /// <returns></returns>
        private Matrix4f CalculateModelView()
        {
            return Matrix4f.Scale(CalculateScale()) * Matrix4f.RotateZ(CalculateRotation()) * Matrix4f.Translate(CalculateTranslation());
        }

        #endregion

        #region Component Methods

        /// <summary>
        /// Adds a component to the entity
        /// </summary>
        /// <param name="component"></param>
        protected virtual void AddComponent(BaseComponent component)
        {
            if (component.GetType() == typeof(Renderable) || component.GetType().IsSubclassOf(typeof(Renderable)))
            {
                if (GetComponent<Renderable>() != null)
                {
                    Debug.Log(typeof(Renderable) + " Can't add more than one renderable", Debug.DebugLayer.Entity, Debug.DebugLevel.Warning);
                    return;
                }
            }

            component.Entity = this;
            components.Add(component);
            component.RequireComponents();

            Debug.Log("Added " + component.GetType(), Debug.DebugLayer.Entity, Debug.DebugLevel.Information);
        }

        /// <summary>
        /// Get the component from a entity
        /// if name is given it will look for name
        /// or else it will look for type
        /// </summary>
        /// <typeparam name="CompType">the component type</typeparam>
        /// <param name="compName">the components name</param>
        /// <returns>the component on the entity</returns>
        public CompType GetComponent<CompType>(string compName = null) where CompType : BaseComponent
        {
            foreach (var comp in components)
            {
                System.Type type = comp.GetType();

                if (name != null)
                    if (name == comp.Name && (type == typeof(CompType) || type.IsSubclassOf(typeof(CompType))))
                        return (CompType)comp;

                if (type == typeof(CompType) || type.IsSubclassOf(typeof(CompType)))
                    return (CompType)comp;

            }

            return null;
        }

        /// <summary>
        /// Gets a list of components from the entity
        /// if name is given it will look for name
        /// or else it will look for type
        /// </summary>
        /// <typeparam name="CompType">the component type</typeparam>
        /// <param name="compName">the components name</param>
        /// <returns>a list of components</returns>
        public CompType[] GetComponents<CompType>(string compName = null) where CompType : BaseComponent
        {
            List<CompType> comps = new List<CompType>();

            foreach (var comp in components)
            {
                System.Type type = comp.GetType();

                if (type == typeof(CompType) || type.IsSubclassOf(typeof(CompType)))
                    comps.Add((CompType)comp);

            }

            return comps.ToArray();
        }

        #endregion

    }
}
