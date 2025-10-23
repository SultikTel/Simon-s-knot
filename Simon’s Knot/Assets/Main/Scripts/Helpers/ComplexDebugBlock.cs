using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simon.Helpers
{
    public class ComplexDebugBlock : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _actionName;
        [SerializeField] private TMP_InputField _inputField;
        public void Init(string actionName, Action<string> action)
        {
            _actionName.text = actionName;
            _button.onClick.AddListener(() => action?.Invoke(_inputField.text));
        }
    }
}