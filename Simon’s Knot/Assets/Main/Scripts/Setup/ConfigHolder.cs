using UnityEngine;

namespace Simon.Configs
{
    public class ConfigHolder : MonoBehaviour
    {
        [SerializeField] private DialoguesConfig _dialoguesConfig;
        public DialoguesConfig DialoguesConfig => _dialoguesConfig;
    }
}