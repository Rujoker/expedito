using System.Linq;
using UnityEngine;

namespace SergeyPchelintsev.Expedito.Presentation.Alerts
{
    [CreateAssetMenu(fileName = "AlertPrefabHub", menuName = "Expedito/AlertPrefabHub")]
    public class AlertPrefabHub : ScriptableObject
    {
        [SerializeField] private BaseAlert[] alerts;
        
        public BaseAlert GetAlertByType(AlertType alertType)
        {
            return alerts.FirstOrDefault(item => item.TypeOfAlert == alertType);
        }
    }
}