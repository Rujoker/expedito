namespace SergeyPchelintsev.Expedito.Model.Managers.Campaign
{
    public interface ICampaignManager
    {
        long TotalScore { get; }
        int CurrentCar { get; }
        void SelectCar(int carId);
    }
}