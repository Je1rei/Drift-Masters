using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Space(10)]
    [SerializeField] private PlayerInputController _playerInputController;
    
    [Space(20)]
    [SerializeField] private Transform _axisRotationDrift; 
    [SerializeField] private float _moveSpeed = 5f; 
    [SerializeField] private float _rotationSpeed = 50f; 
    [SerializeField] private float _multiplierSpeedWhenRotation = 0.5f;
    
    [Space(20)]
    [SerializeField] private TrailRenderer _rlwTireSkid;
    [SerializeField] private TrailRenderer _rrwTireSkid;


    private readonly Vector3 _moveDirection = Vector3.forward; 
    private float _horizontalInput;
    private Transform _transform;
    private Vector3 _moveForce;
    
    private void Awake()
    {
        _transform = transform;
        
        if (_axisRotationDrift == null)
        {
            Debug.LogError("The rotation point is not specified!");
        }
    }
    
    private void OnEnable()
    {
        _playerInputController.Moved += OnMoved;
    }

    private void OnDisable()
    {
        _playerInputController.Moved -= OnMoved;
    }

    private void Update()
    {
        
        HandleInput();
    }
    
    
    private void OnMoved(float obj)
    {
        _horizontalInput = obj;
    }

    private void HandleInput()
    {
        MoveForward();
        
        if (Mathf.Abs(_horizontalInput) != 0.1f)
        {
            MoveForward(_multiplierSpeedWhenRotation);
            RotateObjectAroundPoint(_horizontalInput, _axisRotationDrift.position);
        }
    }

    private void MoveForward(float multiplier = 1)
    {
        float currentSpeed = _moveSpeed * multiplier;

        transform.Translate(_moveDirection * currentSpeed);
    }
    
    private void RotateObjectAroundPoint(float angle, Vector3 axis)
    {
        if (Mathf.Abs(angle) > 0.1f)
        {
            _transform.RotateAround(axis, Vector3.up, angle * _rotationSpeed *  Time.deltaTime);
            
            _transform.Rotate(Vector3.up, angle * _rotationSpeed *  Time.deltaTime);
            
            _rlwTireSkid.emitting = true;
            _rrwTireSkid.emitting = true;
        }
    }
}
