using BrokenEngine.Utils;
using System.IO;

namespace Tower_Defense.Uitls
{
    public static class FileReader
    {
        public static string ReadFile(string path)
        {
            string rtn = "";

            try
            {
                 rtn = File.ReadAllText(path);
            }
            catch(IOException e)
            {
                Debug.Log("Could not read file " + path + " " + e.Message, Debug.DebugLayer.Game, Debug.DebugLevel.Error);
            }

            return rtn;
        }

        public static void WriteToFile(string path, string data)
        {
            try
            {
                File.WriteAllText(path, data);
            }
            catch(IOException e)
            {
                Debug.Log("Could not write to file " + path + " " + e.Message, Debug.DebugLayer.Game, Debug.DebugLevel.Error);
            }
        }
    }
}
