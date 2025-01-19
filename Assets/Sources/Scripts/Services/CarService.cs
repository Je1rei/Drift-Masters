using System;
using System.Collections.Generic;
using Data;
using Players;
using UnityEngine;
using YG;

namespace Services
{
    public class CarService : MonoBehaviour
    {
        [SerializeField] private CarData[] _cars;

        private Target _target;
        private CarData _current;
        private int _id;

        public event Action<Car> Added;
        
        public int ID => _id;
        public CarData Current => _current;
        
        public void Construct(Target target)
        {
            _target = target;
            CreateCars();
        }
        
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
        
        public void CreateCars()
        {
            CarFactory carFactory = new CarFactory();
            List<Car> openedCars = LoadOpenedCars();

            foreach (Car car in openedCars)
            {
                bool carExists = false;
                foreach (Transform child in _target.transform)
                {
                    if (child.GetComponent<Car>() == car)
                    {
                        carExists = true;
                        break;
                    }
                }

                if (!carExists)
                {
                    carFactory.Create(car, _target.transform);
                }
            }
        }
        
        public void AddCar(int carId)
        {
            if (carId < 0 || carId >= _cars.Length || YG2.saves.OpenedCars.Contains(carId) == false)
                return;

            CarFactory carFactory = new CarFactory();
            foreach (CarData data in _cars)
            {
                if (data.ID == carId)
                {
                    Car car = carFactory.Create(data.CarViewPrefab, _target.transform);
                    
                    Added?.Invoke(car);
                }
            }
        }
    }
}