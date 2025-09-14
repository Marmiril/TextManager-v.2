using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.Functions
{
    internal static class FileCaesarCipher
    {
        public static void CaesarCipher(string fullPath)
        {
            if (!FileHelper.EnsureFileExists(fullPath)) return;

            string content = File.ReadAllText(fullPath, Encoding.UTF8);
            string transformed = ApplyRotAscii13(content);

            Console.WriteLine("================================================================================ ");
            Console.WriteLine("============================== TEXTO MODIFICADO ================================ ");
            Console.WriteLine("================================================================================ ");
            Console.WriteLine(transformed);

            SaveHelper.AskSave(fullPath, transformed);
        }
            private const int baseAscii = 32; 
            private const int rango = 95; // 126 - 32 + 1 ==>> para crear un loop circular en el rango.
            private const int shift = 13;

        // Núcleo del cifrado/descifrado.
        public static string ApplyRotAscii13(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            var sb = new StringBuilder(input.Length);

            foreach (char c in input)
            {
                // Sólo se desplaza lo imprimible, se preservan saltos de línea y demás.
                if (c >= 32 && c <= 126)
                {
                    int swift = baseAscii + ((c - baseAscii + shift) % rango);
                    sb.Append((char)swift);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }        
    }
}
