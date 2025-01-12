using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _scoreCount;
    
    private Vector3 _startPosition;
    private Transform _transform;
    
    public event Action PlayerDestroyed;

    private void Awake()
    {
        _transform = transform;
        _startPosition = transform.position;
    }

    public void ResetPosition()
    {
        transform.position = _startPosition;
        PlayerDestroyed?.Invoke();
    }

    public void SetScore(int score)
    {
        _scoreCount+=score;
    }
}
