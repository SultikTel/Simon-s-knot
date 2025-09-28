using UnityEngine;

namespace Simon.Audio
{
    public class AudioController : MonoBehaviour
    {
        public static AudioController Instance;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}