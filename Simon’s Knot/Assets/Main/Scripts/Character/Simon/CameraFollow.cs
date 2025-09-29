using UnityEngine;

namespace Simon.Gameplay.Player
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float _offset;
        private Transform _camera;

        private void Start()
        {
            _camera = Camera.main.transform;
        }

        private void LateUpdate()
        {
            _camera.position = new Vector3(transform.position.x,transform.position.y+ _offset, _camera.position.z);
        }
    }
}