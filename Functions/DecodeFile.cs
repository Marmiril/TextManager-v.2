using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.Functions
{
    internal static class FileDecoder
    {
        public static void DecodeFile(string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                Console.WriteLine("El archivo no existe. Nada que decodificar.");
                return;
            }

            try
            {
                string encoded = File.ReadAllText(fullPath, Encoding.UTF8);

                // Decodificar desde Base64
                byte[] bytes = Convert.FromBase64String(encoded);
                string decoded = Encoding.UTF8.GetString(bytes);

                string tempPath = fullPath + ".tmp";
                File.WriteAllText(tempPath, decoded, Encoding.UTF8);

                //Reemplazo atómico con copia de seguridad-
                string backupPath = fullPath + ".bak";
                File.Replace(tempPath, fullPath, backupPath);
            

                //File.WriteAllText(newPath, decoded, Encoding.UTF8);
                File.Delete(backupPath);


                Console.WriteLine($"Archivo decodificado correctamente. Guardado como '{Path.GetFileName(fullPath)}'.");
            }
            catch (FormatException)
            {
                Console.WriteLine("El archivo no tiene un formato válido de Base64. No se pudo decodificar.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al decodificar el archivo: {ex.Message}.");
            }

        }
    }
}
