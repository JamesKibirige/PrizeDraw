using System.Threading.Tasks;

namespace PrizeDraw.Interfaces
{
    public interface ICampaignReader
    {
        Task<ICampaign> ReadCampaignInputData();
    }
}