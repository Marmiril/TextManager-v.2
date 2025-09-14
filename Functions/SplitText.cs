using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.Functions
{
    internal static class FileSplitText
    {
        public static void SplitText(string fullPath)
        {
            if (!FileHelper.EnsureFileExists(fullPath)) return;

            Console.WriteLine("En cuántas partes desea dividir el fragmento: ");

            if(!int.TryParse(Console.ReadLine(), out int parts) || parts <= 0)
            {
                Console.WriteLine("Indique un número válido.");
                return;
            }

            string[] lines = File.ReadAllLines(fullPath, Encoding.UTF8);

            if (lines.Length == 0)
            {
                Console.WriteLine("El archivo está vacio.");
                return;
            }


            // Calcular cuántas líneas por fragmento.
            int chunkSize = (int)Math.Ceiling((double)lines.Length / parts);

            string baseName = Path.GetFileNameWithoutExtension(fullPath);
            string ext = Path.GetExtension(fullPath);
            string dir = Path.GetDirectoryName(fullPath) ?? Storage.DataRoot;

            int fileCount = 0;

            for(int i = 0; i < lines.Length; i += chunkSize)
            {
                string[] metrLines = lines.Skip(i).Take(chunkSize).ToArray();
                string dest = Path.Combine(dir, $"{baseName}_part{++fileCount}{ext}");

                File.WriteAllLines(dest, metrLines, Encoding.UTF8);

                Console.WriteLine($"Fragmento guardado en {Path.GetFileName(dest)}");
            }

            Console.WriteLine($"Archivo dividido en {fileCount} fragmentos.");
        }
    }
}
