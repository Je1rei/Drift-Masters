using System;
using Infrastructure;
using UnityEngine;
using YG;

namespace Services
{
    public class RewardService : MonoBehaviour
    {
        private const string RewardID = "1";

        private int _multiplierReward = 2;
        private int _lastReward;

        private Player _player;
        private Wallet _wallet;
        private LevelService _levelService;

        public event Action PreparedRewarded;
        public event Action<int, bool> Rewarded;
        public event Action Losed;

        public void Construct(Player player, Wallet wallet, LevelService levelService)
        {
            _lastReward = 0;
            _player = player;
            _wallet = wallet;
            _levelService = levelService;

            _player.Destroyed += Lost;
            _player.Wins += Reward;
            _player.PreparedWins += PreparedReward;
        }

        public void OnDisable()
        {
            if (_player != null)
            {
                _player.Destroyed -= Lost;
                _player.Wins -= Reward;
                _player.PreparedWins -= PreparedReward;
            }
        }

        public void Continue()
        {
            _player.Continue();
        }

        public void RewardAd(int value)
        {
            YG2.RewardedAdvShow(RewardID, () =>
            {
                _wallet.Increase(value);
                Debug.Log(value);
            });
        }

        // private void Reward(int value)
        // {
        //     _wallet.Increase(_lastReward);
        //
        //     Rewarded?.Invoke(_lastReward, true);
        // }

        private void Reward(int value)
        {
            _lastReward = value;
            _wallet.Increase(value);

            _levelService.Complete();

            Rewarded?.Invoke(_lastReward, false);
        }

        private void PreparedReward()
        {
            PreparedRewarded?.Invoke();
        }

        private void Lost()
        {
            Losed?.Invoke();
        }
    }
}