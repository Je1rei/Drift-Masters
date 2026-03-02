using Data;
using DG.Tweening;
using Inputs;
using Services;
using UnityEngine;

namespace Players
{
    public class Drifter : MonoBehaviour
    {
        private const float MinInputThreshold = 0.01f;

        [SerializeField] private InputHandler _inputHandler;
        [SerializeField] private float _durationToggleButtonsView = 1f;

        private float _horizontalInput;

        private float _moveSpeed;
        private float _steerAngle;
        private float _drag;
        private float _traction;

        private bool _isStarted;
        private Tween _toggleTween;

        private InputPause _inputPause;
        private TutorialService _tutorialService;

        private Vector3 _moveForce;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void OnEnable()
        {
            _isStarted = false;
            _inputHandler.Moving += OnMoving;
        }

        private void OnDisable()
        {
            _inputHandler.Moving -= OnMoving;
        }

        private void Update()
        {
            if (_tutorialService?.IsActive == true)
                return;

            HandleInputStart();

            if (_inputPause?.CanInput == true && _isStarted)
            {
                Move();
                Steer();
            }
        }

        private void OnDestroy()
        {
            _toggleTween.Kill();
        }

        public void Construct(TutorialService tutorialService, InputPause inputPause, DriftConfig config)
        {
            _tutorialService = tutorialService;
            _inputPause = inputPause;

            _transform = transform;
            _moveSpeed = config.MoveSpeed;
            _steerAngle = config.SteerAngle;
            _drag = config.Drag;
            _traction = config.Traction;
        }

        public void SetupContinue()
        {
            _moveForce = Vector3.zero;
            _horizontalInput = 0;
            _isStarted = false;
        }

        private void OnMoving(float input)
        {
            _horizontalInput = input;
        }

        private void HandleInputStart()
        {
            if (_isStarted || Mathf.Abs(_horizontalInput) <= MinInputThreshold)
                return;

            _inputPause?.ActivateInput();
            _isStarted = true;

            _toggleTween = DOVirtual.DelayedCall(
                _durationToggleButtonsView,
                () => _inputHandler?.ToggleButtonsView()
            );
        }

        private void Move()
        {
            _moveForce += _transform.forward * (_moveSpeed * Time.deltaTime);
            _transform.position += _moveForce * Time.deltaTime;

            _moveForce *= _drag;
            _moveForce = Vector3.ClampMagnitude(_moveForce, _moveSpeed);

            _moveForce = Vector3.Lerp(
                _moveForce.normalized,
                _transform.forward,
                _traction * Time.deltaTime
            ) * _moveForce.magnitude;
        }

        private void Steer()
        {
            float steerInput = _horizontalInput;
            _transform.Rotate(Vector3.up * (steerInput * _moveForce.magnitude * _steerAngle * Time.deltaTime));
        }
    }
}