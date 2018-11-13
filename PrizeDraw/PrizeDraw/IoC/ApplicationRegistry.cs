using System;
using System.IO;
using System.Text;
using Lamar;
using PrizeDraw.Interfaces;
using PrizeDraw.Validation;

namespace PrizeDraw.IoC
{
    public class ApplicationRegistry: ServiceRegistry
    {
        public ApplicationRegistry()
        {
            For<IApplication>().Use<Application>();
            For<ICampaignReader>().Use<CampaignReader>();
            For<IValidationFactory>().Use<ValidationFactory>();
            For<IValidator>().Use<Validator>();
            For<IPrizeMoneyCalculator>().Use<PrizeMoneyCalculator>();
            For<TextReader>().Use<StreamReader>()
                .Ctor<Stream>().Is(Console.OpenStandardInput())
                .Ctor<Encoding>().Is(Console.InputEncoding);         
        }
    }
}