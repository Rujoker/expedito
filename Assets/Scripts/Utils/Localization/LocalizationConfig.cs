using System.Collections.Generic;
using UnityEngine;

namespace SergeyPchelintsev.Expedito.Utils.Localization
{
    [CreateAssetMenu(fileName = "Localization", menuName = "Expedito/Localization")]
    public class LocalizationConfig : ScriptableObject
    {
        [SerializeField] private List<LocalizationData> localizationKeysList;
        
        public List<LocalizationData> LocalizationKeysList => localizationKeysList;
        
        [System.Serializable]
        public class LocalizationData
        {
            public string key;
            public List<LocalizationRecord> translations;
        }

        [System.Serializable]
        public class LocalizationRecord
        {
            public SystemLanguage language;
            public string translation;
        }
    }
}