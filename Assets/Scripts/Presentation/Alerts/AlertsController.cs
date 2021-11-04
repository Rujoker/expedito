using System.Collections.Generic;
using SergeyPchelintsev.Expedito.Utils.DI;
using UnityEngine;

namespace SergeyPchelintsev.Expedito.Presentation.Alerts
{
    public class AlertsController : MonoBehaviour
    {
        [SerializeField] private Transform alertsRoot;
        
        private AlertPrefabHub alertPrefabHub;
        private readonly List<BaseAlert> openedAlerts = new List<BaseAlert>();

        private void Start()
        {
            var root = DependencyInjector.Root;
            root.Add(this);
            alertPrefabHub = root.Get<AlertPrefabHub>();
        }

        public void ShowAlert(AlertType alertType, Dictionary<string, object> data = null)
        {
            var alertPrefab = alertPrefabHub.GetAlertByType(alertType);
            var alertToOpen = Instantiate(alertPrefab, alertsRoot);
            alertToOpen.PrepareForShowing(this, data);
            alertToOpen.Show();
            openedAlerts.Add(alertToOpen);
        }
        
        public void CloseAlert(AlertType alertType)
        {
            var alertToClose = openedAlerts.Find(item => item.TypeOfAlert == alertType);
            openedAlerts.Remove(alertToClose);
            Destroy(alertToClose.gameObject);
        }
    }
}