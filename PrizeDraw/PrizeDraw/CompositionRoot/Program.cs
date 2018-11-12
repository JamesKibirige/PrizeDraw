using PrizeDraw.Interfaces;
using System;

namespace PrizeDraw
{
    public class Program
    {
        private static IApplication _prizeDrawApplication;
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello World!");

            }
            catch (Exception e)
            {
                Console.WriteLine("An Error has occurred!");
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();

                Environment.FailFast(e.Message);
            }
        }
    }
}
