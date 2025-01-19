using Inputs;
using UnityEngine;

namespace Players
{
    public class NewDriftSystem : MonoBehaviour
    {
        [Space(10)] [SerializeField] private InputHandler _inputHandler;

        [Space(20)] [SerializeField] private float _moveSpeed = 35;
        [SerializeField] private float _speedMax = 25;
        [SerializeField] private float _steerAngle = 8;
        [SerializeField] private float _drag = 1;
        [SerializeField] private float _traction = 5;

        private Transform _transform;
        private float _horizontalInput;
        private Vector3 _moveForce;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

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
            Move();
            Steering();
            DrawDirections();
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

        private void OnMoving(float obj)
        {
            _horizontalInput = obj;
        }
    }
}