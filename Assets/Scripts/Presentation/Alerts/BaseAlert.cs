using System.Collections.Generic;
using Model;
using SergeyPchelintsev.Expedito.Model;
using SergeyPchelintsev.Expedito.Utils.DI;
using UnityEngine;

namespace SergeyPchelintsev.Expedito.Presentation.Alerts
{
    public abstract class BaseAlert : MonoBehaviour
    {
        protected AlertsController alertsController;
        protected IGameMediator gameMediator;

        public abstract AlertType TypeOfAlert { get; }
        
        protected virtual void Awake()
        {
            var root = DependencyInjector.Root;
            gameMediator = root.Get<IGameMediator>();
        }

        public virtual void Show() { }

        public virtual void Hide()
        {
            alertsController.CloseAlert(TypeOfAlert);
        }

        public void PrepareForShowing(AlertsController alertsController, Dictionary<string, object> data)
        {
            this.alertsController = alertsController;
            
            Prepare(data);
        }


        protected virtual void Prepare(Dictionary<string, object> data)
        {
            
        }
 
    }
}