using BrokenEngine;
using BrokenEngine.Systems;
using BrokenEngine.Utils;
using System.Collections.Generic;

namespace Tower_Defense
{
    public static class SceneManager
    {
        private static List<Scene> scenes = new List<Scene>();
        private static Scene curScene = null;

        public static void AddScene(Scene scene)
        {
            scenes.Add(scene);
        }

        public static void RemoveScene(Scene scene)
        {
            scenes.Remove(scene);
        }

        private static Scene GetScene(string name)
        {
            for (int i = 0; i < scenes.Count; i++)
            {
                if (scenes[i].SceneName == name)
                    return scenes[i];
            }

            return null;
        }

        public static void LoadScene(string name)
        {
            SystemManager.Instance.ResetGPUBuffer();

            curScene = GetScene(name);
            curScene.OnLoad();

            Debug.Log("Loaded Scene " + name);
        }
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
    }
}
