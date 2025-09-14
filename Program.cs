using System;

namespace TextManager
{
     public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var cast = new fileManager();
            cast.Run();
        }
    }
}