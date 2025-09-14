using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextManager.Functions
{
    internal static class FileReplacer
    {
        public static void ReplaceWord(string fullPath)
        {
            if (!FileHelper.EnsureFileExists(fullPath)) return;

            string? target = null; // Palabra que se reemplaza.
            string? replace = null; // Palabra nueva.
            string content = File.ReadAllText(fullPath);
            var matches = Regex.Matches(content, @"\w+");
            string[] words = matches.Cast<Match>().Select(m => m.Value).ToArray();

            while (true)
            {
                Console.WriteLine("Indique la palabra que desea reemplazar (o escriba CANCEL para salir):");
                target = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(target))
                {
                    Console.WriteLine("No se ha indicado ninguna palabra. Inténtelo de nuevo: ");
                    continue;
                }
                if (target.Equals("CANCEL", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Operación cancelada");
                    return;
                }
                if (!words.Contains(target, StringComparer.OrdinalIgnoreCase))
                {
                    Console.WriteLine("La palabra buscada no se encuentra en el texto.");
                    continue;
                }

                break;             
            }
            
            while (true)
            {
                Console.WriteLine($"Indique la palabra que reemplazará a {target}.(Escriba 'CANCEL' para salir): ");
                replace = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(replace))
                {
                    Console.WriteLine("No se ha indicado ninguna palabra. Inténtelo de nuevo: ");
                    continue;
                }

                if(replace.Equals("CANCEL", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Operación cancelada.");
                    return;
                }
                break;
            }

            string[] updatedArray = words
                .Select(w => string.Equals(w, target, StringComparison.OrdinalIgnoreCase) ? replace : w)
                .ToArray();
            string updated = string.Join(" ", updatedArray);


            Console.WriteLine("================================================================================ ");
            Console.WriteLine("============================== TEXTO MODIFICADO ================================ ");
            Console.WriteLine("================================================================================ ");
            Console.WriteLine(updated);

            SaveHelper.AskSave(fullPath, updated);
            
            
        }
    }
}
 