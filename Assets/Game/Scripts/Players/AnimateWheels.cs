using UnityEngine;
using Inputs;

namespace Players
{
    public class AnimateWheels : MonoBehaviour
    {
        private const float MinInputValue = 0.05f;

        [SerializeField] private InputHandler _inputHandler;

        [SerializeField] private float _speedMoveWheel = 1.5f;
        [SerializeField] private float _maxSteeringAngle = 50f;

        [Range(0, 5)] [SerializeField] private float _timeTrailDrift = 1f;
        [Range(0, 5)] [SerializeField] private float _timeTrailMove = 0.15f;
        [Range(1, 5)] [SerializeField] private float _sizeStepChangeTrails = 1.5f;

        private TrailRenderer[] _trailsRearWheel;
        private ParticleSystem[] _smokeRearWheel;
        private Wheel[] _frontWheels;
        private Wheel[] _rearWheels;

        private float _horizontalInput;

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

            AnimateTrails();
            AnimateSmoke();
        }

        private void Animate()
        {
            foreach (var wheel in _frontWheels)
            {
                SteerWheel(wheel);
            }

            foreach (var wheel in _rearWheels)
            {
                RotateWheel(wheel);
            }
        }

        private void RotateWheel(Wheel wheel)
        {
            wheel.transform.Rotate(Vector3.right, _speedMoveWheel);
        }

        private void SteerWheel(Wheel wheel)
        {
            float targetAngle = _horizontalInput * _maxSteeringAngle;
            wheel.transform.localRotation = Quaternion.identity;

            wheel.transform.RotateAround(wheel.transform.position, Vector3.up, targetAngle);
        }

        private void OnMoving(float input)
        {
            _horizontalInput = input;
        }

        private bool IsDrifting()
        {
            return Mathf.Abs(_horizontalInput) > MinInputValue;
        }

        private void AnimateTrails()
        {
            float targetTime = IsDrifting() ? _timeTrailDrift : _timeTrailMove;

            foreach (var trail in _trailsRearWheel)
            {
                trail.time = Mathf.Lerp(trail.time, targetTime, _sizeStepChangeTrails * Time.deltaTime);
            }
        }

        private void AnimateSmoke()
        {
            foreach (var smoke in _smokeRearWheel)
            {
                if (IsDrifting())
                {
                    if (!smoke.isPlaying)
                        smoke.Play();
                }
                else
                {
                    if (smoke.isPlaying)
                        smoke.Stop();
                }
            }
        }
    }
}