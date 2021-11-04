using SergeyPchelintsev.Expedito.Controllers.MenuScene;
using SergeyPchelintsev.Expedito.Controllers.SceneManagement;
using SergeyPchelintsev.Expedito.Model;
using SergeyPchelintsev.Expedito.Utils.DI;
using SergeyPchelintsev.Expedito.Utils.Localization;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SergeyPchelintsev.Expedito.Controllers.MainScene
{
    public class MainSceneController : MonoBehaviour
    {
        [SerializeField] private LocalizationConfig localizationConfig;
        
        private GeneralManager generalManager;// = new GeneralManager();
        private Localization localization;
        private IRoot root;
        private bool isInitialized;
        
        public const string Name = "2_MainScene";

        public void Initialize()
        {
            DependencyInjector.CreateCompositionRoot();

            generalManager = new GeneralManager();
            generalManager.Initialize();

            var sceneLoader = new SceneLoader();

            root = DependencyInjector.Root;
            root.Add(sceneLoader);
            root.Add((IGameMediator)generalManager);

            localization = new Localization(localizationConfig);
            
            isInitialized = true;
            
            DontDestroyOnLoad(this);
            
            LaunchNextScene();
        }

        private void LaunchNextScene()
        {
            SceneManager.UnloadSceneAsync(Launcher.firsSceneId);
            SceneManager.LoadSceneAsync(MenuSceneController.Name, LoadSceneMode.Additive);
        }

        private void Update()
        {
            if (!isInitialized) return;
            generalManager.Update(Time.deltaTime);
        }
    }
}