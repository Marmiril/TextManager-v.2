using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManager.Functions
{
    internal enum SaveResult
    {
        Saved,
        NotSaved,
        Cancelled
    }

    internal static class SaveHelper
    {
        /// <summary
        /// Muestra un prompt (S/N/CANCEL). Si s, escrive el archivo;
        /// Devuelve Saved / NotSaved / Cancelled.
        /// </summary>
        
        public static SaveResult AskSave(string fullPath, string content)
        {
            while (true)
            {
                Console.WriteLine("¿Desea mantener los cambios?:(S/N/CANCEL)");
                string? resp = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(resp))
                {
                    Console.WriteLine("Indique S, N o CANCEL.");
                    continue;
                }

                string r = resp.ToUpperInvariant();

                if (r == "S")
                {
                    try
                    {
                        File.WriteAllText(fullPath, content, Encoding.UTF8);
                        Console.WriteLine($"Los cambios se han guardado correctamente en {Path.GetFileName(fullPath)}.");
                        return SaveResult.Saved;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al guardar el archivo: {ex.Message}.");
                        return SaveResult.Cancelled;
                    }
                }
                if (r == "N")
                {
                    Console.WriteLine("Los cambios no se han guardado.");
                    return SaveResult.NotSaved;
                }
                if (r == "CANCEL")
                {
                    Console.WriteLine("Operación cancelada.");
                    return SaveResult.Cancelled;
                }
                else
                {
                    Console.WriteLine("Opción incorrecta. Inténtelo de nuevo");
                    continue;
                }
            }
        }
    }
}
