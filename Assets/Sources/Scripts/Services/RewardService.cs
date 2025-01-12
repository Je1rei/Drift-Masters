﻿using System;
using Infrastructure;
using UnityEngine;
using Zenject;

namespace Services
{
    public class RewardService
    {
        private Wallet _wallet;
    
        private LevelService _levelService;
    
        public event Action Rewarded;
        public event Action Losed;
        
        public RewardService(Wallet wallet, LevelService levelService)
        {
            _wallet = wallet;
            _levelService = levelService;
        }
    
        public void Reward(int value = 1)
        {
            _levelService.Complete();
            _wallet.Increase(value);
            Rewarded?.Invoke();
        }

        public void Lose() // подписать на методы проигрыша на карте и тд
        {
            Losed?.Invoke();
        }
    }
}