using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.Functions
{
    internal static class FileLetterFrequency
    {
        public static void CountLetter(string fullPath)
        {
            if (!FileHelper.EnsureFileExists(fullPath)) return;

            string? input = string.Empty;

            

            while (true)
            {
                Console.WriteLine("Indique qué letra quiere averiguar el número de veces que se repite (CANCEL para salir):");

                input = Console.ReadLine().Trim();

                if (input == "CANCEL")
                {
                    Console.WriteLine("Operación cancelada.");
                }
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Entrada vacía. Inténtelo de nuevo: ");
                    continue;
                }

                break;
            }

            char target = input[0];

            string content = File.ReadAllText(fullPath);

            int count = 0;

            foreach(char c in content)
            {
                if(char.ToUpperInvariant(c) == char.ToUpperInvariant(target))
                {
                    count++;
                }
            }

            Console.WriteLine($"La letra '{target}' aparece {count} veces en el texto {Path.GetFileName(fullPath)}");
        }        
    }
}
