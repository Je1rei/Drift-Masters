using UnityEngine;

namespace Services
{
    public class CarFactory
    {
        public void Create(Car carViewPrefab, Transform parent)
        {
            Object.Instantiate(carViewPrefab, parent);
        }
    }
}