using UnityEngine;

namespace Simon.Configs
{
    [CreateAssetMenu(fileName = "Dialogue Character Config", menuName = "Configs/Dialogue Character Config")]
    public class DialogueCharacterConfig : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        public Sprite Sprite => _sprite;
        [SerializeField] private string _name;
        public string CharacterName => _name;
    }
}