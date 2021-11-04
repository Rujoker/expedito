using SergeyPchelintsev.Expedito.Model.Save;

namespace SergeyPchelintsev.Expedito.Model.Managers.Campaign
{
    public class CampaignManager : BaseManager, ICampaignManager
    {
        private int currentCarId;
        
        public long TotalScore { get; }
        public int CurrentCar => currentCarId;

        public CampaignManager(IGameMediator gameMediator) : base(gameMediator) {}

        public override void Initialize()
        {
            currentCarId = gameMediator.SaveManager.GetValue(SaveKeys.CurrentCarKey)?.AsInt ?? 1;
        }
        
        public void SelectCar(int carId)
        {
            currentCarId = carId;
            
            gameMediator.SaveManager.PutValue(SaveKeys.CurrentCarKey, carId);
            gameMediator.SaveManager.Save();
        }
    }
}