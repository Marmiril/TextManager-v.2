using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.Functions
{
    internal class Other
    {
      
        public static void OtherActionsMenu(string fullPath)
        {
            Console.Clear();
            int opt;

            while (true)
            {
                Console.WriteLine("==============================");
                Console.WriteLine($"Archivo: {Path.GetFileName(fullPath)}.");
                Console.WriteLine("Otras acciones disponibles:");
                Console.WriteLine("1 - Buscar palabra.");
                Console.WriteLine("2 - Contar número de palabras.");
                Console.WriteLine("3 - Contar número de letras.");
                Console.WriteLine("4 - Convertir a mayúsculas.");
                Console.WriteLine("5 - Convertir a minúsculas.");
                Console.WriteLine("6 - Contar líneas.");
                Console.WriteLine("7 - Reemplazar palabra.");
                Console.WriteLine("8 - Invertir palabras.");
                Console.WriteLine("9 - Invertir texto.");
                Console.WriteLine("10 - Eliminar espacios extra.");
                Console.WriteLine("11 - Guardar copia en otro archivo.");
                Console.WriteLine("12 - Encriptar con algoritmo César.");
                Console.WriteLine("13 - Dividir archivo en fragmentos.");
                Console.WriteLine("14 - Unir otro archivo al final.");
                Console.WriteLine("15 - Contar frecuencia de cada letra/palabra.");
                Console.WriteLine("0 - Volver al menú anterior.");

                while(!int.TryParse(Console.ReadLine(), out opt) || opt < 0 || opt > 18)
                {
                    Console.WriteLine("Opción inválida. Inténtelo de nuevo: ");
                }

                if (opt == 0) return;
                else break;
            }

            switch (opt)
            {
                case 1:
                    FileSearcher.SearchInFile(fullPath);
                    break;
                case 2:
                    FileWordCounter.CountWords(fullPath);
                    break;
                case 3:
                    FileLetterCounter.CounteLetters(fullPath);
                    break;
                case 4:
                    FileUpperCase.ToUpperCase(fullPath);
                    break;
                case 5:
                    FileLowerCase.ToLowerCase(fullPath);
                    break;
                case 6:
                    FileLineCounter.CountLines(fullPath);
                    break;
                case 7:
                    FileReplacer.ReplaceWord(fullPath);
                    break;
                case 8:
                    FileWordsInverter.WordsInverter(fullPath);
                    break;
                case 9:
                    FileTextInverter.TextInverter(fullPath);
                    break;
                case 10:
                    FileSpacesRemover.SpacesRemover(fullPath);
                    break;
                case 11:
                    FileCopier.SaveCopy(fullPath);
                    break;
                case 12:
                    FileCaesarCipher.CaesarCipher(fullPath);
                    break;
                case 13:
                    FileSplitText.SplitText(fullPath);
                    break;
                case 14:
                    FileJoinText.JoinText(fullPath);
                    break;
                case 15:
                    FileLetterFrequency.CountLetter(fullPath);
                    break;
            }
        }
    }
}
