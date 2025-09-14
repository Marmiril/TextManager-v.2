using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.Functions
{
    internal static class FileTextInverter
    {
        public static void TextInverter(string fullPath)
        {
            if (!FileHelper.EnsureFileExists(fullPath)) return;

            string content = File.ReadAllText(fullPath);

            char[] letters = content.ToCharArray();
            Array.Reverse(letters);                     

            string invertedContent = new string(letters);

            Console.WriteLine("================================================================================ ");
            Console.WriteLine("============================== TEXTO MODIFICADO ================================ ");
            Console.WriteLine("================================================================================ ");
            Console.WriteLine(invertedContent);

            SaveHelper.AskSave(fullPath, invertedContent);                    

        }
    }
}
