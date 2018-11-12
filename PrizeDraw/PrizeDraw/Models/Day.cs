using PrizeDraw.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PrizeDraw.Models
{
    public class Day : IDay
    {
        public int Index { get; }
        public virtual int NumberOrders { get;}
        public IEnumerable<int> OrderAmounts { get;}

        public virtual int CountOrderAmounts => OrderAmounts.Count();

        public Day(int index,int numberOrders, IEnumerable<int> orderAmounts)
        {
            NumberOrders = numberOrders;
            OrderAmounts = orderAmounts;
            Index = index;
        }
    }
}