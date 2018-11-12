using System.Collections.Generic;

namespace PrizeDraw.Interfaces
{
    public interface ICampaign
    {
        int Duration { get; }
        IEnumerable<IDay> Days { get; }
        int CountDays { get; }
        int TotalOrders { get; }
    }
}