using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simon.Helpers
{
    public class SimpleDebugBlock : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _actionName;
        public void Init(string actionName, Action action)
        {
            _actionName.text = actionName;
            _button.onClick.AddListener(()=> { action?.Invoke(); });
        }
    }
}