using UnityEngine;
using UnityEngine.UI;

namespace SergeyPchelintsev.Expedito.Controllers.RideScene
{
    public class ColorfulIndicator : MonoBehaviour
    {
        [SerializeField] private Text message;
        [SerializeField] private Color normalIndicatorColor;
        [SerializeField] private Color specialIndicatorColor;

        private bool wasExtra;
        
        public void SetAsExtra(bool isExtra)
        {
            if (!wasExtra && isExtra) message.color = specialIndicatorColor;
            else if (wasExtra && !isExtra) message.color = normalIndicatorColor;

            wasExtra = isExtra;
        }
    }
}