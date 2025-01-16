using System;
using Infrastructure;
using Inputs;
using Services;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Drifter _mover;
    private InputPause _inputPause;
    private WalletGamePlay _wallet;
    
    private Vector3 _startPosition;
    private Transform _transform;
    
    public event Action Destroyed;
    public event Action<int> Wins;
    
    public void Construct(WalletGamePlay wallet, InputPause inputPause, Vector3 startPosition)
    {
        //внести данные для дрифта(переменные) из конфигов при констракте
        _wallet = wallet;
        _inputPause = inputPause;
        _transform = transform;
        _startPosition = startPosition;

        _mover.Construct(_inputPause);
        transform.position = _startPosition;
    }

    public void Lose()
    {
        _inputPause.DeactivateInput();
        Destroyed?.Invoke();
    }

    public void Win()
    {
        _inputPause.DeactivateInput();
        Wins?.Invoke(_wallet.Value);
    }

    public void Continue()
    {
        transform.position = _startPosition;
        _mover.SetupContinue();
        _inputPause.ActivateInput();
    }
    
    public void Increase(int amount)
    {
        _wallet.Increase(amount);
    }
}