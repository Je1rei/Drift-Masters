using System;
using UnityEngine;
using Zenject;

public class RewardService : MonoBehaviour
{
    private Wallet _wallet;
    
    private LevelService _levelService;
    
    public event Action Rewarded;
    public event Action Losed;

    [Inject]
    private void Construct(Wallet wallet, LevelService levelService)
    {
        _wallet = wallet;
        _levelService = levelService;
    }
    
    public void Reward()
    {
        _levelService.Complete();
        _wallet.Increase(1); // Value 
        Rewarded?.Invoke();
    }

    public void Lose() // подписать на методы проигрыша на карте и тд
    {
        Losed?.Invoke();
    }
}