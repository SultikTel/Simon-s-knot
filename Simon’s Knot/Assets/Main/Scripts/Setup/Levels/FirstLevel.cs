using Simon.Core;
using UnityEngine;

namespace Simon.Gameplay
{
    public class FirstLevel : Level
    {
        public override void Init(Transform mainHero)
        {
            base.Init(mainHero);

            _mainHero.position = _spawnPoints[1].position;

            _interactables["Bed"].OnInteracted = BedInteraction;
            _interactables["MainHallDoor"].OnInteracted = HallDoorInteraction;
            _interactables["SimonsRoomDoor"].OnInteracted = SimonRoomDoorInteraction;
            _interactables["Mother"].OnInteracted = TalkWithMom;
        }

        private void TalkWithMom()
        {
            if (GameController.Instance.CurrentProgress.HappenedGameEvents.Contains(GameEvent.TalkedWithMomOnDay1))
            {
                return;
            }
            GameController.Instance.DialogueController.ShowDialogue("MotherAndSimonFirstDay");
            GameController.Instance.CurrentProgress.HappenedGameEvents.Add(GameEvent.TalkedWithMomOnDay1);
        }

        private void HallDoorInteraction()
        {
            _mainHero.position = _interactables["SimonsRoomDoor"].transform.position;
        }

        private void SimonRoomDoorInteraction()
        {
            _mainHero.position = _interactables["MainHallDoor"].transform.position;
        }

        private void BedInteraction()
        {
            if (GameController.Instance.CurrentProgress.HappenedGameEvents.Contains(GameEvent.InteractedWithBedOnDay1Again))
            {
                return;
            }
            if (GameController.Instance.CurrentProgress.HappenedGameEvents.Contains(GameEvent.InteractedWithBedOnDay1))
            {
                GameController.Instance.DialogueController.ShowDialogue("FirstDayBedInteraction2");
                GameController.Instance.CurrentProgress.HappenedGameEvents.Add(GameEvent.InteractedWithBedOnDay1Again);
                return;
            }
            GameController.Instance.DialogueController.ShowDialogue("FirstDayBedInteraction");
            GameController.Instance.CurrentProgress.HappenedGameEvents.Add(GameEvent.InteractedWithBedOnDay1);
        }
    }
}