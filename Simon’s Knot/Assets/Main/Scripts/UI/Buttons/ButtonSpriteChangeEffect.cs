using UnityEngine;
using UnityEngine.UI;

namespace Simon.UI
{
    public class ButtonSpriteChangeEffect : MonoBehaviour, IButtonEffect
    {
        private Image targetImage;
        [SerializeField] private Sprite normalSprite;
        [SerializeField] private Sprite hoverSprite;
        [SerializeField] private Sprite pressedSprite;

        private void Awake()
        {
            targetImage = GetComponent<Image>();
        }

        public void OnHoverEnter() => ApplySprite(hoverSprite);
        public void OnHoverExit() => ApplySprite(normalSprite);
        public void OnPressed() => ApplySprite(pressedSprite);
        public void OnClick() => ApplySprite(hoverSprite);

        private void ApplySprite(Sprite sprite)
        {
            if (targetImage == null) return;
            targetImage.sprite = sprite;
            Color color = targetImage.color;
            color.a = (sprite == null) ? 0f : 1f;
            targetImage.color = color;
        }
    }
}