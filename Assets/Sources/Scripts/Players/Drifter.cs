using DG.Tweening;
using Inputs;
using UnityEngine;
using UnityEngine.Serialization;

namespace Players
{
    public class Drifter : MonoBehaviour
    {
        [FormerlySerializedAs("_InputHandler")] [Space(10)] [SerializeField]
        private InputHandler _inputHandler;

        [SerializeField] private float _durationToggleButtonsView = 1f;
        [Space(20)] private float _moveSpeed = 35;
        private float _speedMax = 25;
        private float _steerAngle = 8;
        private float _drag = 1;
        private float _traction = 5;

        private bool _isStarted;
        private InputPause _inputPause;

        private Tween _tween;

        private Vector3 _moveForce;
        private Rigidbody _rigidbody;
        private Transform _transform;
        private float _horizontalInput;

        private void Awake()
        {
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

        private void OnDestroy()
        {
            _tween.Kill();
        }

        public void Construct(InputPause inputPause)
        {
            _inputPause = inputPause;
            _transform = transform;
        }

        public void SetupContinue()
        {
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