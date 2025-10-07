using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace Simon.Core
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private SerializableDictionaryBase<Locations, Location> _locations;
        [SerializeField] private Transform _mapsContainer;

        public void CreatLevel(Locations location)
        {
            Instantiate(_locations[location], _mapsContainer);
        }
    }

    public enum Locations
    {
        None,
        SimonRoom
    }
}