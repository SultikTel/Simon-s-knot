using RotaryHeart.Lib.SerializableDictionary;
using Simon.Gameplay;
using UnityEngine;

namespace Simon.Core
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private SerializableDictionaryBase<LevelEnum, Level> _locations;
        [SerializeField] private Transform _mapsContainer;

        public void CreatLevel(LevelEnum location, Transform mainHero)
        {
            Instantiate(_locations[location], _mapsContainer).Init(mainHero);
        }
    }

    public enum LevelEnum
    {
        None,
        FirstLevel
    }
}