using System;
using UnityEngine;

namespace Simon.Gameplay
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] private GameObject _callOut;
        private bool _canInteractNow;

        public Action OnInteracted;

        private void Start()
        {
            _callOut.SetActive(false);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.E) && _canInteractNow)
            {
                Debug.Log("interacted");
                OnInteracted?.Invoke();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _callOut.SetActive(true);
            _canInteractNow = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _callOut.SetActive(false);
            _canInteractNow = false;
        }
    }
}