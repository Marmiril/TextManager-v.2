using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.Functions
{
    internal static class FileHelper
    {
        public static bool EnsureFileExists(string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                Console.WriteLine("El archivo no existe");
                return false;
            }
            return true;
        }
    }
}
