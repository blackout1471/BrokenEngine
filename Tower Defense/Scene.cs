using BrokenEngine;
using BrokenEngine.Components;
using BrokenEngine.Systems;
using BrokenEngine.Utils;
using System.Collections.Generic;

namespace Tower_Defense
{
    public static class SceneManager
    {
        private static List<Scene> scenes = new List<Scene>();
        private static Scene curScene = null;

        #region static methods
        /// <summary>
        /// Adds a scene to the list
        /// </summary>
        /// <param name="scene"></param>
        public static void AddScene(Scene scene)
        {
            scenes.Add(scene);
        }

        /// <summary>
        /// removes a scene from the list
        /// </summary>
        /// <param name="scene"></param>
        public static void RemoveScene(Scene scene)
        {
            scenes.Remove(scene);
        }

        /// <summary>
        /// Returns the scene from a name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static Scene GetScene(string name)
        {
            for (int i = 0; i < scenes.Count; i++)
            {
                if (scenes[i].SceneName == name)
                    return scenes[i];
            }

            return null;
        }

        /// <summary>
        /// Loads a scene from name
        /// </summary>
        /// <param name="name"></param>
        public static void LoadScene(string name)
        {
            SystemManager.Instance.ResetGPUBuffer();

            curScene = GetScene(name);
            curScene.OnLoad();

            Debug.Log("Loaded Scene " + name);
        }

        /// <summary>
        /// Loads a scene from name
        /// </summary>
        /// <param name="name"></param>
        public static void LoadScene(string name, object obj)
        {
            SystemManager.Instance.ResetGPUBuffer();

            curScene = GetScene(name);
            curScene.OnLoad(obj);

            Debug.Log("Loaded Scene " + name);
        }

        #endregion
    }


    public abstract class Scene
    {
        public string SceneName { get => sceneName; }
        private string sceneName;

        public Scene(string name)
        {
            sceneName = name;
        }

        protected internal abstract void OnLoad();

        protected internal abstract void OnLoad(object obj);

        /// <summary>
        /// Show a Entity group from their tag or hide
        /// </summary>
        /// <param name="groupTag"></param>
        protected void SetEntityGroup(string groupTag, bool show)
        {
            Entity[] entities = EntityManager.Instance.GetEntities();

            for (int i = 0; i < entities.Length; i++)
            {
                if (entities[i].Tag == groupTag)
                    entities[i].EntityEnabled = show;
            }
        }

        /// <summary>
        /// Shows a group of entities
        /// </summary>
        /// <param name="groupTag"></param>
        protected void ShowEntityGroup(string groupTag)
        {
            Entity[] entities = EntityManager.Instance.GetEntities();

            for (int i = 0; i < entities.Length; i++)
            {
                entities[i].EntityEnabled = false;

                if (entities[i].Tag == groupTag)
                    entities[i].EntityEnabled = true;
            }
        }
    }
}
