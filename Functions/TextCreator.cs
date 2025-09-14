using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextManager.Functions
{
    public static class FileTextWrite
    {
        public static void TextCreator()
        {
            string? input;
            string fullPath = null;// Storage.PathFor(input);

            while (true)
            {
                Console.WriteLine("Indique el nombre del archivo (ESC para salir):");

                ConsoleKeyInfo key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Operación cancelada.");
                    return;
                }

                input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Entrada vacía. Inténtelo de nuevo."); continue;
                }
                if (int.TryParse(input, out _))
                {
                    Console.WriteLine("Títulos únicamente numéricos excluidos. Inténtelo de nuevo:"); continue;
                }

                fullPath = Storage.PathFor(input);

                if (File.Exists(fullPath))
                {
                    Console.WriteLine("El título ya existe. Seleccione otro diferente: "); continue;
                }

                break;
            }

            if (fullPath != null)
            {

                Console.WriteLine("================================================================================ ");
                Console.WriteLine("           Escriba el contenido del archivo (Pulse ESC para terminar):           ");
                Console.WriteLine("================================================================================ ");

                var sb = new StringBuilder();

                while (true)
                {
                    var key = Console.ReadKey(intercept: true);

                    if (key.Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                    else if (key.Key == ConsoleKey.Enter)
                    {
                        sb.AppendLine();
                        Console.WriteLine();
                    }

                    else if (key.Key == ConsoleKey.Backspace)
                    {
                        if (sb.Length > 0)
                        {
                            sb.Length--;
                            //Borrado visual del último caracter metido por consola.
                            Console.Write("\b \b");
                        }
                    }

                    else
                    {
                        // Esto igonra teclas de control sin caracter.
                        if (!char.IsControl(key.KeyChar))
                        {
                            sb.Append(key.KeyChar);
                            Console.Write(key.KeyChar);
                        }
                    }
                }

                string content = sb.ToString();

                var lines = new List<string>();

                try
                {
                    SaveHelper.AskSave(fullPath, content);
                    Console.WriteLine("Archivo guardado correctamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al guardar el archivo:{ex:Messagge}.");
                }

            }
        }
    }
}
