using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.Functions
{
    internal static class FileAppender
    {
        public static void AppenderFile(string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                Console.WriteLine("Archivo no encontrado.Seleccione otra opción o revise el listado.");
                return;
            }

            Console.WriteLine("'END' para salir y guardar.");
            Console.WriteLine("'CANCEL' - Cancelar operación.");
            Console.WriteLine("Modo edición. Escriba su texto:");


            var lines = new List<string>();

            while (true)
            {
                string? line = Console.ReadLine();

                if (line == null) break;

                if(line == "CANCEL")
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
                Console.WriteLine("No se escribió nada, ergo, el archivo no ha sido modificado.");
                return;
            }

            try
            {
                File.AppendAllText(fullPath, Environment.NewLine + content, Encoding.UTF8);
                Console.WriteLine("Texto añadido correctamente al archivo.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar el archivo: {ex.Message}");
            }
        }
    }
}
