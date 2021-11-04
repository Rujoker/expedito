namespace SergeyPchelintsev.Expedito.Model.Managers.Ride
{
    public class RideManager : BaseManager, IRideManager, ITickable
    {
        private RideState rideState;
        public RideState CurrentState => rideState;
        
        public RideManager(IGameMediator gameMediator) : base(gameMediator)
        {
            
        }
        
        public void SetRideState(RideState rideState)
        {
            this.rideState = rideState;
        }

        public void DestroyRideState()
        {
            rideState = null;
        }

        public void StartRide()
        {
            
        }

        public void AddTime(float bonusTime)
        {
            rideState.ExtendTime(bonusTime);
        }

        public void TakeCheckpoint()
        {
            rideState.TakeCheckpoint();
        }

        public void FinishRide()
        {
           
        }

        public void Tick(float deltaTime)
        {
            rideState?.Tick(deltaTime);
        }
    }
}