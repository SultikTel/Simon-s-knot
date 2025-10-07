using Simon.Core;
using UnityEngine;

namespace Simon.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private BaseUIButton _newGameButton;
        [SerializeField] private BaseUIButton _optionsButton;
        [SerializeField] private BaseUIButton _exitButton;

        private void OnEnable()
        {
            _newGameButton.OnClicked.AddListener(() => {
                GameController.Instance.LoadDay(1);
                gameObject.SetActive(false);
            });
            _exitButton.OnClicked.AddListener(() => Debug.Log("Quit"));
        }

        private void OnDisable()
        {
            _newGameButton.OnClicked.RemoveAllListeners();
            _exitButton.OnClicked.RemoveAllListeners();
        }
    }
}