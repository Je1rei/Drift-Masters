using UnityEngine;

namespace Services
{
    public class CarFactory
    {
        public Car Create(Car carViewPrefab, Transform parent)
        {
            return Object.Instantiate(carViewPrefab, parent);
        }
    }
}