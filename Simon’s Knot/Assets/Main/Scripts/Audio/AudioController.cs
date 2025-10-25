using Simon.Configs;
using UnityEngine;

namespace Simon.Audio
{
    public class AudioController : MonoBehaviour
    {
        public static AudioController Instance;
        [SerializeField] private SoundConfig _soundConfig;
        private AudioSource _oneShotAudioSource;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            _oneShotAudioSource = gameObject.AddComponent<AudioSource>();
        }
        public void PlaySound(SoundName soundEnum)
        {
            if (!_soundConfig.Sounds.ContainsKey(soundEnum)) return;
            if (_soundConfig.Sounds[soundEnum] == null) return;
            _oneShotAudioSource.PlayOneShot(_soundConfig.Sounds[soundEnum]);
        }
    }

    public enum SoundName
    {
        None,
        ButtonClick,
        Step
    }
}