using RotaryHeart.Lib.SerializableDictionary;
using System;
using UnityEngine;

namespace Simon.Configs
{
    public class ScenarioConfig : MonoBehaviour
    {
        [SerializeField] private SerializableDictionaryBase<int, DayConfig> _dayConfigs;
    }

    [Serializable]
    public class DayConfig
    {
        
    }
}