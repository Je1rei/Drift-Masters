using Data;
using DG.Tweening;
using Inputs;
using Services;
using UnityEngine; 

namespace Players
{
    public class Drifter : MonoBehaviour
    {
        [SerializeField] private InputHandler _inputHandler;
        [SerializeField] private float _durationToggleButtonsView = 1f;
        
        private float _horizontalInput;
        
        private float _moveSpeed;
        private float _speedMax;
        private float _steerAngle;
        private float _drag;
        private float _traction;

        private bool _isStarted;

        private Tween _tween;
        private InputPause _inputPause;
        private TutorialService _tutorialService;
        
        private Vector3 _moveForce;
        private Rigidbody _rigidbody;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody>();
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
            if (_tutorialService.IsActive == false)
            {
                DrawDirections();

                if (Mathf.Abs(_horizontalInput) > 0 && _isStarted == false)
                {
                    _inputPause.ActivateInput();
                    _isStarted = true;

                    _tween = DOVirtual.DelayedCall(_durationToggleButtonsView,
                        () => { _inputHandler.ToggleButtonsView(); });
                }

                if (_inputPause.CanInput && _isStarted == true)
                {
                    Move();
                    Steering();
                }
            }
        }

        private void OnDestroy()
        {
            _tween.Kill();
        }

        public void Construct(TutorialService tutorialService, InputPause inputPause, DriftConfig config)
        {
            _tutorialService = tutorialService;
            _inputPause = inputPause;
            _transform = transform;

            _moveSpeed = config.MoveSpeed;
            _speedMax = config.MaxSpeed;
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

        private void OnMoving(float obj)
        {
            _horizontalInput = obj;
        }

        private void Move()
        {
            _moveForce += _transform.forward * (_moveSpeed * Time.deltaTime);
            _transform.position += _moveForce * Time.deltaTime;

            _moveForce *= _drag;
            _moveForce = Vector3.ClampMagnitude(_moveForce, _moveSpeed);

            _moveForce = Vector3.Lerp(_moveForce.normalized, _transform.forward, _traction * Time.deltaTime) *
                         _moveForce.magnitude;
        }

        private void Steering()
        {
            float steerInput = _horizontalInput;
            transform.Rotate(Vector3.up * (steerInput * _moveForce.magnitude * _steerAngle * Time.deltaTime));
        }

        private void DrawDirections()
        {
            Debug.DrawRay(_transform.position, _moveForce.normalized * 10f, Color.green);
            Debug.DrawRay(_transform.position, _transform.forward * 10, Color.blue);
        }
    }
}