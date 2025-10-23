using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace Simon.UI
{
    public class MiniGamesController : MonoBehaviour
    {
        public static MiniGamesController Instance;
        [SerializeField] private SerializableDictionaryBase<MiniGames, Transform> _miniGames;
        [SerializeField] private Transform _miniGamesContainer;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void OpenMiniGame(MiniGames miniGames)
        {
            foreach (Transform child in _miniGamesContainer)
            {
                Destroy(child.gameObject);
            }
            Instantiate(_miniGames[miniGames],_miniGamesContainer);
        }
    }

    public enum MiniGames
    {
        None,
        Football,
        SisterHold
    }
}