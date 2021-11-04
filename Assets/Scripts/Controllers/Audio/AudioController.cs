using Model;
using UnityEngine;

namespace SergeyPchelintsev.Expedito.Controllers.Audio
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource tap;
        [SerializeField] private AudioSource pickCheckpoint;
        [SerializeField] private AudioSource pickBonus;

        private void Start()
        {
            Sound.Get.OnPlay += PlaySound;
        }

        private void OnDestroy()
        {
            Sound.Get.OnPlay -= PlaySound;
        }

        private void PlaySound(Sound.SoundKind kind)
        {
            switch (kind)
            {
               case Sound.SoundKind.Tap:
                   tap.Play();
                   break;
               case Sound.SoundKind.Bonus:
                   pickBonus.Play();
                   break;
               case Sound.SoundKind.Checkpoint:
                   pickCheckpoint.Play();
                   break;
            }
        }
    }
}