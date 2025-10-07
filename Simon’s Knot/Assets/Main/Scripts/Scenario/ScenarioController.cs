using UnityEngine;

namespace Simon.Scenario
{
    public class ScenarioController : MonoBehaviour
    {
        public ScenarioController Instance;

        private void Awake()
        {
            if (Instance==null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }
    }

    public enum Events
    {
        None,
        TalkedToMom
    }
}