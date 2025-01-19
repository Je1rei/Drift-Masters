using System;
using Unity.VisualScripting;
using UnityEngine;

namespace ObjectInGame
{
    public class ItemRotator : MonoBehaviour
    {
        [Range(0f, 1f)]
        [SerializeField]private float rotationSpeed = 0.5f; 
        [SerializeField] private Vector3 rotationAxis = Vector3.up; 
        
        private Transform _transform;
        private float _rotationDegrees = 360f;

        private void Awake()
        {
            _transform = transform; 
        }

        private void Update()
        {
            RotateItem();
        }

        private void RotateItem()
        {
            _transform.Rotate(rotationAxis, rotationSpeed * _rotationDegrees * Time.deltaTime);
        }
    }
}