using SergeyPchelintsev.Expedito.Configuration.View;
using SergeyPchelintsev.Expedito.Utils.Localization;
using UnityEngine;
using UnityEngine.UI;

namespace SergeyPchelintsev.Expedito.Presentation.Alerts.Garage
{
    public class CarCardController : MonoBehaviour
    {
        [SerializeField] private Button selectButton;
        [SerializeField] private GameObject selectedState;
        [SerializeField] private Image carPreview;
        [SerializeField] private Text carName;
        [SerializeField] private Text carDescription;
        
        private CarViewConfig.CarViewData carViewData;
        
        public void ShowCar(CarViewConfig.CarViewData data)
        {
            carViewData = data;
            carPreview.sprite = data.icon;
            carName.text = Localization.Instance.Translate(data.carName);
            carDescription.text = Localization.Instance.Translate(data.carDescription);
        }

        public void CheckSelection(int carId)
        {
            selectButton.gameObject.SetActive(carId != carViewData.identifier);
            selectedState.gameObject.SetActive(carId == carViewData.identifier);
        }

        public Button SelectButton => selectButton;

    }
}