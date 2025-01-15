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
    
    private Vector3 _moveForce;
    private Transform _transform;
    private float _horizontalInput;

    private void Awake()
    {
        _transform = transform;
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
