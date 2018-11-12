using PrizeDraw.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PrizeDraw
{
    public class CampaignReader: ICampaignReader
    {
        private readonly TextReader _reader;

        public CampaignReader(TextReader reader)
        {
            _reader = reader;
        }

        public async Task<ICampaign> ReadCampaignInputData()
        {
            var input = await _reader.ReadToEndAsync();
            var inputdata = input.Split
            (
                new[] {Environment.NewLine},
                StringSplitOptions.None
            );

            var duration = int.Parse(inputdata[0]);

            var days = new List<IDay>();
            for (var i = 1; i < inputdata.Length; i++)
            {
                var line = inputdata[i];
                var orderarray = line.Split(' ');

                var numorders = int.Parse(orderarray[0]);
                var orderamounts = new List<int>();

                for (var j = 1; j < orderarray.Length; j++)
                {
                    orderamounts.Add
                    (
                        int.Parse(orderarray[i])
                    );
                }

                days.Add(new Day(i, numorders, orderamounts));
            }

            return new Campaign(duration, days);
        }
    }
}