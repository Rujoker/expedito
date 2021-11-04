using Model;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace SergeyPchelintsev.Expedito.Controllers.Audio
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private GameObject enabledState;
        [SerializeField] private GameObject disabledState;
        [SerializeField] private Button button;
      
        private void Start()
        {
            UpdateState();
            button.OnClickAsObservable().Subscribe(_ => EnableSound()).AddTo(this);
        }

        private void UpdateState()
        {
            enabledState.SetActive(Sound.Get.SoundEnabled);
            disabledState.SetActive(!Sound.Get.SoundEnabled);
        }
        
        public void EnableSound()
        {
            Sound.Get.SoundEnabled = !Sound.Get.SoundEnabled;
            Sound.Get.PlayTap();
            UpdateState();
        }
        
    }
}