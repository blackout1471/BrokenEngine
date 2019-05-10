using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace BrokenEngine.Utils
{
    public static class FileUtils
    {

        /// <summary>
        /// Reads a file and gives an string array back with all the lines
        /// each index is a new line
        /// </summary>
        /// <param name="path">The path to the file</param>
        /// <returns>The text in a string array</returns>
        public static string[] ReadFileAsString(string path)
        {
            StreamReader fs;
            List<string> lines = new List<string>();

            try
            {
                fs = new StreamReader(path);
            }
            catch (System.Exception e)
            {
                throw e;
            }

            string line = "";
            while ((line = fs.ReadLine()) != null)
            {
                lines.Add(line + "\n");
            }

            return lines.ToArray();
        }

        /// <summary>
        /// Reads a file as bytes and returns the information in a byte array
        /// </summary>
        /// <param name="path">the path to the file</param>
        /// <returns>The files information in a byte array</returns>
        public static byte[] ReadFileAsBytes(string path)
        {
            FileInfo fileinfo;

            try
            {
                fileinfo = new FileInfo(path);
            }
            catch (System.Exception e)
            {
                throw e;
            }

            byte[] data = new byte[fileinfo.Length];

            using (FileStream fs = fileinfo.OpenRead())
            {
                fs.Read(data, 0, data.Length);
            }

            fileinfo.Delete();

            return data;
        }

        public static Bitmap ReadFileAsImage(string path) { throw new System.NotImplementedException(); }

    }
}
