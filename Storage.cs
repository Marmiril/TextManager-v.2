using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextManager
{
    internal static class Storage
    {
        // Carpeta base: MisDocumentos\TextManager
        public static readonly string DataRoot = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "TextManager");

        // Garantiza que la carpeta exista. No da error si ya existe.
        public static void EnsureRoot()
        {
            Directory.CreateDirectory(DataRoot);
        }

        // Combina la carpeta base con un nombre de archivo.
        public static string PathFor(string fileName) => Path.Combine(DataRoot, fileName);
        
        
        
    }
}
