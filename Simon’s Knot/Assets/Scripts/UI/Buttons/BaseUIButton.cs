using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Simon.UI
{
    public class BaseUIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerClickHandler
    {
        private List<IButtonEffect> _effects;

        [SerializeField] private bool interactable = true;
        public bool IsInteractable => interactable;

        [Header("Events")]
        public UnityEvent OnClicked;
        public UnityEvent OnPressed;
        public UnityEvent OnHoveredEnter;
        public UnityEvent OnHoveredExit;

        private void Awake()
        {
            _effects = new List<IButtonEffect>(GetComponents<IButtonEffect>());
        }

        private void OnEnable()
        {
            RestoreToDefaultState();
        }

        public void SetInteractable(bool value)
        {
            interactable = value;
        }

        private void RestoreToDefaultState()
        {
            if (!interactable) return;
            foreach (IButtonEffect effect in _effects)
                effect.OnHoverExit();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!interactable) return;

            foreach (IButtonEffect effect in _effects)
                effect.OnHoverEnter();

            OnHoveredEnter?.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!interactable) return;

            foreach (IButtonEffect effect in _effects)
                effect.OnHoverExit();

            OnHoveredExit?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!interactable) return;

            foreach (IButtonEffect effect in _effects)
                effect.OnPressed();

            OnPressed?.Invoke();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!interactable) return;

            foreach (IButtonEffect effect in _effects)
                effect.OnClick();

            OnClicked?.Invoke();
        }
    }

    public interface IButtonEffect
    {
        public void OnHoverEnter();
        public void OnHoverExit();
        public void OnPressed();
        public void OnClick();
    }
}