using System;
using System.Collections.Generic;
using Data;
using Infrastructure.Factories;
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
        private CarFactory _carFactory;

        private int _id;

        public event Action<Car> Added;

        public int ID => _id;
        public CarData Current => _current;

        public void Construct(Target target)
        {
            _target = target;
            _carFactory = new CarFactory();

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

        public void AddCar(int carId)
        {
            if (carId < 0 || carId >= _cars.Length || YG2.saves.OpenedCars.Contains(carId) == false)
                return;

            CarData carData = Array.Find(_cars, data => data.ID == carId);
            
            if (carData == null)
            {
                return;
            }

            Car car = _carFactory.Create(carData.CarViewPrefab, _target.transform);
            Added?.Invoke(car);
        }

        private List<Car> LoadOpenedCars()
        {
            List<Car> openedCars = new List<Car>();

            if (YG2.saves.OpenedCars == null || YG2.saves.OpenedCars.Count == 0)
                return openedCars;

            foreach (int carId in YG2.saves.OpenedCars)
            {
                if (carId >= 0 && carId < _cars.Length)
                {
                    openedCars.Add(_cars[carId].CarViewPrefab);
                }
            }

            return openedCars;
        }

        private void CreateCars()
        {
            List<Car> openedCars = LoadOpenedCars();
            HashSet<Car> existingCars = new HashSet<Car>();
            
            foreach (Transform child in _target.transform)
            {
                if (child.TryGetComponent(out Car car))
                {
                    existingCars.Add(car);
                }
            }

            foreach (Car car in openedCars)
            {
                if (existingCars.Contains(car) == false)
                {
                    _carFactory.Create(car, _target.transform);
                }
            }
        }
    }
}