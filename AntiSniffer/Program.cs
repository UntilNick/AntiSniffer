namespace AntiSniffer
{
    using System;

    internal static class Program
    {
        private static void Main()
        {
            Console.Title = "AntiSniffer by Antlion";
            AntiSniffer.Inizialize(); // Убиваем все найденные снифферы.
            Console.ReadKey();
        }
    }
}