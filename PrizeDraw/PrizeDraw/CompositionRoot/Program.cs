using PrizeDraw.Validation;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PrizeDraw.CompositionRoot
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                using (StreamReader reader = new StreamReader(Console.OpenStandardInput(), Console.InputEncoding))
                {
                    var prizeDrawApplication = new Application
                        (
                            new CampaignReader(reader),
                            new ValidationFactory(),
                            new Validator(),
                            new PrizeMoneyCalculator()
                        );

                    await prizeDrawApplication.Run();
                }

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
