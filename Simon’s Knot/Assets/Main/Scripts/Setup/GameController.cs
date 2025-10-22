using Simon.Configs;
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
        [SerializeField] private DialogueController _dialogueController;
        public DialogueController DialogueController => _dialogueController;
        public Progress CurrentProgress { get; private set; } = new();
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
        }

        public void LoadDay(int day)
        {
            if (day == 1)
            {
                _levelController.CreatLevel(LevelEnum.FirstLevel, _mainHero);
            }
        }
    }

    public class Progress
    {
        public HashSet<GameEvent> HappenedGameEvents { get; private set; } = new();
        public void EventHappened(GameEvent happenedEvent)
        {
            HappenedGameEvents.Add(happenedEvent);
        }
    }

    public enum GameEvent
    {
        None,
        InteractedWithBedOnDay1,
        InteractedWithBedOnDay1Again,
        TalkedWithMomOnDay1
    }
}