using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _scoreCount;
    
    private Vector3 _startPosition;
    private Transform _transform;
    
    public event Action Destroyed;
    
    public void Construct(Vector3 startPosition)
    {
        //mover.Construct();
        //внести данные для дрифта(переменные) из конфигов при констракте
        
        _transform = transform;
        _startPosition = startPosition;
        
        transform.position = _startPosition;
    }

    public void ResetPosition()
    {
        transform.position = _startPosition;
        Destroyed?.Invoke();
    }

    public void SetScore(int score)
    {
        _scoreCount+=score;
    }
}