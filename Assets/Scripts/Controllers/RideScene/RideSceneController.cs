using System;
using System.Collections;
using SergeyPchelintsev.Expedito.Configuration.Model;
using SergeyPchelintsev.Expedito.Model;
using SergeyPchelintsev.Expedito.Model.Managers.Ride;
using SergeyPchelintsev.Expedito.Presentation.Alerts;
using SergeyPchelintsev.Expedito.Utils.DI;
using SergeyPchelintsev.Expedito.Utils.Localization;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace SergeyPchelintsev.Expedito.Controllers.RideScene
{
    public class RideSceneController : MonoBehaviour
    {
        public const string Name = "4_RideScene";
        
        [Header("Buttons")] 
        [SerializeField] private Button pauseButton;
        
        [Header("Text")]
        [SerializeField] private Text timer;
        [SerializeField] private Text checkpointsProgress;
        [SerializeField] private Text distance;
        [SerializeField] private Text gas;
        [SerializeField] private ColorfulIndicator gasIndicator;
        [SerializeField] private ColorfulIndicator distanceIndicator;
        [SerializeField] private ColorfulIndicator timeIndicator;
        
        [Header("Other")]
        [SerializeField] private int startTime = 60;
       
        private CarConfig carConfig;
        private IGameMediator gameMediator;
        private AlertsController alertsController;
        private RideState rideState;
        private string metersShortMessage;
        
        private const float MinTimeForExtra = 25f;
        private const float MinFuelForExtra = 0.25f;
        private const float MaxDistanceForExtra = 50f;
        
        private void Awake()
        {
            var root = DependencyInjector.Root;
            carConfig = root.Get<CarConfig>();
            gameMediator = root.Get<IGameMediator>();
            alertsController = root.Get<AlertsController>();

            pauseButton.OnClickAsObservable().Subscribe(_ => ShowPauseScreen()).AddTo(this);
        }

        private void Start()
        {
            var data = carConfig.GetById(gameMediator.CampaignManager.CurrentCar);
            
            rideState = new RideState(startTime, data.fuelCapacity, data.fuelPerSecond);
            gameMediator.RideManager.SetRideState(rideState);
            gameMediator.RideManager.StartRide();
            
            gameMediator.RideManager.CurrentState.rideFinished.Subscribe(value =>
            {
                if (value) ShowFinishScreen();
            }).AddTo(this);

            rideState.ridePaused.Subscribe(PauseGame).AddTo(this);
            PauseGame(false);

            metersShortMessage = Localization.Instance.Translate("METERS_SHORT");

            StartCoroutine(UpdateView());
        }

        private void ShowPauseScreen()
        {
            alertsController.ShowAlert(AlertType.Pause);
        }
        
        private void ShowFinishScreen()
        {
            PauseGame(true);
            alertsController.ShowAlert(AlertType.Finish);
        }

        private void PauseGame(bool paused)
        {
            Time.timeScale = paused ? 0 : 1;
        }

        private IEnumerator UpdateView()
        {
            while (true)
            {
                UpdateTextMessages();
                UpdateIndicationColors(); 
                yield return new WaitForSeconds(0.1f);
            }
        }

        private void UpdateTextMessages()
        {
            timer.text = TimeSpan.FromSeconds(rideState.TimeToFinish).ToString("mm':'ss");
            checkpointsProgress.text = $"{rideState.Score}";
            distance.text = $"{Math.Ceiling(rideState.Distance)} {metersShortMessage}";
            gas.text = $"{Math.Round(100 * rideState.CurrentFuel/rideState.MaxFuel)}%";
        }

        private void UpdateIndicationColors()
        {
            timeIndicator.SetAsExtra(rideState.TimeToFinish < MinTimeForExtra);
            gasIndicator.SetAsExtra(rideState.CurrentFuel/rideState.MaxFuel < MinFuelForExtra);
            distanceIndicator.SetAsExtra(rideState.Distance < MaxDistanceForExtra);
        }
    }
}