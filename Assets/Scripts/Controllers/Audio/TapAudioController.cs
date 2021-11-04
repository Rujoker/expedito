using Model;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace SergeyPchelintsev.Expedito.Controllers.Audio
{
    [RequireComponent(typeof(Button))]
    public class TapAudioController : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().OnClickAsObservable().Subscribe(_ => Sound.Get.PlayTap()).AddTo(this);
        }
    }
}