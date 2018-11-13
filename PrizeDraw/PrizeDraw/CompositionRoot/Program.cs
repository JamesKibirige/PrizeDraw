using System;
using System.Threading.Tasks;
using Lamar;
using PrizeDraw.IoC;

namespace PrizeDraw.CompositionRoot
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                //Register
                var container = new Container
                (
                    new ApplicationRegistry()
                );

                //Resolve
                var prizeDrawApplication = container.GetInstance<Application>();
                await prizeDrawApplication.Run();

                //Release
                container.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine("An Error has occurred!");
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }
    }
}
