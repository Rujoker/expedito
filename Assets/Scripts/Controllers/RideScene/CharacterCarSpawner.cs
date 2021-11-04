using SergeyPchelintsev.Expedito.Configuration.View;
using SergeyPchelintsev.Expedito.Controllers.Driving;
using SergeyPchelintsev.Expedito.Model;
using SergeyPchelintsev.Expedito.Utils;
using SergeyPchelintsev.Expedito.Utils.DI;
using UnityEngine;

namespace SergeyPchelintsev.Expedito.Controllers.RideScene
{
    public class CharacterCarSpawner : MonoBehaviour
    {
        [SerializeField] private CarViewConfig carViewConfig;
        [SerializeField] private Transform startPosition;
        [SerializeField] private CameraFollow cameraFollow;

        private IGameMediator gameMediator;

        private void Awake()
        {
            var root = DependencyInjector.Root;
            gameMediator = root.Get<IGameMediator>();
        }

        private void Start()
        {
            var carViewData = carViewConfig.GetById(gameMediator.CampaignManager.CurrentCar);
            var selectedCarPrefab = carViewData.carPrefab;
            var carController = Instantiate(selectedCarPrefab, startPosition);
            cameraFollow.Target = carController.transform;
            carController.gameObject.AddComponent<CarJoystickControl>();
            carController.gameObject.AddComponent<FuelController>();
        }
    }
}