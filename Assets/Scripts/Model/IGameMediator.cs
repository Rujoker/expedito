using SergeyPchelintsev.Expedito.Model.Managers.Campaign;
using SergeyPchelintsev.Expedito.Model.Managers.Ride;
using SergeyPchelintsev.Expedito.Model.Save;

namespace SergeyPchelintsev.Expedito.Model
{
    public interface IGameMediator
    {
        IRideManager RideManager { get; }
        ICampaignManager CampaignManager { get; }
        ISaveManager SaveManager { get; }
    }
}