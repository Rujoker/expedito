using SergeyPchelintsev.Expedito.Controllers.MenuScene;
using SergeyPchelintsev.Expedito.Controllers.RideScene;
using SergeyPchelintsev.Expedito.Controllers.SceneManagement;
using SergeyPchelintsev.Expedito.Utils.DI;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace SergeyPchelintsev.Expedito.Presentation.Alerts.Pause
{
    public class PauseAlert : BaseAlert
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button exitButton;

        private SceneLoader sceneLoader;
            
        public override AlertType TypeOfAlert => AlertType.Pause;

        protected override void Awake()
        {
            base.Awake();
            
            var root = DependencyInjector.Root;
            sceneLoader = root.Get<SceneLoader>();
        }

        public override void Show()
        {
            resumeButton.OnClickAsObservable().Subscribe(_ =>ResumeGame()).AddTo(this);
            exitButton.OnClickAsObservable().Subscribe(_ => ToMenu()).AddTo(this);
            
            gameMediator.RideManager.CurrentState.ridePaused.Value = true;
        }

        private void ResumeGame()
        {
            gameMediator.RideManager.CurrentState.ridePaused.Value = false;
            Hide();
        }
        
        private void ToMenu()
        {
            gameMediator.RideManager.CurrentState.ridePaused.Value = false;
            Hide();
            sceneLoader.ReplaceSceneWithLoader(RideSceneController.Name, MenuSceneController.Name);
        }
    }
}