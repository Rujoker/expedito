using SergeyPchelintsev.Expedito.Controllers.LoadingScene;
using SergeyPchelintsev.Expedito.Controllers.RideScene;
using SergeyPchelintsev.Expedito.Controllers.SceneManagement;
using SergeyPchelintsev.Expedito.Presentation.Alerts;
using SergeyPchelintsev.Expedito.Utils.DI;
using UniRx;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace SergeyPchelintsev.Expedito.Controllers.MenuScene
{
    public class MenuSceneController : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button garageButton;
        [SerializeField] private Button exitButton;
        
        private SceneLoader sceneLoader;
        private AlertsController alertsController;
        
        public const string Name = "3_MenuScene";

        private void Start()
        {
            var root = DependencyInjector.Root;
            alertsController = root.Get<AlertsController>();
            sceneLoader = root.Get<SceneLoader>();
            
            playButton.OnClickAsObservable().Subscribe(_ => LaunchGame()).AddTo(this);
            garageButton.OnClickAsObservable().Subscribe(_ => ShowGarage()).AddTo(this);
            exitButton.OnClickAsObservable().Subscribe(_ => ExitGame()).AddTo(this);
        }

        private void LaunchGame()
        {
            sceneLoader.ReplaceSceneWithLoader(Name, RideSceneController.Name);
        }

        private void ShowGarage()
        {
            alertsController.ShowAlert(AlertType.Garage);
        }
        
        private void ExitGame()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }
}