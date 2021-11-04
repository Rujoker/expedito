using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace SergeyPchelintsev.Expedito.Presentation.Alerts.Garage
{
    public class GarageAlert : BaseAlert
    {
        [SerializeField] private Button closeButton;
        
        public override AlertType TypeOfAlert => AlertType.Garage;

        public override void Show()
        {
            closeButton.OnClickAsObservable().Subscribe(_ => Hide()).AddTo(this);
        }
    }
}