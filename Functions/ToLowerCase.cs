using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.Functions
{
    internal static class FileLowerCase
    {
        public static void ToLowerCase(string fullPath)
        {
            if (!FileHelper.EnsureFileExists(fullPath)) return;

            string content = File.ReadAllText(fullPath, Encoding.UTF8);
            string updated = content.ToLower();

            Console.WriteLine("================================================================================ ");
            Console.WriteLine("============================== TEXTO MODIFICADO ================================ ");
            Console.WriteLine("================================================================================ ");
            Console.WriteLine(updated);

            SaveHelper.AskSave(fullPath, updated);
        }
    }
}
