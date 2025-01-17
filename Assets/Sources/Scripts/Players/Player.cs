using System;
using Data;
using DG.Tweening;
using Infrastructure;
using Inputs;
using Services;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Drifter _mover;

    private int _countAllItems;
    private int _countRequiredItems;
    private int _countCollected;
    private int _countAllCollected;

    private AudioService _audioService;
    private InputPause _inputPause;
    private WalletGamePlay _wallet;
    
    private Vector3 _startPosition;
    private Transform _transform;
    
    public event Action Destroyed;
    public event Action<int> Wins;
    public event Action PreparedWins;
    
    public void Construct(int countRequiredItems, int countAllItems, AudioService audioService, WalletGamePlay wallet, InputPause inputPause, Vector3 startPosition)
    {
        _audioService = audioService;
        _wallet = wallet;
        _inputPause = inputPause;
        _transform = transform;
        _startPosition = startPosition;

        _countAllItems = countAllItems;
        _countRequiredItems = countRequiredItems;
        _countCollected = 0;
        
        _mover.Construct(_inputPause);
        transform.position = _startPosition;
    }

    public void Lose()
    {
        _inputPause.DeactivateInput();
        
        if (_countCollected >= _countRequiredItems)
        {
            Wins?.Invoke(_wallet.Value);
        }
        else
        {
            Destroyed?.Invoke();
        }
    }

    public void Win()
    {
        if (_countCollected == _countRequiredItems)
        {
            PreparedWins?.Invoke();
        }
        
        if (_countCollected >= _countRequiredItems && _countAllCollected == _countAllItems)
        {
            _inputPause.DeactivateInput();
            Wins?.Invoke(_wallet.Value);
        }
    }

    public void Continue()
    {
        transform.position = _startPosition;
        _mover.SetupContinue();
        _inputPause.ActivateInput();
    }
    
    public void Increase(int amount, bool isRequiredItem)
    {
        _audioService.PlayOneShot();
        
        if (isRequiredItem)
        {
            _countCollected++;
        }

        _countAllCollected++;
        _wallet.Increase(amount);
    }
}