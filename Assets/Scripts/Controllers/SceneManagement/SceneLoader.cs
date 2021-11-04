using System;
using SergeyPchelintsev.Expedito.Controllers.LoadingScene;
using SergeyPchelintsev.Expedito.Controllers.RideScene;
using UniRx;
using UnityEngine.SceneManagement;

namespace SergeyPchelintsev.Expedito.Controllers.SceneManagement
{
    public class SceneLoader
    {
        public void ReplaceSceneWithLoader(string toUnload, string toLoad, Action onComplete = null)
        {
            LoadScene(LoadingSceneController.Name, () =>
            {
                ReplaceScene(toUnload, toLoad, () =>
                {
                    UnloadScene(LoadingSceneController.Name, onComplete);
                });
            });
        }
        
        public void ReplaceScene(string toUnload, string toLoad, Action onComplete = null)
        {
            UnloadScene(toUnload);
            LoadScene(toLoad, onComplete);
        }

        public void LoadScene(string sceneName, Action onComplete = null)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive)
                .AsAsyncOperationObservable()
                .Subscribe(_ =>
                {
                    onComplete?.Invoke();
                });
        }

        public void UnloadScene(string sceneName, Action onComplete = null)
        {
            SceneManager.UnloadSceneAsync(sceneName)
                .AsAsyncOperationObservable()
                .Subscribe(_ =>
                {
                    onComplete?.Invoke();
                });
        }
    }
}