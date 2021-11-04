using System.Collections.Generic;
using Model;
using SergeyPchelintsev.Expedito.Configuration.View;
using SergeyPchelintsev.Expedito.Model;
using SergeyPchelintsev.Expedito.Utils.DI;
using UniRx;
using UnityEngine;

namespace SergeyPchelintsev.Expedito.Presentation.Alerts.Garage
{
    public class SelectCarController : MonoBehaviour
    {
        [SerializeField] private CarCardController carCardPrefab;
        [SerializeField] private Transform carsRoot;
        
        [SerializeField] private CarViewConfig carViewConfig;

        private readonly List<CarCardController> carViews = new List<CarCardController>();
        private IGameMediator gameMediator;

        private void Awake()
        {
            var root = DependencyInjector.Root;
            gameMediator = root.Get<IGameMediator>();
        }

        private void Start()
        {
            foreach (var carData in carViewConfig.CarContainerList)
            {
                var card = Instantiate(carCardPrefab, carsRoot);
                card.ShowCar(carData);
                carViews.Add(card);
                card.SelectButton.OnClickAsObservable().Subscribe(_ => SelectCar(carData)).AddTo(card);
                CheckSelection();
            }
        }

        private void SelectCar(CarViewConfig.CarViewData cardData)
        {
            gameMediator.CampaignManager.SelectCar(cardData.identifier);
            CheckSelection();
        }

        private void CheckSelection()
        {
            foreach (var carView in carViews)
            {
                carView.CheckSelection(gameMediator.CampaignManager.CurrentCar);
            }
        }
    }
}