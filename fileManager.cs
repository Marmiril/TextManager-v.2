using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextManager.Functions;
using System.IO;

namespace TextManager
{
    internal class fileManager
    {
        private string[] _currentFiles = Array.Empty<string>();


        public void Run()
        {
            Storage.EnsureRoot();

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Carpeta de datos: {Storage.DataRoot}\n");

                Console.WriteLine("BIENVENIDO AL GESTOR DE TEXTOS.");
                Console.WriteLine("OPCIONES:\n");
                Console.WriteLine("1 - Escribir un nuevo texto.");
                Console.WriteLine("2 - Tratar un texto ya existente.");
                Console.WriteLine("ESC - Salir.");

                RefreshAndShowFiles();

                // ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                var key = Console.ReadKey(intercept: true).Key;

                if (key == ConsoleKey.Escape) return;

                switch (key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        FileTextWrite.TextCreator();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                    {
                            string? fullPath = PickExistingFile();
                            if (fullPath != null) ActionsMenu(fullPath);
                            break;
                    }

                    default:
                        Console.WriteLine("Opción inválida. Use1, 2 o ESC.");
                        Console.ReadKey();
                        break;

                }
            }
        }

        public void RefreshAndShowFiles()
        {
            _currentFiles = Directory.Exists(Storage.DataRoot)
                ? Directory.GetFiles(Storage.DataRoot)
                : Array.Empty<string>();

            Console.WriteLine();
            Console.WriteLine("==== Archivos en la carpeta ====\n");
            if (_currentFiles.Length == 0)
            {
                Console.WriteLine("Carpeta vacía.");
            }
            else
            {
                for (int i = 0; i < _currentFiles.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Path.GetFileName(_currentFiles[i])}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("=====================================\n");

        }

        /// <summary>
        /// Lista archivos, permite selecciona por índice, abrir por nombre, crear nuevo o salir.
        /// Devuelve la ruta completa seleccionada o null si el usuario sale.
        /// </summary>
        public string? PickExistingFile()
        {
            while (true)
            {

                Console.WriteLine();
                var files = Directory.Exists(Storage.DataRoot)
                    ? Directory.GetFiles(Storage.DataRoot)
                    : Array.Empty<string>();

                Console.WriteLine("==== ELIJA UN ARCHIVO PARA TRATAR ====");
                Console.WriteLine();
                if (files.Length == 0)
                {
                    Console.WriteLine("La carpeta está vacía.");
                }
                else
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}.{Path.GetFileName(files[i])}");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Seleccione el archivo: ");
                Console.WriteLine("Escriba 0 para volver.");


                string? input = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Entrada vacía. Inténtelo de nuevo.");
                    continue;
                }

                if (input == "0") return null;

                if (int.TryParse(input, out int idx))
                {
                    if (idx >= 1 && idx <= files.Length) return files[idx - 1];

                    Console.WriteLine("Índice fuera de rango. Inténtelo de nuevo");
                    continue;
                }

                string candidate = Storage.PathFor(input);
                Console.Clear();
                if (File.Exists(candidate)) return candidate;

                Console.WriteLine("El archivo no existe. Elíja otro índice");
            }
        }

        /// <summary>
        /// Acciones disponibles para el archivo seleccionado.
        /// </summary>

        private void ActionsMenu(string fullPath)
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===============================================");
                Console.WriteLine($"Archivo: '{Path.GetFileName(fullPath)}'.");
                Console.WriteLine("Selecciona la acción a realizar");
                Console.WriteLine("1 - Leer");
                Console.WriteLine("2 - Sobrescribir");
                Console.WriteLine("3 - Modificar (añadir al final)");
                Console.WriteLine("4 - Codificar (Base64)");
                Console.WriteLine("5 - Decodificar (Base64)");
                Console.WriteLine("6 - Otras acciones");
                Console.WriteLine("7 - Borrar.");
                Console.WriteLine("0 - Volver a la lista de archivos");

                if (!int.TryParse(Console.ReadLine(), out int opt) || opt < 0 || opt > 7)
                {
                    Console.WriteLine("Opción incorrecta. Inténtelo de nuevo.");
                    continue;
                }

                if (opt == 0) return;

                switch (opt)
                {
                    case 1:
                        FileReader.ReadFile(fullPath);
                        break;

                    case 2:
                        FileOverwriter.OverwriteFile(fullPath);
                        break;

                    case 3:
                        FileAppender.AppenderFile(fullPath);
                        break;

                    case 4:
                        FileEncoder.EncodeFile(fullPath);
                        break;

                    case 5:
                        FileDecoder.DecodeFile(fullPath);
                        break;

                    case 6:
                        Other.OtherActionsMenu(fullPath);
                        break;
                    case 7:
                        FileDeleter.DeleteFile(fullPath);
                        // Si se borró, salir al listado para elegir otro
                        if (!File.Exists(fullPath)) return;
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Pulse una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
