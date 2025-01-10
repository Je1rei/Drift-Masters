using System;
using Infrastructure;
using UIView;
using UnityEngine;
using Zenject;

namespace Services
{
    public class ShopService : MonoBehaviour
    {
        [SerializeField] private ShopCell[] _shopCells;

        private Wallet _wallet;

        [Inject]
        private void Construct(Wallet wallet)
        {
            _wallet = wallet;
            
            foreach(ShopCell cell in _shopCells)
            {
                cell.Purchasing += Spend;
            }
        }

        private void Spend(int price)
        {
            bool isPurchased = _wallet.TrySpend(price);

            if (isPurchased)
            {
                Debug.Log("Purchased");
                //добавить что то как про сохранение уровней, чтобы по айди проверялось куплен предмет или нет
                //YG2.SaveProgress();
            }
        }

        // сюда добавить взаимодействие с ShopCell
    }
}