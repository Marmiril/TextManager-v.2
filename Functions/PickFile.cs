using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.Functions
{
    internal static class FileSelector
    {
        public static string? PickFile()
        {
            string[] files = Directory.GetFiles(Storage.DataRoot);


            Console.WriteLine("============================== ARCHIVOS ==============================");
            if (files.Length == 0)
            {
                Console.WriteLine("La carpeta está vacía");
                return null;
            }

            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"{i + 1}:{Path.GetFileName(files[i])}.");
            }

            Console.WriteLine("============================== ******** ==============================");

            while (true)
            {
                Console.WriteLine("Seleccione el archivo o 0 para cancelar:");

                string? input = Console.ReadLine().Trim();

                if (input == "0")
                {
                    Console.WriteLine("Operación cancelada.");
                    return null;
                }
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Entrada vacía. Inténtelo de nuevo:");
                    continue;
                }
                if (int.TryParse(input, out int idx))
                {
                    if (idx >= 1 && idx <= files.Length)
                    {
                        return files[idx - 1];
                    }

                    Console.WriteLine("Opción fuera de rango. Inténtelo de nuevo: ");
                    continue;

                }
                else
                {
                    string candidate = Storage.PathFor(input);
                    if (File.Exists(candidate)) return candidate;
                }

                Console.WriteLine("Opción no válida.");
                continue;
            }

        }
    }
}
