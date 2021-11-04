using System;
using Model;
using SergeyPchelintsev.Expedito.Model;
using SergeyPchelintsev.Expedito.Model.Managers.Ride;
using SergeyPchelintsev.Expedito.Utils;
using SergeyPchelintsev.Expedito.Utils.DI;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

namespace SergeyPchelintsev.Expedito.Controllers.RideScene
{
    public class CheckpointController : MonoBehaviour
    {
        private Transform carPosition;
        private IRideManager rideManager;
        private double distance;
        
        public delegate void TakeCheckpoint();
        public TakeCheckpoint OnCheckpointTaken { get; set; }

        private void Awake()
        {
            var root = DependencyInjector.Root;
            var gameMediator = root.Get<IGameMediator>();

            rideManager = gameMediator.RideManager;
        }

        private void Start()
        {
            carPosition = FindObjectOfType<CameraFollow>().Target;
        }

        private void Update()
        {
            rideManager.CurrentState.Distance = Math.Sqrt(Math.Abs((carPosition.position - transform.position).sqrMagnitude));
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.GetComponent<CarController>()) return;
            Sound.Get.PlayCheckpointPick();
            
            rideManager.TakeCheckpoint();

            OnCheckpointTaken();
            Destroy(gameObject);
        }

    }
}