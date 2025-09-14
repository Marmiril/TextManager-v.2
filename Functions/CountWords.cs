using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextManager.Functions
{
    internal static class FileWordCounter
    {
        public static void CountWords(string fullPath)
        {
            if (!FileHelper.EnsureFileExists(fullPath)) return; 

            string content = File.ReadAllText(fullPath);

            // Le pongo regex para leer a lo fácil.
            var matches = Regex.Matches(content, @"\w+");

            Console.WriteLine($"Número total de palabras: {matches.Count}");            
        }
    }
}
