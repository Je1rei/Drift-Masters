using System;
using UnityEngine;
using YG;
using Zenject;

namespace Infrastructure
{
    public class Wallet : BaseWallet
    {
        public override void Increase(int amount)
        {
            base.Increase(amount);
            YG2.saves.Coins = Value;
            
            //YG2.SetLeaderboard(nameLB: "Score", score: YG2.saves.Coins);
            YG2.SaveProgress();
        }
    }
}