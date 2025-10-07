using UnityEngine;

namespace Simon.Core
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;

        [SerializeField] private Transform _mainHero;
        [SerializeField] private LevelController _levelController;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void LoadDay(int day)
        {
            if (day == 1)
            {

            }
        }
    }
}