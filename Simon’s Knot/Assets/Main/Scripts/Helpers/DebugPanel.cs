using Simon.UI;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simon.Helpers
{
    public class DebugPanel : MonoBehaviour
    {
        [SerializeField] private SimpleDebugBlock _simpleDebugBlockPrefab;
        [SerializeField] private ComplexDebugBlock _complexDebugBlockPrefab;
        [SerializeField] private Transform _container;
        [SerializeField] private Button _showHideButton;
        [SerializeField] private TMP_Text _showHideButtonText;
        [SerializeField] private GameObject _scrolView;

        private void Awake()
        {
            CreateFunction("openFootBall", () => { MiniGamesController.Instance.OpenMiniGame(MiniGames.Football); });
            CreateFunction("openSisterMiniGame", () => { MiniGamesController.Instance.OpenMiniGame(MiniGames.SisterHold); });
            CreateFunction("complex", (a) => { Debug.Log(a); });
        }

        private void CreateFunction(string nameOfAction, Action actionToDo)
        {
            SimpleDebugBlock simpleDebugBlock = Instantiate(_simpleDebugBlockPrefab, _container);
            simpleDebugBlock.Init(nameOfAction, actionToDo);
        }
        private void CreateFunction(string nameOfAction, Action<string> actionToDo)
        {
            ComplexDebugBlock complexDebugBlock = Instantiate(_complexDebugBlockPrefab, _container);
            complexDebugBlock.Init(nameOfAction, actionToDo);
        }

        private void ShowOrHide(bool show)
        {
            _scrolView.SetActive(show);
            _showHideButtonText.text = show ? "hide" : "show";
        }

        private void OnEnable()
        {
            ShowOrHide(true);
            _showHideButton.onClick.AddListener(()=>ShowOrHide(!_scrolView.activeSelf));
        }
        private void OnDisable()
        {
            _showHideButton.onClick.RemoveAllListeners();
        }
    }
}