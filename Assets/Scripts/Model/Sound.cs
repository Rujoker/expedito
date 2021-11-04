using UnityEngine;

namespace Model
{
    public class Sound
    {
        public enum SoundKind
        {
            Tap,
            Bonus,
            Checkpoint
        }

        public delegate void OnPlaySoundDelegate(SoundKind kind);

        public OnPlaySoundDelegate OnPlay;

        private const string SoundKey = "sound_enabled";
        
        private static Sound _instance;

        public static Sound Get => _instance ??= new Sound();

        public bool SoundEnabled
        {
            get
            {
                if (!PlayerPrefs.HasKey(SoundKey))  PlayerPrefs.SetInt(SoundKey, 1);
                return PlayerPrefs.GetInt(SoundKey) == 1;
            }
            set
            {
                PlayerPrefs.SetInt(SoundKey, value ? 1 : 0);
                PlayerPrefs.Save();
            }
        }

        public void PlayTap()
        {
            if (SoundEnabled) OnPlay(SoundKind.Tap);
        }
        
        public void PlayBonusPick()
        {
            if (SoundEnabled) OnPlay(SoundKind.Bonus);
        }   
        
        public void PlayCheckpointPick()
        {
            if (SoundEnabled) OnPlay(SoundKind.Checkpoint);
        }
    }
}