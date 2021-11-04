using SergeyPchelintsev.Expedito.Controllers.MenuScene;
using SergeyPchelintsev.Expedito.Controllers.RideScene;
using SergeyPchelintsev.Expedito.Controllers.SceneManagement;
using SergeyPchelintsev.Expedito.Utils.DI;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace SergeyPchelintsev.Expedito.Presentation.Alerts.Finish
{
    public class FinishAlert : BaseAlert
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuButton;

        private SceneLoader sceneLoader;
        
        protected override void Awake()
        {
            base.Awake();
            
            var root = DependencyInjector.Root;
            sceneLoader = root.Get<SceneLoader>();
        }
        
        public override AlertType TypeOfAlert => AlertType.Finish;
        
        public override void Show()
        {
            restartButton.OnClickAsObservable().Subscribe(_ => Restart()).AddTo(this);
            menuButton.OnClickAsObservable().Subscribe(_ => ToMenu()).AddTo(this);
        }
        
        private void Restart()
        {
            Hide();
            sceneLoader.ReplaceSceneWithLoader(RideSceneController.Name, RideSceneController.Name);
        }
        
        private void ToMenu()
        {
            Hide();
            sceneLoader.ReplaceSceneWithLoader(RideSceneController.Name, MenuSceneController.Name);
        }
    }
}