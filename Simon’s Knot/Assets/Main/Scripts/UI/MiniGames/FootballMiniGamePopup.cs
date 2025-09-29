using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simon.UI
{
    public class FootballMiniGamePopup : MonoBehaviour
    {
        [SerializeField] private Image _ball;
        [SerializeField] private List<IndexAndObject> _points;
        [SerializeField] private Image _arrow;
        [SerializeField] private TMP_Text _goalText;

        private Vector3 _startPosition;
        private Vector3 _startScale;
        private int _arrowDirection = 1;

        private void Start()
        {
            _startPosition = _ball.rectTransform.localPosition;
            _startScale = _ball.rectTransform.localScale;

            StartCoroutine(BallRoutine());
        }

        private void Update()
        {
            HandleArrowInput();
        }

        private void HandleArrowInput()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _arrow.rectTransform.localEulerAngles = new Vector3(0, 0, 90f);
                _arrowDirection = 0;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _arrow.rectTransform.localEulerAngles = new Vector3(0, 0, -90f);
                _arrowDirection = 2;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _arrow.rectTransform.localEulerAngles = Vector3.zero;
                _arrowDirection = 1;
            }
        }

        private IEnumerator BallRoutine()
        {
            while (true)
            {
                int randomIndex = UnityEngine.Random.Range(0, _points.Count);
                Vector3 targetPosition = _points[randomIndex].obj.transform.localPosition;

                Vector3 targetScale = _startScale * 0.8f;

                float duration = 2f;
                float t = 0f;

                while (t < duration)
                {
                    t += Time.deltaTime;
                    float progress = t / duration;

                    _ball.rectTransform.localPosition = Vector3.Lerp(_startPosition, targetPosition, progress);
                    _ball.rectTransform.localScale = Vector3.Lerp(_startScale, targetScale, progress);

                    yield return null;
                }

                // Проверяем попадание
                CheckGoal(randomIndex);

                // Возврат мяча
                _ball.rectTransform.localPosition = _startPosition;
                _ball.rectTransform.localScale = _startScale;

                yield return new WaitForSeconds(0.5f);
            }
        }

        private void CheckGoal(int targetIndex)
        {
            if (targetIndex == _arrowDirection)
            {
                _goalText.text = "GOAL!";
                _goalText.color = Color.green;
            }
            else
            {
                _goalText.text = "MISS!";
                _goalText.color = Color.red;
            }
        }
    }

    [Serializable]
    public class IndexAndObject
    {
        public int index;
        public GameObject obj;
    }
}