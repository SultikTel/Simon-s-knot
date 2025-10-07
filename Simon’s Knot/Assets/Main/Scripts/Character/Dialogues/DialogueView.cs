using Simon.Configs;
using Simon.Core;
using UnityEngine;

namespace Simon.Gameplay
{
    public class DialogueView : MonoBehaviour
    {
        [SerializeField] private InteractableEnum _interactable;
        public InteractableEnum Interactable => _interactable;
        [SerializeField] private DialogueBox _box;

        private void OnEnable()
        {
            GameController.Instance.DialogueController.AddDialogueParticipant(this);
            _box.gameObject.SetActive(false);
        }
    }
}