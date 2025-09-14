using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.Functions
{
    internal static class FileLetterCounter
    {
        public static void CounteLetters(string fullPath)
        {
            if (!FileHelper.EnsureFileExists(fullPath)) return;

            string content = File.ReadAllText(fullPath);

            int count = content.Count(c => char.IsLetter(c));

            Console.WriteLine($"Número total de letras: {count}");          
        }
    }
}
