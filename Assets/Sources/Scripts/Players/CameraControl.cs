using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _speedFollowing = 0.5f;
    [SerializeField] private float _offsetZ = 0.5f;
    [SerializeField] private float _offsetX = 0.5f;

    private Vector3 _startPosition;
    private Transform _transform;
    private float _cameraPositionY;

    private void Awake()
    {
        _transform = transform;
        _cameraPositionY = _transform.position.y;
    }

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        _transform.position = Vector3.Lerp(new Vector3(_transform.position.x, _cameraPositionY, _transform.position.z),
            new Vector3(_target.transform.position.x, _cameraPositionY, _target.transform.position.z + _offsetZ),
            Time.deltaTime * _speedFollowing);
    }
}