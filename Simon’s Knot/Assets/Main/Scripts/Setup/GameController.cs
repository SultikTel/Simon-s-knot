using Simon.Configs;
using UnityEngine;

namespace Simon.Core
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;

        [SerializeField] private Transform _mainHero;
        [SerializeField] private LevelController _levelController;
        [SerializeField] private ConfigHolder _configHolder;
        [SerializeField] private DialogueController _dialogueController;
        public DialogueController DialogueController => _dialogueController;
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
            _dialogueController.Init(_configHolder.DialoguesConfig.AllDialogues);
            _dialogueController.ShowDialogue("MotherAndSimonFirstDay");
        }

        public void LoadDay(int day)
        {
            if (day == 1)
            {
                Instantiate(_mainHero);
                _levelController.CreatLevel(Locations.SimonRoom);

            }
        }
    }
}