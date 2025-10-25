using RotaryHeart.Lib.SerializableDictionary;
using Simon.Configs;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simon.Gameplay
{
    public class DialogueBox : MonoBehaviour
    {
        [SerializeField] private SerializableDictionaryBase<Side, Image> _avatars;
        [SerializeField] private TMP_Text _mainText;
        [SerializeField] private TMP_Text _characterName;

        public void Init(DialogueEntryData dialogueEntryData)
        {
            foreach (KeyValuePair<Side, Image> item in _avatars)
            {
                if (item.Key == dialogueEntryData.Side)
                {
                    item.Value.enabled = true;
                    item.Value.sprite = dialogueEntryData.Character.Sprite;
                }
                else
                {
                    item.Value.enabled = false;
                }
            }

            _characterName.text = dialogueEntryData.Character.CharacterName;
            _mainText.text = dialogueEntryData.Line;
        }
    }
}