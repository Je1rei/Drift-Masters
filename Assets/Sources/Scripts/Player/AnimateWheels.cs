using UnityEngine;
using Inputs;

namespace Players
{
    public class AnimateWheels : MonoBehaviour
    {
        [SerializeField] private InputHandler _inputHandler;
        [Space(10)] [SerializeField] private Wheel[] _frontWheels;
        [SerializeField] private Wheel[] _rearWheels;
        [Space(10)] [SerializeField] private float _speedMoveWheel = 1.5f;
        [SerializeField] private float _maxSteeringAngle = 30f;

        private float _horizontalInput;

        private void OnEnable()
        {
            _inputHandler.Moving += OnMoving;
        }

        private void OnDisable()
        {
            _inputHandler.Moving -= OnMoving;
        }

        private void Update()
        {
            Animate();
        }

        private void Animate()
        {
            foreach (var wheel in _frontWheels)
            {
                SteerWheel(wheel);
            }

            foreach (var wheel in _rearWheels)
            {
                MoveWheel(wheel);
            }
        }

        private void MoveWheel(Wheel wheel)
        {
            wheel.transform.Rotate(Vector3.right, _speedMoveWheel);
        }

        private void SteerWheel(Wheel wheel)
        {
            float targetAngle = _horizontalInput * _maxSteeringAngle;
            wheel.transform.localRotation = Quaternion.identity;

            wheel.transform.RotateAround(wheel.transform.position, Vector3.up, targetAngle);
        }

        private void OnMoving(float obj)
        {
            _horizontalInput = obj;
        }
    }
}