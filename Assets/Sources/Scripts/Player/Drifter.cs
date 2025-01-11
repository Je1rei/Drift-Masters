using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Drifter : MonoBehaviour
{
    [Space(10)]
    [SerializeField] private PlayerInputController _playerInputController;
    
    [Space(20)]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _speedMax;
    [SerializeField] private float _drag;
    [SerializeField] private float _steerAngle;
    [SerializeField] private float _traction;
    
    private Vector3 _moveForce;
    private Transform _transform;
    private float _horizontalInput;

    private void Awake()
    {
        _transform = transform;
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
        _moveForce += _transform.forward * _moveSpeed;
        transform.position += _moveForce * Time.deltaTime;
        
        _transform.Rotate(Vector3.up * _horizontalInput * _moveForce.magnitude * _steerAngle * Time.deltaTime);

        _moveForce *= _drag;
        _moveForce = Vector3.ClampMagnitude(_moveForce, _speedMax);
        
        _moveForce = Vector3.Lerp(_moveForce.normalized, _transform.forward, Time.deltaTime * _traction)
                     * _moveForce.magnitude;
    }
    
    private void OnMoved(float obj)
    {
        _horizontalInput = obj;
    }
}
