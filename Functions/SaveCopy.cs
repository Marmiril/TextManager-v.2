using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.Functions
{
    internal static class FileCopier
    {
        public static void SaveCopy(string fullPath)
        {
            if (!FileHelper.EnsureFileExists(fullPath)) return;

            string destPath = string.Empty;

            while (true)
            {
                Console.WriteLine("Indique el nombre del archivo de copia (CANCEL PARA SALIR):");

                string? name = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Îndique un nombre para el archivo. Inténtelo de nuevo:");
                    continue;
                }

                if (int.TryParse(name, out _))
                {
                    Console.WriteLine("Títulos únicamente numéricos excluidos.");
                    continue;
                }

                if (name == "CANCEL")
                {
                    Console.WriteLine("Operación cancelada.");
                    return;
                }

                destPath = Storage.PathFor(name);

                if (File.Exists(destPath))
                {
                    Console.WriteLine($"Ya existe un archivo con el nombre de {destPath}. Intente con otro nombre: ");
                    continue;
                }
                break;
            }

            try
            {
                string content = File.ReadAllText(fullPath, Encoding.UTF8);
                File.WriteAllText(destPath, content, Encoding.UTF8);
                Console.WriteLine($"Copia guardada como '{Path.GetFileName(destPath)}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el archivo: {ex.Message}");
            }


        }

    }
}
