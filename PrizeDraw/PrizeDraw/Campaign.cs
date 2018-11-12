using System.Collections.Generic;
using System.Linq;

namespace PrizeDraw
{
    public class Campaign : ICampaign
    {
        public int Duration { get;}
        public IEnumerable<IDay> Days { get; }

        public int CountDays => Days.Count();

        public int TotalOrders => Days.Sum(day => day.NumberOrders);

        public Campaign(int duration, IEnumerable<IDay> days)
        {
            Duration = duration;
            Days = days;
        }
    }
}
