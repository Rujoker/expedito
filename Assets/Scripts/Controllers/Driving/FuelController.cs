using SergeyPchelintsev.Expedito.Model;
using SergeyPchelintsev.Expedito.Model.Managers.Ride;
using SergeyPchelintsev.Expedito.Utils.DI;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

namespace SergeyPchelintsev.Expedito.Controllers.Driving
{
    [RequireComponent(typeof (CarController))]
    public class FuelController : MonoBehaviour
    {
        private CarController car;
        private IRideManager rideManager;

        private void Awake()
        {
            var root = DependencyInjector.Root;
            var gameMediator = root.Get<IGameMediator>();
            rideManager = gameMediator.RideManager;
            
            car = GetComponent<CarController>();
        }

        private void FixedUpdate()
        {
            if (car.CurrentSpeed > 0)
            {
                rideManager.CurrentState.ConsumeFuel(Time.fixedDeltaTime);
            }
        }
    }
}