using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.Functions
{
    internal static class FileDeleter
    {
        public static void DeleteFile(string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                Console.WriteLine("El archivo no existe. No se puede borrar la nada.");
                return;
            }

            Console.WriteLine($"Seguro que desea borrar el arhcivo '{Path.GetFileName(fullPath)}'?.");
            Console.WriteLine("S/N");

            string? answer = Console.ReadLine();

            if (answer?.Trim().ToUpper() == "S")
            {
                try
                {
                    File.Delete(fullPath);
                    Console.WriteLine($"El archivo '{Path.GetFileName(fullPath)}' ha sido borrado correctamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al borrar el archivo: {ex.Message}.");
                }
            }
            else
            {
                Console.WriteLine("Operación cancelada. El archivo no fue borrado.");
            }

        }
    }
}
