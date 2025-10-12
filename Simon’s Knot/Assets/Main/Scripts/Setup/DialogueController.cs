using Simon.Configs;
using Simon.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simon.Core
{
    public class DialogueController : MonoBehaviour
    {
        [SerializeField] private RectTransform _dialoguesHolder;
        [SerializeField] private DialogueBox _dialogueBox;
        private IDictionary<string, DialogueData> _allDialogues;
        private DialogueBox _current;
        private Coroutine _dialogueRoutine;
        public void Init(IDictionary<string, DialogueData> dialogues)
        {
            _allDialogues = dialogues;
        }

        public void ShowDialogue(string id)
        {
            if (!_allDialogues.ContainsKey(id))
            {
                Debug.LogWarning($"Dialogue with id '{id}' not found.");
                return;
            }

            if (_dialogueRoutine != null)
                StopCoroutine(_dialogueRoutine);

            if (_current == null)
                _current = Instantiate(_dialogueBox, _dialoguesHolder);

            _dialogueRoutine = StartCoroutine(PlayDialogue(_allDialogues[id]));
        }

        private IEnumerator PlayDialogue(DialogueData dialogue)
        {
            foreach (var entry in dialogue.DialogueEntries)
            {
                _current.Init(entry);
                yield return new WaitForSeconds(4f); 
            }

            Destroy(_current.gameObject);
            _current = null;
        }
    }
}