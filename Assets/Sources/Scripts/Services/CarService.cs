using System.Collections.Generic;
using Data;
using UnityEngine;
using YG;

namespace Services
{
    public class CarService : MonoBehaviour
    {
        [SerializeField] private CarData[] _cars;

        private CarData _current;
        private int _id;

        public int ID => _id;
        public CarData Current => _current;

        public void Load(int index)
        {
            if (index < 0 || index >= _cars.Length)
            {
                return;
            }

            _current = _cars[index];
            _id = index;
        }

        public List<Car> LoadOpenedCars()
        {
            List<Car> openedCars = new List<Car>();

            if (YG2.saves.OpenedCars != null)
            {
                foreach (int carId in YG2.saves.OpenedCars)
                {
                    if (carId >= 0 && carId < _cars.Length)
                    {
                        openedCars.Add(_cars[carId].CarViewPrefab);
                    }
                }
            }

            return openedCars;
        }
    }
}