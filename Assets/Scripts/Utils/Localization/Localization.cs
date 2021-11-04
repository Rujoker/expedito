using UnityEngine;

namespace SergeyPchelintsev.Expedito.Utils.Localization
{
    public class Localization
    {
        private LocalizationConfig config;
        private SystemLanguage language;
        private const SystemLanguage defaultLanguage = SystemLanguage.English;

        public static Localization Instance { get; private set; }
        
        public Localization(LocalizationConfig localizationConfig)
        {
            config = localizationConfig;
            language = Application.systemLanguage;

            Instance = this;
        }

        public string Translate(string key)
        {
            var localizationData = config.LocalizationKeysList.Find(item => item.key == key);
            if (localizationData == null) return key;
            
            var record = localizationData.translations.Find(item => item.language == language) 
                         ?? localizationData.translations.Find(item => item.language == defaultLanguage);

            return record == null ? key : record.translation;
        }
    }
}