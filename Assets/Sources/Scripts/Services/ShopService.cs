using System;
using Infrastructure;
using UIView;
using UnityEngine;
using YG;
using Zenject;

namespace Services
{
    public class ShopService : MonoBehaviour
    {
        private ShopCell[] _shopCells;
        private Wallet _wallet;

        public void Construct(AudioService audioService, Wallet wallet, ShopCell[] shopCells)
        {
            _wallet = wallet;
            _shopCells = shopCells;

            foreach (ShopCell cell in _shopCells)
            {
                cell.Construct(audioService);
                
                if (YG2.saves.OpenedCars.Contains(cell.ItemData.ID))
                {
                    cell.SetPurchasedState();
                }
                else
                {
                    cell.Purchasing += Spend;
                }
            }
        }

        private void Spend(int price, ShopCell cell)
        {
            bool isPurchased = _wallet.TrySpend(price);

            if (isPurchased)
            {
                Debug.Log("Purchased");
                
                YG2.saves.OpenedCars.Add(cell.ItemData.ID);
                YG2.SaveProgress();

                cell.SetPurchasedState();
            }
        }
    }
}