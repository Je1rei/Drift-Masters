using System;
using System.Collections;
using System.Collections.Generic;
using Inputs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Drifter : MonoBehaviour
{
    [FormerlySerializedAs("_InputHandler")]
    [Space(10)]
    [SerializeField] private InputHandler _inputHandler;
    
    [Space(20)]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _speedMax;
    [SerializeField] private float _drag;
    [SerializeField] private float _steerAngle;
    [SerializeField] private float _traction;

    private bool _isStarted;
    private InputPause _inputPause;
    
    private Vector3 _moveForce;
    private Transform _transform;
    private float _horizontalInput;
    
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
        if (Mathf.Abs(_horizontalInput) > 0 && _isStarted == false)
        {
            _inputPause.ActivateInput();
            _isStarted = true;
        }
        
        if (_inputPause.CanInput && _isStarted == true)
        {
            Move();

            _transform.Rotate(Vector3.up * (_horizontalInput * _moveForce.magnitude * _steerAngle * Time.deltaTime));

            //_moveForce *= _drag;
            _moveForce = Vector3.ClampMagnitude(_moveForce, _speedMax);

            Debug.DrawRay(_transform.position, _moveForce.normalized * 3, Color.red);
            Debug.DrawRay(_transform.position, _transform.forward * 3, Color.blue);

            _moveForce = Vector3.Lerp(_moveForce.normalized, _transform.forward, _traction * Time.deltaTime)
                         * _moveForce.magnitude;
            /*_moveForce = Vector3.Lerp(_moveForce.normalized, new Vector3(0f,transform.eulerAngles.y+_traction,0f), _traction * Time.deltaTime)
             * _moveForce.magnitude;*/
        }
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
        _moveForce += _transform.forward * _moveSpeed;
        _transform.position += _moveForce * Time.deltaTime;
    }
}
