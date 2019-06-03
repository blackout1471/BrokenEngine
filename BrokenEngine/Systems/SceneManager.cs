using System;
using System.Collections.Generic;

namespace BrokenEngine.Systems
{
    public class SceneManager
    {
        #region SingleTon
        public static SceneManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new SceneManager();

                return instance;
            }
        }

        private static SceneManager instance = null;

        #endregion

        private List<Scene> scenes = new List<Scene>();
        private Scene currentScene = null;

        public void AddScene(Scene scene)
        {
            scenes.Add(scene);
        } 

        public void RemoveScene(Scene scene)
        {
            scenes.Remove(scene);
        }

        public void LoadScene(string sceneName)
        {
            currentScene = GetScene(sceneName);

            currentScene.Load();
        }

        private Scene GetScene(string sceneName)
        {
            for (int i = 0; i < scenes.Count; i++)
            {
                if (scenes[i].SceneName == sceneName)
                    return scenes[i];
            }

            return null;
        }
    }
}
