using Simon.Configs;
using Simon.Gameplay;
using System.Collections.Generic;
using UnityEngine;

namespace Simon.Core
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;

        [SerializeField] private Transform _mainHero;
        [SerializeField] private LevelController _levelController;
        [SerializeField] private ConfigHolder _configHolder;

        private DialogueController _dialogueController;
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
            _dialogueController = new(_configHolder.DialoguesConfig.AllDialogues);
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


    public class DialogueController
    {
        private IDictionary<string, DialogueData> _allDialogues;
        private Dictionary<InteractableEnum, DialogueView> dialogueViews = new();
        public DialogueController(IDictionary<string, DialogueData> dialogues)
        {
            _allDialogues = dialogues;
        }
        public void AddDialogueParticipant(DialogueView dialogueView)
        {
            dialogueViews[dialogueView.Interactable] = dialogueView;
        }
    }
}