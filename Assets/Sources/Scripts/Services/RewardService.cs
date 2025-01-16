﻿using System;
using Infrastructure;
using UnityEngine;
using YG;
using Zenject;

namespace Services
{
    public class RewardService : IDisposable
    {
        private const string RewardID = "1";

        private int _multiplierReward = 2;
        private int _lastReward;
        
        private Player _player;
        private Wallet _wallet;
        private LevelService _levelService;
    
        public event Action Rewarded;
        public event Action Losed;
        
        public void Construct(Player player, Wallet wallet, LevelService levelService)
        {
            _lastReward = 0;
            _player = player;
            _wallet = wallet;
            _levelService = levelService;
            
            _player.Destroyed += Lost;
            _player.Wins += Reward;
        }
    
        public void Dispose()
        {
            _player.Destroyed -= Lost;
            _player.Wins -= Reward;
        }
        
        public void Continue()
        {
            _player.Continue();
        }
        
        public void RewardAd()
        {
            YG2.RewardedAdvShow(RewardID, () =>
            {
                Reward(_lastReward * _multiplierReward);
            });
        }
        
        private void Reward(int value = 1)
        {
            _lastReward = value;
            _levelService.Complete();
            _wallet.Increase(value);

            Rewarded?.Invoke();
        }

        private void Lost()
        {
            Losed?.Invoke();
        }
    }
}