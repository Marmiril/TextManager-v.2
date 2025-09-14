using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextManager.Functions
{
    internal static class FileOverwriter
    {
        public static void OverwriteFile(string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                Console.WriteLine("El archivo no existe. Use otra opción.");
                return;
            }

            Console.WriteLine("Modo sobrescritura, se perderá el escrito anterior.");
            Console.WriteLine("Escriba 'END' (solo) para terminar, o 'CANCEL' para cancelar.");
            Console.WriteLine();

            var lines = new List<string>();

            while (true)
            {
                string? line = Console.ReadLine();

                if (line == null) break;

                if (line == "CANCEL")
                {
                    Console.WriteLine("Operación cancelada. No se modificó el archivo.");
                    return;
                }

                if (line == "END") break;

                lines.Add(line);
            }

            string content = string.Join(Environment.NewLine, lines);

            if (string.IsNullOrWhiteSpace(content))
            {
                Console.WriteLine("No se escribió nada. El archivo ha quedado vacío.");
                return;
            }

            try
            {
                File.WriteAllText(fullPath, content, Encoding.UTF8);
                Console.WriteLine("Archivo sobrescrito correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al sobrescribir el archivo: {ex.Message}");
            }
        }
    }
}
