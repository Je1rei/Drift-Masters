using System;
using UnityEngine;
using Inputs;

namespace Players
{
    public class AnimateWheels : MonoBehaviour
    {
        [SerializeField] private InputHandler _inputHandler;
        [Space(10)] [SerializeField] private float _speedMoveWheel = 1.5f;
        [SerializeField] private float _maxSteeringAngle = 50f;

        [Space(10)] [Range(0, 5)] [SerializeField]
        private float _timeTrailDrift = 1f;

        [Range(0, 5)] [SerializeField] private float _timeTrailMove = 0.15f;
        [Range(1, 5)] [SerializeField] private float _sizeStepChangeTrails = 1.5f;

        private TrailRenderer[] _trailsRearWheel;
        private ParticleSystem[] _smokeRearWheel;
        private Wheel[] _frontWheels;
        private Wheel[] _rearWheels;
        private float _horizontalInput;
        private float _minimumInputValue = 0.05f;

        private void OnEnable()
        {
            _inputHandler.Moving += OnMoving;
        }

        private void OnDisable()
        {
            _inputHandler.Moving -= OnMoving;
        }

        public void Construct(Car car)
        {
            _frontWheels = car.FrontWheels;
            _rearWheels = car.RearWheels;
            _trailsRearWheel = car.TrailsRearWheel;
            _smokeRearWheel = car.SmokeRearWheel;
        }

        private void Update()
        {
            Animate();

            TrailAnimate();
            SmokeAnimate();
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

        private void TrailAnimate()
        {
            if (TryRotationValue())
            {
                SetTreilsTime(_timeTrailDrift);
            }
            else
            {
                SetTreilsTime(_timeTrailMove);
            }
        }

        private void SmokeAnimate()
        {
            foreach (var smoke in _smokeRearWheel)
            {
                if (TryRotationValue() && smoke.isPlaying == false)
                {
                    smoke.Play();
                }
                else
                {
                    smoke.Pause();
                }
            }
        }

        private bool TryRotationValue()
        {
            if (_horizontalInput > _minimumInputValue || _horizontalInput < -_minimumInputValue)
            {
                return true;
            }

            return false;
        }

        private void SetTreilsTime(float time)
        {
            foreach (var trail in _trailsRearWheel)
            {
                trail.time = Mathf.Lerp(trail.time, time, _sizeStepChangeTrails * Time.deltaTime);
            }
        }
    }
}