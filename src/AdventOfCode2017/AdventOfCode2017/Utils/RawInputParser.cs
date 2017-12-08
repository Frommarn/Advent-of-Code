using System.IO;

namespace AdventOfCode2017.Utils
{
    public static class RawInputParser
    {
        /// <summary>
        /// Reads the raw input from file.
        /// </summary>
        /// <returns></returns>
        public static string[] ReadRawInputFromFile(string day, string fileName)
        {
            string fileNamePath = Directory.GetCurrentDirectory() + "\\Day" + day + "\\" + fileName;
            if (File.Exists(fileNamePath) == false)
            {
                throw new FileNotFoundException("Could not find the file!", fileNamePath);
            }

            return File.ReadAllLines(fileNamePath);
        }
    }
}
