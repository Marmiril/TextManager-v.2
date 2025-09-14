using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.Functions
{
    internal static class FileReader
    {
        public static void ReadFile(string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                Console.WriteLine("El archivo no existe.");
                return;
            }

            try
            {
                string content = File.ReadAllText(fullPath);
                Console.WriteLine("---- Contenido del archivo ----");
                Console.WriteLine(content);
                Console.WriteLine("---- Fin del archivo ----");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
            }
        }
    }
}
