using RotaryHeart.Lib.SerializableDictionary;
using Simon.Audio;
using UnityEngine;

namespace Simon.Configs
{
    [CreateAssetMenu(fileName = "Sound Config", menuName = "Configs/SoundConfig")]
    public class SoundConfig : ScriptableObject
    {
        [SerializeField] private SerializableDictionaryBase<SoundName, AudioClip> _sounds;
        public SerializableDictionaryBase<SoundName, AudioClip> Sounds => _sounds;
    }
}