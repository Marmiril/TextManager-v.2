using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextManager.Functions;

namespace TextManager.Functions
{
    internal static class FileJoinText
    {
        public static void JoinText(string fullPath)
        {
            if (!FileHelper.EnsureFileExists(fullPath)) return;

            string? name = string.Empty;

            string? otherPath = FileSelector.PickFile();
        

            if (!FileHelper.EnsureFileExists(otherPath)) return;

            try
            {
                string content1 = File.ReadAllText(fullPath, Encoding.UTF8);
                string content2 = File.ReadAllText(otherPath, Encoding.UTF8);

                string merged = content1 + Environment.NewLine + content2;


                Console.WriteLine("================================================================================ ");
                Console.WriteLine("============================== TEXTO MODIFICADO ================================ ");
                Console.WriteLine("================================================================================ ");
                Console.WriteLine(merged);

                SaveHelper.AskSave(fullPath, merged);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar el archivo.");
            }




        }
    }
}
