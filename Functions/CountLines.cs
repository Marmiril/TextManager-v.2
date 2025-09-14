using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.Functions
{
    internal static class FileLineCounter 
    {
        public static void CountLines(string fullPath)
        {
            if (!FileHelper.EnsureFileExists(fullPath)) return;

            string[] lines = File.ReadAllLines(fullPath);

            Console.WriteLine($"Archivo '{Path.GetFileName(fullPath)}'. Nº total de líneas: {lines.Length}.");

        }
    }
}
