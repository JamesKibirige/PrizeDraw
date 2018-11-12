using System.Collections.Generic;

namespace PrizeDraw.Interfaces
{
    public interface IDay
    {
        int Index { get; }
        int NumberOrders { get; }
        IEnumerable<int> OrderAmounts { get; }
        int CountOrderAmounts { get; }
    }
}