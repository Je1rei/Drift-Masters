using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMover : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float rotationSpeed = 0.5f;
    [SerializeField] private Vector3 rotationAxis = Vector3.up; 

    private Transform _transform;
    private float _steerAngle = 360f ;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        ItemRotation();
    }

    private void ItemRotation()
    {
        _transform.Rotate(rotationAxis, rotationSpeed * _steerAngle * Time.deltaTime);
    }
}
