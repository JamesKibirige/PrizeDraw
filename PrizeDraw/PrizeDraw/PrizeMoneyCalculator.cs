using PrizeDraw.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PrizeDraw
{
    public class PrizeMoneyCalculator: IPrizeMoneyCalculator
    {
        public int CalculatePrizeMoney(ICampaign aCampaign)
        {
            var prizeDrawAmounts = new List<int>();
            var customerPrizeMoney = new List<int>();

            foreach (var day in aCampaign.Days)
            {
                prizeDrawAmounts.AddRange(day.OrderAmounts);
                prizeDrawAmounts.Sort();

                var largestamount = prizeDrawAmounts.Max();
                var smallestamount = prizeDrawAmounts.Min();

                customerPrizeMoney.Add(largestamount - smallestamount);

                prizeDrawAmounts.Remove(largestamount);
                prizeDrawAmounts.Remove(smallestamount);
            }

            return customerPrizeMoney.Sum(m => m);
        }
    }
}