using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace Simon.Core
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private SerializableDictionaryBase<Locations, Location> _locations;

    }

    public enum Locations
    {
        None,
        SimonRoom
    }
}