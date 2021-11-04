using UnityEngine;
using UnityEngine.UI;

namespace SergeyPchelintsev.Expedito.Utils.Localization
{
    [RequireComponent(typeof(Text))]
    public class LocalizationController : MonoBehaviour
    {
        [SerializeField] private string localizationKey;
        [SerializeField] private bool toUpper;
        private void Awake()
        {
            var textComponent = GetComponent<Text>();
            var key = string.IsNullOrEmpty(localizationKey) ? textComponent.text : localizationKey;
            var translation = Localization.Instance.Translate(key);
            textComponent.text = toUpper ? translation.ToUpperInvariant() : translation;
        }
    }
}