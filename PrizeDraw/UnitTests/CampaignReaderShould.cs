using PrizeDraw;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace UnitTests
{
    public class CampaignReaderShould
    {
        [Theory]
        [MemberData(nameof(InputData))]
        public async Task ReadCampaignInputData_FromTextReader_ReturnsCampaign(string campaigninput)
        {
            using (var sr = new StringReader(campaigninput))
            {
                //Arrange
                Console.SetIn(sr);

                //Act
                var result = await new CampaignReader(sr).ReadCampaignInputData();

                //Assert    
                Assert.NotNull(result);
                Assert.IsAssignableFrom<ICampaign>(result);
                Assert.Equal(5, result.Duration);
                Assert.Equal(5, result.CountDays);
                Assert.Equal(10, result.TotalOrders);
            }
        }

        public static IEnumerable<object[]> InputData()
        {
            var builder = new StringBuilder();
            builder.Append("5");
            builder.AppendLine("3 1 2 3");
            builder.AppendLine("2 1 1");
            builder.AppendLine("4 10 5 5 1");
            builder.AppendLine("0");
            builder.AppendLine("1 2");

            yield return new object[]
            {
                builder.ToString()
            };
        }
    }
}