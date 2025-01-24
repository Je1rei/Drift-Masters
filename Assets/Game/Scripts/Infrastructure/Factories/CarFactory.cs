using Players;
using UnityEngine;

namespace Infrastructure.Factories
{
    public class CarFactory 
    {
        public Car Create(Car carViewPrefab, Transform parent)
        {
            return Object.Instantiate(carViewPrefab, parent);
        }
    }
}