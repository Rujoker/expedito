using SergeyPchelintsev.Expedito.Controllers.MainScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SergeyPchelintsev.Expedito.Controllers
{
    public class Launcher : MonoBehaviour
    {
        public static int firsSceneId = 0;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void OnAppLoaded()
        {
            var launcher = new Launcher();
        }

        private Launcher()
        {
            firsSceneId = SceneManager.GetActiveScene().buildIndex;

            SceneManager.sceneLoaded += InitializeMainSceneController;
            SceneManager.LoadSceneAsync(MainSceneController.Name, LoadSceneMode.Additive);
        }

        private void InitializeMainSceneController(Scene scene, LoadSceneMode mode)
        {
            SceneManager.sceneLoaded -= InitializeMainSceneController;
            var coreController = GameObject.FindObjectOfType<MainSceneController>();
            coreController.Initialize();
        }
    }
}
