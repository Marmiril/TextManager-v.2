using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TextManager.Functions
{
    internal static class FileSearcher
    {
        public static void SearchInFile(string fullPath)
        {
            if (!FileHelper.EnsureFileExists(fullPath)) return;

            Console.WriteLine("Indique la palabra a buscar en el texto (o escriba CANCEL para salir): ");
            string? term = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(term))
            {
                Console.WriteLine("No ha indicado ninguna palabra. Inténtelo de nuevo: ");
            } 
            
            if(term.Equals("CANCEL", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            string[] lines = File.ReadAllLines(fullPath, Encoding.UTF8);

            int totalMatches = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                int hits = CountOccurrences(lines[i], term, ignoreCase: true);

                if (hits > 0)
                {
                    totalMatches += hits;
                   // Console.WriteLine($"Línea {i + 1}: {lines[i]}");
                }
            }

            if (totalMatches == 0)
            {
                Console.WriteLine($"'{term}'No se han encontrado coincidencias en el texto.");
            }

            else Console.WriteLine($"Coincidencias totales: {totalMatches}");
        }

        public static int CountOccurrences(string text, string pattern, bool ignoreCase)
        {
            if (string.IsNullOrEmpty(pattern)) return 0;

            var comparison = ignoreCase
                ? StringComparison.OrdinalIgnoreCase
                :StringComparison.Ordinal;

            int count = 0;
            int start = 0;


            while (true)
            {
                int idx = text.IndexOf(pattern, start, comparison);

                if (idx < 0) break;
                count++;
                start = idx + pattern.Length;  // Avanza tras la coincidencia.                  
            }
            Console.Clear();
            return count;
        }
    }
}
