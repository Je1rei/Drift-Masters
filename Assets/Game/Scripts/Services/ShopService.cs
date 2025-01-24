using Infrastructure;
using UIView;
using UnityEngine;
using YG;

namespace Services
{
    public class ShopService : MonoBehaviour
    {
        private ShopCell[] _shopCells;
        private Wallet _wallet;
        private CarService _carService;
        
        private void OnDisable()
        {
            if (_shopCells == null) return;
            
            foreach (ShopCell cell in _shopCells)
            {
                cell.Purchasing -= HandlePurchase;
            }
        }
        
        public void Construct(AudioService audioService, CarService carService, Wallet wallet, ShopCell[] shopCells)
        {
            _carService = carService;
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
                    cell.Purchasing += HandlePurchase;
                }
            }
        }

        private void HandlePurchase(int price, ShopCell cell)
        {
            bool isPurchased = _wallet.TrySpend(price);
            
            if (isPurchased)
            {
                int carId = cell.ItemData.ID;

                YG2.saves.OpenedCars.Add(carId);
                YG2.saves.Coins -= price;
                YG2.SaveProgress();

                cell.SetPurchasedState();
                
                _carService.AddCar(carId);
            }
        }
    }
}