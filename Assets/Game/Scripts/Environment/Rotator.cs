using UnityEngine;

namespace Environment
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField, Range(0f, 1f)] private float rotationSpeed = 0.5f;
        [SerializeField] private Vector3 rotationAxis = Vector3.up;

        private Transform _transform;
        private readonly float _steerAngle = 360f;

        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            _transform.Rotate(rotationAxis, rotationSpeed * _steerAngle * Time.deltaTime);
        }
    }
}