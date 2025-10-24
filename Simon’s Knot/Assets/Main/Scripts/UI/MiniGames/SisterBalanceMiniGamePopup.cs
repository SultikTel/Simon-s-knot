using UnityEngine;
using UnityEngine.UI;

namespace Simon.UI
{
    public class SisterBalanceMiniGamePopup : MonoBehaviour
    {
        [Header("Accept Zone Settings")]
        [SerializeField] private RectTransform _acceptZone;
        [SerializeField] private float _speed;
        [SerializeField] private float _changeDirSmooth;

        [Header("Player Settings")]
        [SerializeField] private RectTransform _currentPlayerIndex;
        [SerializeField] private float _playerSpeed;
        [SerializeField] private Image _accepImage;

        private RectTransform _parent;
        private Vector2 _direction;

        private void Start()
        {
            _parent = _acceptZone.parent as RectTransform;
            _direction = Random.insideUnitCircle.normalized;
        }

        private void Update()
        {
            MoveAcceptZone();
            MovePlayer();
            CheckOverlap();
        }

        private void MoveAcceptZone()
        {
            Vector2 randomChange = Random.insideUnitCircle * 0.5f;
            _direction += randomChange * Time.deltaTime * _changeDirSmooth;
            _direction = _direction.normalized;

            Vector2 newPos = _acceptZone.anchoredPosition + _direction * _speed * Time.deltaTime;

            Vector2 parentSize = _parent.rect.size;
            Vector2 zoneSize = _acceptZone.rect.size;

            float halfW = (parentSize.x - zoneSize.x) / 2f;
            float halfH = (parentSize.y - zoneSize.y) / 2f;

            bool hitX = false, hitY = false;
            if (newPos.x > halfW) { newPos.x = halfW; hitX = true; }
            if (newPos.x < -halfW) { newPos.x = -halfW; hitX = true; }
            if (newPos.y > halfH) { newPos.y = halfH; hitY = true; }
            if (newPos.y < -halfH) { newPos.y = -halfH; hitY = true; }

            if (hitX) _direction.x *= -1;
            if (hitY) _direction.y *= -1;

            _acceptZone.anchoredPosition = newPos;
        }

        private void MovePlayer()
        {
            if (_currentPlayerIndex == null)
                return;

            float input = Input.GetAxisRaw("Horizontal"); 
            Vector2 pos = _currentPlayerIndex.anchoredPosition;
            pos.x += input * _playerSpeed * Time.deltaTime;

            // ограничение по краям
            Vector2 parentSize = _parent.rect.size;
            Vector2 playerSize = _currentPlayerIndex.rect.size;

            float halfW = (parentSize.x - playerSize.x) / 2f;
            pos.x = Mathf.Clamp(pos.x, -halfW, halfW);

            _currentPlayerIndex.anchoredPosition = pos;
        }

        private void CheckOverlap()
        {
            if (_accepImage == null || _acceptZone == null || _currentPlayerIndex == null)
                return;

            Rect rectA = GetWorldRect(_acceptZone);
            Rect rectB = GetWorldRect(_currentPlayerIndex);

            bool isOverlapping = rectA.Overlaps(rectB);

            _accepImage.color = isOverlapping ? Color.green : Color.red;
        }

        private Rect GetWorldRect(RectTransform rt)
        {
            Vector3[] corners = new Vector3[4];
            rt.GetWorldCorners(corners);
            Vector3 bottomLeft = corners[0];
            Vector3 topRight = corners[2];
            return new Rect(bottomLeft, topRight - bottomLeft);
        }
    }
}