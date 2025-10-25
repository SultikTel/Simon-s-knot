using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace Simon.Gameplay
{
    public abstract class Level : MonoBehaviour
    {
        [SerializeField] protected SerializableDictionaryBase<int, Transform> _spawnPoints;
        [SerializeField] protected SerializableDictionaryBase<string, Interactable> _interactables;

        protected Transform _mainHero;

        public virtual void Init(Transform mainHero)
        {
            _mainHero = Instantiate(mainHero, transform);
        }
    }
}