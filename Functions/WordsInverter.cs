using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.Functions
{
    internal static class FileWordsInverter
    {
        public static void WordsInverter(string fullPath)
        {
            if (!FileHelper.EnsureFileExists(fullPath)) return;

            string content = File.ReadAllText(fullPath);
            string[] words = content.Split(new[] { ' ', '\n', '\t', '\r' },
            StringSplitOptions.RemoveEmptyEntries);
            string[] inverted = words.Reverse().ToArray();
            string invertedText = string.Join(" ", inverted);

            Console.WriteLine("================================================================================ ");
            Console.WriteLine("============================== TEXTO MODIFICADO ================================ ");
            Console.WriteLine("================================================================================ ");
            Console.WriteLine(invertedText);

            SaveHelper.AskSave(fullPath, invertedText);
           
            
        }
    }
}
