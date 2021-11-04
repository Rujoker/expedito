namespace SergeyPchelintsev.Expedito.Model.Managers.Ride
{
    public interface IRideManager
    {
        RideState CurrentState { get; }
        void SetRideState(RideState rideState);
        void DestroyRideState();
        void StartRide();
        void AddTime(float bonusTime);
        void TakeCheckpoint();
        void FinishRide();
    }
}