using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace TextManager.Functions
{
    internal static class FileWriter
    {
        public static bool WriteFile(string fullPath)
        {
            if (File.Exists(fullPath))
            {
                Console.WriteLine("El archivo ya existe. Use otra opción para modificarlo o un nombre distinto.");
                return false;
            }

            Console.Clear();
            Console.WriteLine($" ==== Modo edición. Escriba su texto para {Path.GetFileName(fullPath)}. ====");
            Console.WriteLine("Escriba 'END' (solo) para terminar, o 'CANCEL' para cancelar.\n");

            var lines = new List<string>();

            while (true)
            {
                string? line = Console.ReadLine();
                if (line is null) break;                // fin inesperado (EOF).

                if (line.Trim() == "CANCEL")
                {
                    Console.WriteLine("Operación cancelada. No se creó el archivo.");
                    return false;
                }

                if (line.Trim() == "END") break;                 // finaliza la entrada.

                lines.Add(line);
            }

            string content = string.Join(Environment.NewLine, lines);

            if (string.IsNullOrWhiteSpace(content))
            {
                Console.WriteLine("No se escribió nada, ergo, no se creó archivo alguno.");
                return false;
            }

            try
            {
                File.WriteAllText(fullPath, content, Encoding.UTF8);
                Console.WriteLine("Archivo creado correctamente.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el archivo: {ex.Message}.");
                return false;
            }
        }
    }
}
