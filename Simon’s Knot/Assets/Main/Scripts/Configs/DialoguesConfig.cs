using RotaryHeart.Lib.SerializableDictionary;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Simon.Configs
{
    [CreateAssetMenu(fileName = "Dialogues Config", menuName = "Configs/Dialogues")]
    public class DialoguesConfig : ScriptableObject
    {
        [SerializeField] private SerializableDictionaryBase<string, DialogueData> _allDialogues;
        public IDictionary<string, DialogueData> AllDialogues => _allDialogues;
    }

    [Serializable]
    public class DialogueData
    {
        [SerializeField] private List<DialogueEntryData> _dialogueEntries;
        public List<DialogueEntryData> DialogueEntries => _dialogueEntries;
    }
    [Serializable]
    public class DialogueEntryData
    {
        [SerializeField] private Character _character;
        public Character Character => _character;
        [SerializeField] private string _line;
        public string Line => _line;
    }
    public enum Character
    {
        None,
        Simon,
        Mother
    }
}