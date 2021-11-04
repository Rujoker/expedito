using UniRx;

namespace SergeyPchelintsev.Expedito.Model.Managers.Ride
{
    public class RideState
    {
        private int currentCarId;
        
        private float timeToFinish;
        
        private float currentFuel;
        private float maxFuel;
        private float consumptionRate;
        
        private long score;

        internal float TimeToFinish => timeToFinish;
        internal float Score => score;
        internal double Distance { get; set; }
        internal float CurrentFuel => currentFuel;
        internal float MaxFuel => maxFuel;

        internal readonly BoolReactiveProperty ridePaused = new BoolReactiveProperty();
        internal readonly BoolReactiveProperty rideFinished = new BoolReactiveProperty();

        public RideState(float timeToFinish, float maxFuel, float consumeRate)
        {
            this.timeToFinish = timeToFinish;
            this.maxFuel = maxFuel;
            this.consumptionRate = consumeRate;
            this.currentFuel = maxFuel;
        }
        
        public void Tick(float deltaTime)
        { 
            if (ridePaused.Value) return;
            
            timeToFinish -= deltaTime;

            if (timeToFinish <= 0 || currentFuel <= 0) rideFinished.Value = true;
        }

        public void ExtendTime(float addTime) => timeToFinish += addTime;
        public void TakeCheckpoint() => score++;
        public void RefillFuel() => currentFuel = maxFuel;

        public void ConsumeFuel(float second)
        {
            currentFuel -= (second * consumptionRate);
        }
    }
}