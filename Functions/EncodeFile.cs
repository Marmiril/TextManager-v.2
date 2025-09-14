using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.Functions
{
    internal static class FileEncoder
    {
        public static void EncodeFile(string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                Console.WriteLine("El archivo no existe. Nada que codificar.");
                    return;
            }

            try
            {
                string content = File.ReadAllText(fullPath);

                // Codificación a Base64.
                string encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(content));

                // Guardar en uno temporal.
                string tempPath = fullPath + ".tmp";
                File.WriteAllText(tempPath, encoded, Encoding.UTF8);

                // Reemplazar el original por el temporal, con copia de seguridad.
                string backupPath = fullPath + ".bak";
                File.Replace(tempPath, fullPath, backupPath);

                
                File.Delete(backupPath);


                Console.WriteLine($"Archivo codificado correctamente. Guardado cómo: '{Path.GetFileName(fullPath)}'.");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error al codificar el archivo: {ex.Message}.");
            }
        }
    }
}
