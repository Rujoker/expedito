using System.Collections.Generic;
using SergeyPchelintsev.Expedito.Model.Managers;
using SergeyPchelintsev.Expedito.Model.Managers.Campaign;
using SergeyPchelintsev.Expedito.Model.Managers.Ride;
using SergeyPchelintsev.Expedito.Model.Save;

namespace SergeyPchelintsev.Expedito.Model
{
    public class GeneralManager : IGameMediator
    {
        private RideManager rideManager;
        private CampaignManager campaignManager;
        private SaveManager saveManager;
        
        private List<BaseManager> allManagers = new List<BaseManager>();
        private List<ITickable> tickables = new List<ITickable>();

        private const float TickTimerMax = 1f;
        private float tickTimer;

        public IRideManager RideManager => rideManager;
        public ICampaignManager CampaignManager => campaignManager;
        public ISaveManager SaveManager => saveManager;

        public void Initialize()
        {
            rideManager = new RideManager(this);
            allManagers.Add(rideManager);          
            
            campaignManager = new CampaignManager(this);
            allManagers.Add(campaignManager);

            saveManager = new SaveManager();

            foreach (var manager in allManagers)
            {
                manager.Initialize();
                
                if (manager is ITickable tickable) tickables.Add(tickable);
            }
        }
        
        public void Update(float deltaTime)
        {
            tickTimer += deltaTime;

            while (tickTimer >= TickTimerMax)
            {
                foreach (var manager in tickables)
                {
                    manager.Tick(TickTimerMax);
                }

                tickTimer -= TickTimerMax;
            }
        }
    }
}