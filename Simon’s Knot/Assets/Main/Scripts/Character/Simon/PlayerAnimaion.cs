using Simon.Audio;
using UnityEngine;

namespace Simon.Gameplay.Player
{
    public class PlayerAnimaion : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            Vector2 velocity = _playerMovement.GoingDirection;

            if (velocity.sqrMagnitude < 0.1f)
            {
                _animator.Play("Idle");
                return;
            }

            if (Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y))
            {
                if (velocity.x > 0)
                    _animator.Play("RunRight");
                else
                    _animator.Play("RunLeft");
            }
            else
            {
                if (velocity.y > 0)
                    _animator.Play("RunUp");
                else
                    _animator.Play("RunDown");
            }
        }

        private void PlayStepSound()
        {
            AudioController.Instance.PlaySound(SoundName.Step);
        }
    }
}