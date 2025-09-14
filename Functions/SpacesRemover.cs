using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextManager.Functions
{
    internal static class FileSpacesRemover
    {
        public static void SpacesRemover(string fullPath)
        {
            if (!FileHelper.EnsureFileExists(fullPath)) return;


            string content = File.ReadAllText(fullPath, Encoding.UTF8);

            string cleaned = Regex.Replace(content, @"[ \t]+", string.Empty);

            Console.WriteLine("================================================================================ ");
            Console.WriteLine("============================== TEXTO MODIFICADO ================================ ");
            Console.WriteLine("================================================================================ ");
            Console.WriteLine(cleaned);

            SaveHelper.AskSave(fullPath, cleaned);

        }
    }
}
